namespace SimpleECS
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Manages all Entity and Archetype information
    /// </summary>
    public static class World
    {
        const int INITIAL_CAPACITY = 1024;

        static World()
        {
            entity_data[0].version = 1;    // so that the default entity is always invalid
        }

        /// <summary>
        /// A list of all archetypes currently owned by the world
        /// </summary>
        public static IReadOnlyList<Archetype> Archetypes => archetypes;
        static List<Archetype> archetypes = new List<Archetype>();
        static Dictionary<int, List<Archetype>> id_to_archetype = new Dictionary<int, List<Archetype>>();
        static int[] free_entities = new int[INITIAL_CAPACITY];
        static int free_entity_count = 0;
        static Entity_Data[] entity_data = new Entity_Data[INITIAL_CAPACITY];
        static int entity_data_count;

        /// <summary>
        /// The current total amount of entities in existance
        /// </summary>
        public static int EntityCount => entity_data_count - free_entity_count;

        static bool allow_changes = true;

        /// <summary>
        /// Use to enable or disable structural changes to entities.
        /// When disabled, structural changes caused by Set(), Remove() and Destroy() 
        /// are queued and applied when changes are once again enabled
        /// /// </summary>
        public static bool AllowStructuralChanges
        {
            get => allow_changes;
            set
            {
                allow_changes = value;
                while (allow_changes && StructureEvent.queue.Count > 0)
                {
                    var item = StructureEvent.queue.Dequeue();
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
                    }
                }
            }
        }


        struct StructureEvent
        {
            public static Queue<StructureEvent> queue = new Queue<StructureEvent>(INITIAL_CAPACITY);
            public static void Post(Type event_type, Entity entity, int compID = 0, in object args = default)
            {
                queue.Enqueue(new StructureEvent { event_type = event_type, entity = entity, component_ID = compID, args = args });
            }

            public enum Type
            {
                Set, Remove, Destroy
            }

            public Type event_type;
            public Entity entity;
            public Object args;
            public int component_ID;
        }

        /// <summary>
        /// Tries to get entity by index, returns false if entity is invalid
        /// </summary>
        public static bool TryGetEntity(int index, out Entity entity)
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
                        entity =default;
                    return entity;
                }
            }
            return entity = default;
        }

        /// <summary>
        /// Creates an entity in the archetype with default components
        /// </summary>
        public static Entity CreateEntity(this Archetype archetype)
        {
            if (!archetype)
                throw new Exception("Archetype is invalid, cannot create Entities");

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
            data.component_index = data.archetype.entity_count;
            var entity = new Entity(entity_index, data.version);
            archetype.AddEntity(entity);
            return entity;
        }

        /// <summary>
        /// Returns false if entity was destroyed or not valid
        /// </summary>
        public static bool IsValid(this Entity entity)
            => entity.version == entity_data[entity.index].version;

        /// <summary>
        /// Returns false if archetype is not valid or Removed by World.RemoveEmptyArchetypes()
        /// </summary>
        public static bool IsValid(this Archetype archetype)
            => archetype?.entity_pool == null ? false : true;

        /// <summary>
        /// Gets component on entity by reference.
        /// Throws an exception if the entity is invalid or does not have
        /// the component
        /// </summary>
        public static ref Component Get<Component>(this in Entity entity)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                if (data.archetype.TryGetArray<Component>(out var pool))
                    return ref pool[data.component_index];
                throw new Exception($"{entity} does not have {typeof(Component).FullName}");
            }
            throw new Exception($"{entity} has been destroyed or is not valid, cannot get component");
        }

        static TypeSignature signature = new TypeSignature(64);

        /// <summary>
        /// Sets the component on entity to value, if the entity does not already have
        /// the component it will add it to the entity. Methods marked with OnSetCallback 
        /// with this type will be invoked
        /// </summary>
        public static Entity Set<Component>(this in Entity entity, in Component component)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];

                if (data.archetype.TryGetPool<Component>(out var pool)) // if component exists set it and return
                {
                    pool.SetValue(entity, data.component_index, component);
                    return entity;
                }

                if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
                {
                    StructureEvent.Post(StructureEvent.Type.Set, entity, TypeID<Component>.Value, component);
                    return entity;
                }

                // otherwise create and return one
                var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Add<Component>());
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

        static Entity Set(Entity entity, int component_ID, object component)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                // if component exists set it
                if (data.archetype.TryGetPool(component_ID, out var pool))
                {
                    pool.SetObject(entity, data.component_index, component);
                    return entity;
                }

                if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
                {
                    StructureEvent.Post(StructureEvent.Type.Set, entity, component_ID, component);
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

        static Entity RemoveComponent(Entity entity, int comp_id)
        {
            if (IsValid(entity))
            {
                if (!allow_changes)
                {
                    StructureEvent.Post(StructureEvent.Type.Remove, entity, comp_id);
                    return entity;
                }

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
                    pool.remove_callback?.Invoke(entity);
                }
            }
            return entity;
        }

        /// <summary>
        /// Removes the component type from entity if entity has one.
        /// Methods marked with the OnRemoveCallback attribute with this component will be invoked if it was removed
        /// </summary>
        public static Entity Remove<Component>(this Entity entity) => RemoveComponent(entity, TypeID<Component>.Value);

        /// <summary>
        /// Destroys the entity. Methods marked with OnRemoveCallback of any of the components destroyed will 
        /// be invoked. The entity will be invalid during the callback.
        /// </summary>
        public static void Destroy(this Entity entity)
        {
            if (IsValid(entity))
            {
                if (!allow_changes)
                {
                    StructureEvent.Post(StructureEvent.Type.Destroy, entity);
                    return;
                }

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

        /// <summary>
        /// Returns all components on entity.
        /// Pass in your own storage to avoid allocations
        /// </summary>
        public static List<Object> GetAllComponents(this Entity entity, List<object> storage = null)
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

        /// <summary>
        /// Returns true if this entity has the component
        /// </summary>
        public static bool Has<T>(this Entity entity)
            => IsValid(entity) && entity_data[entity.index].archetype.Has<T>();

        /// <summary>
        /// Tries to get the component, if the entity doesn't have one it will return false
        /// </summary>
        public static bool TryGet<T>(this Entity entity, out T value)
        {
            if (IsValid(entity))
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

        /// <summary>
        /// Tries to get the entity's archetype
        /// Returns false if entity is destroyed or invalid
        /// </summary>
        public static bool TryGetArchetype(this Entity entity, out Archetype archetype)
        {
            if (IsValid(entity))
            {
                archetype = entity_data[entity.index].archetype;
                return true;
            }
            archetype = default;
            return false;
        }

        /// <summary>
        /// Gets the archetype with the associated type signature 
        /// </summary>
        /// <returns></returns>
        public static Archetype GetArchetype(TypeSignature signature)
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
            archetype = new Archetype(signature);
            stored_archetypes.Add(archetype);
            archetypes.Add(archetype);
            return archetype;
        }

        internal static int Version; // version updates whenever archetypes are destroyed

        /// <summary>
        /// Removes all archetypes with no entities.
        /// </summary>
        public static void RemoveEmptyArchetypes()
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
        public static void ResizeBackingArrays()
        {
            for (int i = 0; i < archetypes.Count; ++i)
                archetypes[i].ResizeBackingArrays();
        }

        /// <summary>
        /// Removes all empty archetypes, resizes all backing arrays then does a GC.Collect();
        /// </summary>
        public static void Compact()
        {
            RemoveEmptyArchetypes();
            ResizeBackingArrays();
            GC.Collect();
        }

        struct Entity_Data
        {
            public int version;
            public int component_index;
            public Archetype archetype;
        }
    }
}