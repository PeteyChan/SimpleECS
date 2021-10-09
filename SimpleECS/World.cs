namespace SimpleECS
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manages all Entity and Archetype information
    /// </summary>
    public sealed partial class World
    {
        /// <summary>
        /// Default World
        /// </summary>
        public readonly static World Default = new World("Default World");

#pragma warning disable
        public override string ToString() => Name;
#pragma warning restore

        static int count;

        /// <summary>
        /// Creates a new world
        /// </summary>
        public World() => Name = "World " + (++count).ToString();

        /// <summary>
        /// Creates a new world with name
        /// </summary>
        public World(string name) => Name = name;

        const int INITIAL_CAPACITY = 1024;

        /// <summary>
        /// Name of the world
        /// </summary>
        /// <value></value>
        public string Name { get; private set; }
        
        /// <summary>
        /// A list of all archetypes currently owned by the world
        /// </summary>
        public IReadOnlyList<Archetype> Archetypes => archetypes;
        List<Archetype> archetypes = new List<Archetype>();
        Dictionary<int, List<Archetype>> id_to_archetype = new Dictionary<int, List<Archetype>>();
        int[] free_entities = new int[INITIAL_CAPACITY];
        int free_entity_count = 0;
        (int version, Archetype archetype, int component_index)[] entity_data = new (int, Archetype, int)[INITIAL_CAPACITY];
        int entity_data_count;
        TypeSignature signature = new TypeSignature(32);    // reused in methods such as Set() and Remove() to avoid gc pressure
        Queue<StructureEvent> structure_event_cache = new Queue<StructureEvent>(INITIAL_CAPACITY); // used to store events created during foreach iterations

        /// <summary>
        /// The current total amount of entities in existance
        /// </summary>
        public int EntityCount => entity_data_count - free_entity_count;

        bool allow_changes = true;

        /// <summary>
        /// Use to enable or disable structural changes to entities.
        /// When disabled, structural changes caused by Set(), Remove() and Destroy() 
        /// are queued and applied when changes are once again enabled
        /// /// </summary>
        public bool AllowStructuralChanges
        {
            get => allow_changes;
            set
            {
                allow_changes = value;
                while (allow_changes && structure_event_cache.Count > 0)
                {
                    var item = structure_event_cache.Dequeue();
                    switch (item.event_type)
                    {
                        case StructureEvent.Type.Set:
                            Set(item.entity, item.component_ID, item.args);
                            break;
                        case StructureEvent.Type.Remove:
                            RemoveComponent(item.entity, item.component_ID);
                            break;
                        case StructureEvent.Type.Destroy:
                            Destroy(item.entity);
                            break;
                        case StructureEvent.Type.Transfer:
                            Transfer(item.entity, (World)item.args);
                            break;
                        case StructureEvent.Type.Create:
                            ref var data = ref entity_data[item.entity.index];
                            data.version = item.entity.version;
                            data.component_index = data.archetype.entity_count;
                            data.archetype.AddEntity(item.entity);
                            break;
                    }
                }
            }
        }

        void CacheEvent(StructureEvent.Type event_type, Entity entity, int compID = 0, in object args = default)
        {
            structure_event_cache.Enqueue(new StructureEvent { event_type = event_type, entity = entity, component_ID = compID, args = args });
        }

        struct StructureEvent
        {
            public enum Type
            {
                Set, Remove, Destroy, Transfer, Create
            }

            public Type event_type;
            public Entity entity;
            public Object args;
            public int component_ID;
        }

        /// <summary>
        /// Tries to get entity by index, returns false if entity is invalid
        /// </summary>
        public bool TryGetEntity(int index, out Entity entity)
        {
            if (index >= 0 && index < entity_data.Length)
            {
                var data = entity_data[index];
                var comp_id = data.component_index;
                if (data.archetype)
                {
                    if (comp_id < data.archetype.entity_pool.Length)
                        entity = data.archetype.entity_pool[comp_id];
                    else entity = default;
                    if (entity.index != index)
                        entity = default;
                    return entity;
                }
            }
            return entity = default;
        }

        /// <summary>
        /// Creates a query that operates on this world
        /// </summary>
        public Query CreateQuery() => new Query(this);

        /// <summary>
        /// Creates a new Entity
        /// </summary>
        public Entity CreateEntity()
        {
            signature.Clear();
            return CreateEntityWithArchetype(GetArchetype(signature));
        }

        /// <summary>
        /// Creates a new entity using the provided archetype with default components.
        /// This method does not trigger OnSet()
        /// </summary>
        public Entity CreateEntityWithArchetype(Archetype archetype)
        {
            if (!archetype) throw new Exception("An invalid archetype cannot create Entities");
            
            int entity_index;
            if (free_entity_count > 0)
                entity_index = free_entities[--free_entity_count];
            else
            {
                if (entity_data_count == entity_data.Length)
                    Array.Resize(ref entity_data, entity_data.Length * 2);
                entity_index = entity_data_count;
                entity_data_count++;
            }

            ref var data = ref entity_data[entity_index];
            data.archetype = archetype;
            var entity = new Entity(entity_index, data.version, this);
            if (!allow_changes)
            {
                data.version--; // entity is invalid while it's cached, you can still add or remove components though
                CacheEvent(StructureEvent.Type.Create, entity); // while it's in this state though
            }
            else
            {
                data.component_index = data.archetype.entity_count;
                archetype.AddEntity(entity);
            }
            return entity;
        }

        /// <summary>
        /// Returns true if entity is valid
        /// </summary>
        public static bool IsValid(Entity entity)
            => entity.world != null && entity.version == entity.world.entity_data[entity.index].version;

        /// <summary>
        /// Returns false if archetype is not valid or Destroyed by world.DestroyEmptyArchetypes()
        /// </summary>
        public static bool IsValid(Archetype archetype)
            => archetype?.entity_pool == null ? false : true;

        internal ref Component Get<Component>(int index, int version )
        {
            if (entity_data[index].version == version)
            {
                ref var data = ref entity_data[index];
                if (data.archetype.TryGetArray<Component>(out var pool))
                    return ref pool[data.component_index];
                throw new Exception($"{new Entity(index, version, this)} does not have {typeof(Component).FullName}");
            }
            throw new Exception($"{ new Entity(index, version, this)} has been destroyed or is not valid, cannot get component");
        }

        internal Entity Set<Component>(in Entity entity, in Component component)
        {
            if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
            {
                CacheEvent(StructureEvent.Type.Set, entity, TypeID<Component>.Value, component);
                return entity;
            }

            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];

                if (data.archetype.TryGetPool<Component>(out var pool)) // if component exists set it and return
                {
                    pool.SetValue(entity, data.component_index, component);
                    return entity;
                }

                // otherwise create and return one
                var target_arch = GetArchetype(signature.Copy(data.archetype).Add<Component>());
                var target_index = target_arch.entity_count;

                // updating archetype entity component information
                entity_data[data.archetype.entity_pool[data.archetype.entity_count - 1].index]
                    .component_index = data.component_index;
                data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                data.component_index = target_index;
                data.archetype = target_arch;

                // add the new component
                if (target_arch.TryGetPool<Component>(out var target_pool))
                    target_pool.SetValue(entity, target_index, component);
                else
                    throw new Exception($"FRAMEWORK BUG: Tried adding component to the wrong archetype {typeof(Component)} {target_arch}");
            }
            return entity;
        }

        internal Entity Transfer(in Entity entity, World target_world)   // I don't think this needs to be cached when 
        {
            if (!allow_changes)
            {
                CacheEvent(StructureEvent.Type.Transfer, entity, args: target_world);
                return entity;
            }
            
            if (IsValid(entity) && this != target_world)
            {
                ref var data = ref entity_data[entity.index];
                var target_archetype = target_world.GetArchetype(data.archetype.signature);
                var target_entity = target_world.CreateEntityWithArchetype(target_archetype);
                var target_data = target_world.entity_data[target_entity.index];

                data.archetype.TransferEntity(data.component_index, target_archetype, target_data.component_index);
                data.version++;

                if (free_entity_count == free_entities.Length)
                    Array.Resize(ref free_entities, free_entities.Length * 2);

                free_entities[free_entity_count] = entity.index;
                free_entity_count++;
                return target_entity;
            }
            return entity;
        }

        Entity Set(Entity entity, int component_ID, object component)
        {
            if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
            {
                CacheEvent(StructureEvent.Type.Set, entity, component_ID, component);
                return entity;
            }

            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                // if component exists set it
                if (data.archetype.TryGetPool(component_ID, out var pool))
                {
                    pool.SetObject(entity, data.component_index, component);
                    return entity;
                }


                {// otherwise create and return one
                    var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Add(component_ID));
                    var target_index = target_arch.entity_count;

                    // updating archetype entities
                    entity_data[data.archetype.entity_pool[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool(component_ID, out var target_pool))
                        target_pool.SetObject(entity, target_index, component);
                    else
                        throw new Exception($"FRAMEWORK BUG: Tried adding component to the wrong archetype {TypeID.Get(component_ID).FullName} {target_arch}");
                }
            }
            return entity;
        }

        Entity RemoveComponent(Entity entity, int comp_id)
        {
            if (!allow_changes)
            {
                CacheEvent(StructureEvent.Type.Remove, entity, comp_id);
                return entity;
            }

            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                if (data.archetype.TryGetPool(comp_id, out var pool))
                {
                    var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Remove(comp_id)); // get target archetype
                    var target_index = target_arch.entity_count;

                    // updating entity
                    entity_data[data.archetype.entity_pool[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                    data.component_index = target_index;
                    data.archetype = target_arch;
                    pool.RemoveCallback(entity);
                }
            }
            return entity;
        }

        internal Entity Remove<Component>(Entity entity) => RemoveComponent(entity, TypeID<Component>.Value);

        internal void Destroy(in Entity entity)
        {
            if (!allow_changes)
            {
                CacheEvent(StructureEvent.Type.Destroy, entity);
                return;
            }

            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                data.version++;

                if (free_entity_count == free_entities.Length)
                    Array.Resize(ref free_entities, free_entities.Length * 2);

                free_entities[free_entity_count] = entity.index;
                free_entity_count++;

                entity_data[data.archetype.entity_pool[data.archetype.entity_count - 1].index]
                                .component_index = data.component_index;

                data.archetype.DestroyEntity(data.component_index);
            }
        }

        internal List<Object> GetAllComponents(Entity entity, List<object> storage = null)
        {
            if (storage == null) storage = new List<object>();
            else storage.Clear();

            if (IsValid(entity))
            {
                var data = entity_data[entity.index];
                data.archetype.GetAllComponents(data.component_index, storage);
            }
            return storage;
        }

        internal bool Has<T>(Entity entity)
            => entity_data[entity.index].version == entity.version && entity_data[entity.index].archetype.Has<T>();

        internal bool TryGet<T>(Entity entity, out T value)
        {
            if (entity_data[entity.index].version == entity.version)
            {
                var data = entity_data[entity.index];
                if (data.archetype.TryGetArray<T>(out var pool))
                {
                    value = pool[data.component_index];
                    return true;
                }
            }
            value = default;
            return false;
        }

        internal bool TryGetArchetype(in Entity entity, out Archetype archetype)
        {
            if (entity_data[entity.index].version == entity.version)
            {
                archetype = entity_data[entity.index].archetype;
                return true;
            }
            archetype = default;
            return false;
        }

        internal bool TryGetData(in Entity entity, out (int version, Archetype archetype, int component_index) data)
        {
            data = entity_data[entity.index];
            return entity.version == data.version;
        }

        /// <summary>
        /// Gets the archetype with the associated type signature 
        /// </summary>
        public Archetype GetArchetype(TypeSignature signature)
        {
            if (!id_to_archetype.TryGetValue(signature.GetHashCode(), out var stored_archetypes))
                id_to_archetype[signature.GetHashCode()] = stored_archetypes = new List<Archetype>();

            Archetype archetype;
            for (int i = 0; i < stored_archetypes.Count; ++i)   // although the hash is good, there is always a slim chance for
            {                                           // collisions. Although this is slower, it'll never fail
                archetype = stored_archetypes[i];
                if (archetype.signature.Equals(signature))
                    return archetype;
            }
            archetype = new Archetype(this, signature);
            stored_archetypes.Add(archetype);
            archetypes.Add(archetype);
            return archetype;
        }

        internal int Version; // version updates whenever archetypes are destroyed

        /// <summary>
        /// Destroys all archetypes with no entities.
        /// </summary>
        public void DestroyEmptyArchetypes()
        {
            List<Archetype> kept_archs = new List<Archetype>();
            foreach (var pending in archetypes)
                if (pending.entity_count > 0)
                    kept_archs.Add(pending);
                else
                    pending.Destroy();

            archetypes.Clear();
            id_to_archetype.Clear();
            foreach (var archetype in kept_archs)
            {
                var id = archetype.signature.GetHashCode();
                if (!id_to_archetype.TryGetValue(id, out var stored_archs))
                    id_to_archetype[id] = stored_archs = new List<Archetype>();
                stored_archs.Add(archetype);
                archetypes.Add(archetype);
            }
            Version++;
        }

        /// <summary>
        /// Resizes all archetype backing arrays to the minimum power of 2 needed to hold their components.
        /// Useful after deleting large amounts of entities or transitioning to other scenes in game engines.
        /// </summary>
        public void ResizeBackingArrays()
        {
            for (int i = 0; i < archetypes.Count; ++i)
                archetypes[i].ResizeBackingArrays();
        }

        /// <summary>
        /// Destroys all empty archetypes, resizes all backing arrays then does a GC.Collect();
        /// </summary>
        public void Compact()
        {
            DestroyEmptyArchetypes();
            ResizeBackingArrays();
            GC.Collect();
        }

        Dictionary<int, object> ComponentCallbacks = new Dictionary<int, object>();

        class Component_Event<T>
        {
            public Delegates.ComponentCallback<T> callback;
        }

        /// <summary>
        /// When an entity sets the Component, the supplied callback will be invoked
        /// </summary>
        /// <param name="callback">delegate params (Entity entity, ref Component component)</param>
        /// <param name="register">Set to false to unregister the callback</param>
        public void OnSet<Component>(Delegates.ComponentCallback<Component> callback, bool register = true)
        {
            if (!ComponentCallbacks.TryGetValue(TypeID<Component>.Value, out var value))
                ComponentCallbacks[TypeID<Component>.Value] = value = new Component_Event<Component>();

            var e = (Component_Event<Component>)value;
            if (register)
                e.callback += callback;
            else e.callback -= callback;/**/
        }

        /// <summary>
        /// When an entity removes the Component, the supplied callback will be invoked
        /// </summary>
        /// <param name="callback">delegate params (Entity entity, ref Component component)</param>
        /// <param name="register">Set to false to unregister the callback</param>
        public void OnRemove<Component>(Delegates.ComponentCallback<Component> callback, bool register = true)
        {
            if (!ComponentCallbacks.TryGetValue(-TypeID<Component>.Value, out var value))
                ComponentCallbacks[-TypeID<Component>.Value] = value = new Component_Event<Component>();

            var e = (Component_Event<Component>)value;
            if (register)
                e.callback += callback;
            else e.callback -= callback;/**/
        }

        void InvokeSetEvent<T>(in Entity entity, ref T component)
        {
            if (ComponentCallbacks.TryGetValue(TypeID<T>.Value, out var val))
                ((Component_Event<T>)val).callback.Invoke(entity, ref component);
        }

        void InvokeRemoveEvent<T>(in Entity entity, ref T component)
        {
            if (ComponentCallbacks.TryGetValue(-TypeID<T>.Value, out var val))
                ((Component_Event<T>)val).callback.Invoke(entity, ref component);
        }
    }

    namespace Delegates
    {
        /// <summary>
        /// Delegate used for Component Events
        /// </summary>
        /// <param name="entity">Entity calling the event</param>
        /// <param name="component">Component used in the event</param>
        public delegate void ComponentCallback<T>(Entity entity, ref T component);
    }
}
