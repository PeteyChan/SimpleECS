using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleECS
{
    using Internal;

    /// <summary>
    /// Is called on the component if the component is added to entity with Set() and it was successful
    /// </summary>
    public interface ISetCallback
    {
        void OnSet(Entity entity);
    }

    /// <summary>
    /// Is called when a component implementing this is removed or it's owning entity is destroyed.
    /// If the entity was destroyed, the entity will be invalid when the OnRemove fucntion is called
    /// </summary>
    public interface IRemoveCallback
    {
        void OnRemove(Entity entity);
    }

    public partial struct Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Do not use directly, use Entity.Create() instead
        /// </summary>
        /// <param name="id"></param>
        /// <param name="version"></param>
        public Entity(int id, int version)
        {
            this.index = id; this.version = version;
        }

        /// <summary>
        /// Identifier to map entity to components
        /// </summary>
        public readonly int index;

        /// <summary>
        /// Versioning to verify validity 
        /// </summary>
        public readonly int version;

        /// <summary>
        /// Gets a reference to component. Throws exception if not found or entity is invalid
        /// </summary>
        public ref Component Get<Component>()
            => ref World.Get<Component>(this);

        /// <summary>
        /// Sets the component on entity to value, adds it if entity is valid and it does not have one already.
        /// Inplement the IOnSetComponent interface on component to recieve a callback when item is sucessfully added to entity
        /// </summary>
        public Entity Set<Component>(Component component)
            => World.Set(this, component);

        /// <summary>
        /// Returns true if entity has component
        /// </summary>
        public bool Has<Component>()
            => World.Has<Component>(this);

        /// <summary>
        /// Tries to get the component, returns false if it fails
        /// </summary>
        public bool TryGet<Component>(out Component value)
            => World.TryGet(this, out value);

        /// <summary>
        /// Removes the component from entity if it has one.
        /// Components implementing IDisposable will have
        /// Dispose() called after they've been removed
        /// </summary>
        public Entity Remove<Component>()
            => World.Remove<Component>(this);

        /// <summary>
        /// Destroys the entity.
        /// All components implementing IDisposable will have it called.
        /// Entity is invalid during the Dispose() call
        /// </summary>
        public void Destroy()
            => World.DestroyEntity(this);

        /// <summary>
        /// Returns false if entity is destroyed or otherwise invalid.
        /// Alternatively you can use if(entity) to check for validity
        /// </summary>
        public bool isValid
            => World.IsValid(this);

        public static implicit operator bool(Entity entity)
            => World.IsValid(entity);

        public bool Equals(Entity other)
            => other.index == index && other.version == version;

        public static bool operator ==(Entity a, Entity b)
            => a.index == b.index && a.version == b.version;

        public static bool operator !=(Entity a, Entity b)
            => !(a == b);


        public override bool Equals(object obj)
        {
            if (obj is Entity entity)
                return this == entity;
            return false;
        }

        public override int GetHashCode()
            => index;

        public override string ToString()
        {
            if (!TryGet(out string name) || string.IsNullOrEmpty(name))
                name = "Entity";
            return $"{name} {index}.{version}";
        }
    }

    public static class World
    {
        static World()
        {
            entity_data[0].version = 1;    // so that the default entity is always invalid
        }

        public static IReadOnlyList<Archetype> Archetypes => archetypes;
        static List<Archetype> archetypes = new List<Archetype>();
        static Dictionary<int, List<Archetype>> id_to_archetype = new Dictionary<int, List<Archetype>>();
        static Stack<int> free_entities = new Stack<int>();
        static Entity_Data[] entity_data = new Entity_Data[1024];
        static int entity_data_count;
        public static int EntityCount => entity_data_count - free_entities.Count;

        static bool allow_changes = true;

        /// <summary>
        /// Use to enable or disable structural changes to entities.
        /// When disabled, structural changes are queued and applied when changes are allowed
        /// /// </summary>
        public static bool AllowStructuralChanges
        {
            get => allow_changes; 
            set
            {
                allow_changes = value;
                while (allow_changes && structureEvents.Count > 0)
                {
                    var item = structureEvents.Dequeue();
                    switch (item.event_type)
                    {
                        case StructureEvent.Type.Set:
                            Set(item.entity, item.args, item.component_type, item.component_ID);
                            break;
                        case StructureEvent.Type.Remove:
                            RemoveComponent(item.entity, item.component_ID);
                            break;
                        case StructureEvent.Type.Destroy:
                            DestroyEntity(item.entity);
                            break;
                    }
                }
            }
        }
        static Queue<StructureEvent> structureEvents = new Queue<StructureEvent>();

        struct StructureEvent
        {
            public enum Type
            {
                Set, Remove, Destroy
            }

            public Type event_type;
            public Entity entity;
            public Object args;
            public int component_ID;
            public System.Type component_type;
        }


        public static bool TryGetEntity(int index, out Entity entity)
        {
            if (index >= 0 && index < entity_data.Length)
                entity = new Entity(index, entity_data[index].version);
            else entity = default;
            return IsValid(entity);
        }

        static Entity CreateEntity()
        {
            int entity_index;
            if (free_entities.Count > 0)
            {
                entity_index = free_entities.Pop();
            }
            else
            {
                if (entity_data_count == entity_data.Length)
                    Array.Resize(ref entity_data, entity_data.Length * 2);
                entity_index = entity_data_count;
                entity_data_count++;
            }
            return new Entity(entity_index, entity_data[entity_index].version);
        }

        public static Entity CreateEntity(params Type[] type_signature)
        {
            var sig = new TypeSignature(type_signature);
            return World.CreateEntity(World.GetArchetype(sig));
        }

        public static Entity CreateEntity(Archetype archetype)
        {
            if (!archetype)
                throw new Exception("Archetype is invalid, cannot create Entities");

            int entity_index;
            if (free_entities.Count > 0)
            {
                entity_index = free_entities.Pop();
            }
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

            archetype.entity_pool.Add(entity);
            foreach (var pool in archetype.pools)
                pool.Add(1);
            return entity;
        }

        public static bool IsValid(Entity entity)
            =>  //entity.index >= 0 &&          // there is no real way to have wrong indices under normal operations
                //entity.index < entity.world.entity_data.Length &&
                entity.version == entity_data[entity.index].version;

        public static ref Component Get<Component>(Entity entity)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                if (data.archetype.TryGetPool<Component>(out var pool))
                    return ref pool.Values[data.component_index];
                throw new Exception($"{entity} does not have {typeof(Component).FullName}");
            }
            throw new Exception($"{entity} has been destroyed or is not valid, cannot get component");
        }

        public static Entity Set<Component>(Entity entity, Component component)
        {

            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                {// if component exists set it
                    if (data.archetype.TryGetPool<Component>(out var pool))
                    {
                        pool.Values[data.component_index] = component;
                        if (component is ISetCallback settable)
                        {
                            settable.OnSet(entity);
                        }
                        return entity;
                    }
                }
                if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
                {
                    structureEvents.Enqueue(new StructureEvent
                    {
                        event_type = StructureEvent.Type.Set,
                        entity = entity,
                        args = component,
                        component_ID = TypeID.GetID<Component>.Value,
                        component_type = typeof(Component)
                    });
                    return entity;
                }

                {// otherwise create and return one
                    var target_arch = GetArchetype(new TypeSignature(data.archetype.signature).Add<Component>());
                    var target_index = target_arch.entity_count;

                    // updating archetype entities
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.entity_pool.Remove(data.component_index);
                    target_arch.entity_pool.Add(entity);

                    // move the components over
                    for (int i = 0; i < data.archetype.pools.Count; ++i)
                    {
                        var pool = data.archetype.pools[i];
                        if (target_arch.TryGetPool(pool.ID, out var target_pool))
                            target_pool.Add(pool.Remove(data.component_index));
                        else // should never happen as the new archetype should have all types of the previous one by definition
                            throw new Exception($"FRAMEWORK BUG: Not all components where moved to new archetype, {entity}, {data.archetype} -> {target_arch}");
                    }

                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool<Component>(out var poolT))
                    {
                        poolT.Add(component);
                        if (component is ISetCallback settable)
                        {
                            settable.OnSet(entity);
                        }
                        return entity;
                    }
                    else    // should never happen since the archetype should have the component by definition
                        throw new Exception($"FRAMEWORK BUG: Tried adding component to the wrong archetype {typeof(Component)} {target_arch}");
                }
            }
            return entity;
        }

        static Entity Set(Entity entity, object component, Type componentType, int component_ID)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                {// if component exists set it
                    if (data.archetype.TryGetPool(component_ID, out var pool))
                    {
                        pool.Set(data.component_index, component);
                        if (component is ISetCallback settable)
                        {
                            settable.OnSet(entity);
                        }
                        return entity;
                    }
                }
                if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
                {
                    structureEvents.Enqueue(new StructureEvent
                    {
                        event_type = StructureEvent.Type.Set,
                        entity = entity,
                        args = component,
                        component_ID = component_ID,
                        component_type = componentType
                    });
                    return entity;
                }
                {// otherwise create and return one
                    var target_arch = GetArchetype(new TypeSignature(data.archetype.signature).Add(componentType));
                    var target_index = target_arch.entity_count;

                    // updating archetype entities
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.entity_pool.Remove(data.component_index);
                    target_arch.entity_pool.Add(entity);

                    // move the components over
                    for (int i = 0; i < data.archetype.pools.Count; ++i)
                    {
                        var pool = data.archetype.pools[i];
                        if (target_arch.TryGetPool(pool.ID, out var target_pool))
                            target_pool.Add(pool.Remove(data.component_index));
                        else // should never happen as the new archetype should have all types of the previous one by definition
                            throw new Exception($"FRAMEWORK BUG: Not all components where moved to new archetype, {entity}, {data.archetype} -> {target_arch}");
                    }

                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool(component_ID, out var poolT))
                    {
                        poolT.Add(component);
                        if (component is ISetCallback settable)
                        {
                            settable.OnSet(entity);
                        }
                        return entity;
                    }
                    else    // should never happen since the archetype should have the component by definition
                        throw new Exception($"FRAMEWORK BUG: Tried adding component to the wrong archetype {componentType} {target_arch}");
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
                    structureEvents.Enqueue(new StructureEvent { event_type = StructureEvent.Type.Remove, entity = entity, component_ID = comp_id });
                    return entity;
                }

                ref var data = ref entity_data[entity.index];
                if (data.archetype.TryGetPool(comp_id, out var remove_pool))
                {
                    var comp = remove_pool.Get(data.component_index);
                    var target_arch = GetArchetype(new TypeSignature(data.archetype.signature).Remove(comp_id)); // get target archetype
                    var target_index = target_arch.entity_count;

                    // updating entity
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.entity_pool.Remove(data.component_index);
                    target_arch.entity_pool.Add(entity);

                    for (int i = 0; i < data.archetype.pools.Count; ++i)
                    {
                        var pool = data.archetype.pools[i];
                        var to_move = pool.Remove(data.component_index);
                        if (target_arch.TryGetPool(pool.ID, out var target_pool))
                            target_pool.Add(to_move);
                    }
                    data.component_index = target_index;
                    data.archetype = target_arch;
                    if (comp is IRemoveCallback removeComponent)
                        removeComponent.OnRemove(entity);
                }
            }
            return entity;
        }

        public static Entity Remove<Component>(Entity entity) => RemoveComponent(entity, TypeID.GetID<Component>.Value);

        static Stack<IRemoveCallback> disposables = new Stack<IRemoveCallback>();
        public static void DestroyEntity(Entity entity)
        {
            if (IsValid(entity))
            {
                if (!allow_changes)
                {
                    structureEvents.Enqueue(new StructureEvent { event_type = StructureEvent.Type.Destroy, entity = entity });
                    return;
                }

                ref var data = ref entity_data[entity.index];

                data.version++;
                free_entities.Push(entity.index);
                entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index]
                                .component_index = data.component_index;

                data.archetype.entity_pool.Remove(data.component_index);

                for (int i = 0; i < data.archetype.pools.Count; ++i)
                {
                    var pool = data.archetype.pools[i];

                    var removed = pool.Remove(data.component_index);
                    if (removed is IRemoveCallback disposable)
                        disposables.Push(disposable);
                }
                while (disposables.Count > 0)           // calling onremove() after all structural changes are complete
                    disposables.Pop().OnRemove(entity); // just in case Dispose() causes more structural changes
            }
        }

        public static List<object> GetAllComponents(Entity entity)
        {
            var components = new List<object>();
            if (IsValid(entity))
            {
                var data = entity_data[entity.index];
                for (int i = 0; i < data.archetype.pools.Count; ++i)
                {
                    var pool = data.archetype.pools[i];
                    components.Add(pool.Get(data.component_index));
                }
                return components;
            }
            return components;
        }

        public static bool Has<T>(Entity entity)
            => IsValid(entity) && entity_data[entity.index].archetype.Has<T>();


        public static bool TryGet<T>(Entity entity, out T value)
        {
            if (IsValid(entity))
            {
                var data = entity_data[entity.index];
                if (data.archetype.TryGetPool<T>(out var pool))
                {
                    value = pool.Values[data.component_index];
                    return true;
                }
            }
            value = default;
            return false;
        }

        public static Archetype GetArchetype(Entity entity)
        {
            if (IsValid(entity))
                return entity_data[entity.index].archetype;
            throw new Exception($"{entity} is invalid. Cannot get archetype");
        }

        public static Archetype GetArchetype(TypeSignature.IReadOnly signature)
        {
            if (!id_to_archetype.TryGetValue(signature.ID, out var archtypes))
                id_to_archetype[signature.ID] = archtypes = new List<Archetype>();

            Archetype archetype;
            for (int i = 0; i < archtypes.Count; ++i) // although the hash is good, there is always a slim chance for
            {                                       // collisions. Although this is slower, it'll never fail
                archetype = archtypes[i];
                if (archetype.signature.Equals(signature))
                    return archetype;
            }
            archetype = new Archetype(signature);
            archtypes.Add(archetype);
            archetypes.Add(archetype);
            return archetype;
        }

        /// <summary>
        /// resizes backing arrays to the minimum power of 2 needed to hold it's components.
        /// use after deleting large amounts of entities to reclaim memory
        /// </summary>
        public static void Resize()
        {
            for (int i = 0; i < archetypes.Count; ++i)
                archetypes[i].Resize();

        }

        struct Entity_Data
        {
            public int version;
            public int component_index;
            public Archetype archetype;
        }
    }

    public partial class Query : IReadOnlyList<Archetype>, IEnumerable<Entity>
    {
        public IReadOnlyList<Type> HasTypes => has;
        public IReadOnlyList<Type> NotTypes => not;
        Archetype[] matching_archetypes = new Archetype[8];
        public IReadOnlyList<Archetype> MatchingArchetypes => this;
        public IEnumerable<Entity> MatchingEntities => this;
        /// <summary>
        /// Current world the query operates on, if null will query World.Default
        /// </summary>
        TypeSignature has = new TypeSignature();
        TypeSignature not = new TypeSignature();
        int current_archetype_index; // index of last archetype in world that we checked for a match
        int archetype_count;    // number of matching archetypes
        public int EntityCount  // count of matching entities
        {
            get
            {
                Refresh();
                int count = 0;
                for (int i = 0; i < archetype_count; ++i)
                    count += matching_archetypes[i].entity_count;
                return count;
            }
        }

        /// <summary>
        /// Filters entities to those that have component
        /// </summary>
        public Query Has<T>()
        {
            has.Add<T>();
            return this;
        }

        /// <summary>
        /// Filters entities to those without component
        /// </summary>
        public Query Not<T>()
        {
            not.Add<T>();
            return this;
        }

        public Query Clear()
        {
            has.Clear();
            not.Clear();
            matching_archetypes = new Archetype[8];
            current_archetype_index = 0;
            archetype_count = 0;
            name = null;
            return this;
        }

        string name;
        public override string ToString()
        {
            Refresh();
            if (name == null)
            {
                name = "Query ";
                if (has.Count > 0)
                {
                    name += "[HAS: ";

                    foreach (var type in has.Types)
                        name += type.Name;
                    name += "] ";
                }
                if (not.Count > 0)
                {
                    name += "[NOT: ";
                    foreach (var type in not.Types)
                        name += type.Name;
                    name += "]";
                }
            }
            return $"{name}";
        }

        int lastWorldID;

        /// <summary>
        /// Only needs to be called during manual iteration.
        /// Checks to see if the world has changed, and if so
        /// updates the query as necessary
        /// </summary>
        public void Refresh() // checks for any new archetypes since last run and updates accordingly
        {
            if (current_archetype_index != World.Archetypes.Count)  // check for any new archetypes
            {
                for (int i = current_archetype_index; i < World.Archetypes.Count; ++i)
                {
                    var archetype = World.Archetypes[i];

                    if (!archetype.signature.HasAll(has))
                        goto next_archetype;

                    if (archetype.signature.HasAny(not))
                        goto next_archetype;

                    if (archetype_count == matching_archetypes.Length)
                        Array.Resize(ref matching_archetypes, matching_archetypes.Length * 2);
                    matching_archetypes[archetype_count] = archetype;
                    archetype_count++;

                next_archetype:
                    continue;
                }
                current_archetype_index = World.Archetypes.Count;
            }
        }

        /// <summary>
        /// Destroys all entities that match query
        /// </summary>
        public void DestroyMatches()    // this could potentially be really efficient by destroying the archetype in bulk
        {                               // but good enough for now
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    archetype.entity_pool.Values[itr].Destroy();
            }
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    yield return archetype.entity_pool.Values[itr];
            }
        }

        int IReadOnlyCollection<Archetype>.Count => archetype_count;
        Archetype IReadOnlyList<Archetype>.this[int index] => matching_archetypes[index];

        IEnumerator<Archetype> IEnumerable<Archetype>.GetEnumerator()
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }
    }
}

namespace SimpleECS.Internal
{
    static class TypeID
    {
        static Dictionary<Type, int> newIDs = new Dictionary<Type, int>();
        public static int Get(Type type)
        {
            if (!newIDs.TryGetValue(type, out var id))
                newIDs[type] = id = newIDs.Count + 1;
            return id;
        }

        public static class GetID<T>
        {
            public static readonly int Value = Get(typeof(T));
        }
    }

    public partial class Archetype : IReadOnlyList<IPool>
    {
        public TypeSignature.IReadOnly signature;
        public readonly Pool<Entity> entity_pool;
        int ID;
        public override int GetHashCode() => ID;
        public int entity_count => entity_pool.Count;
        Data[] data_map;
        readonly int component_count;

        public IReadOnlyList<IPool> pools => this;
        public Archetype(TypeSignature.IReadOnly signature)
        {
            this.signature = new TypeSignature(signature);
            this.entity_pool = new Pool<Entity>();
            ID = signature.GetHashCode();

            Stack<(int id, System.Type type)> to_allocate = new Stack<(int, System.Type)>();
            data_map = new Data[signature.Count == 0 ? 1 : signature.Count];
            component_count = signature.Count;
            
            for (int i = 0; i < data_map.Length; ++i)
                data_map[i].next = -1;
            
            if (component_count == 0) return;

            for (int i = 0; i < signature.Count; ++i)
            {
                var value = signature.TypeIds[i];
                var type = signature.Types[i];
                var index = value % data_map.Length;
                ref var pool = ref data_map[index];
                if (pool.ID == 0)
                {
                    pool.ID = value;
                    pool.pool = System.Activator.CreateInstance(typeof(Pool<>).MakeGenericType(type)) as IPool;
                }
                else
                    to_allocate.Push((value, type));
            }

            for (int index = 0; index < data_map.Length; ++index)
            {
                ref var data = ref data_map[index];
                if (data.ID != 0)
                    continue;
                var values = to_allocate.Pop();
                data.ID = values.id;
                data.pool = System.Activator.CreateInstance(typeof(Pool<>).MakeGenericType(values.type)) as IPool;
                var goalIndex = data.ID % data_map.Length;
                while (data_map[goalIndex].next >= 0)
                    goalIndex = data_map[goalIndex].next;
                data_map[goalIndex].next = index;
                if (to_allocate.Count == 0)
                    return;
            }
        }

        public Entity CreateEntity() => World.CreateEntity(this);

        public bool TryGetPool(Type type, out IPool pool)
            => TryGetPool(TypeID.Get(type), out pool);

        public bool TryGetPool<T>(out Pool<T> pool)
        {
            var success = TryGetPool(TypeID.GetID<T>.Value, out var val);
            pool = (Pool<T>)val;
            return success;
        }

        public bool TryGetPool(int type_id, out IPool pool)
        {
            var data = data_map[type_id % data_map.Length]; //TODO: allow zero component 
            if (data.ID == type_id)
            {
                pool = data.pool;
                return true;
            }
            while (data.next >= 0)
            {
                data = data_map[data.next];
                if (data.ID == type_id)
                {
                    pool = data.pool;
                    return true;
                }
            }
            pool = default;
            return false;
        }

        public bool Has<T>()
        {
            var type_id = TypeID.GetID<T>.Value;
            var data = data_map[type_id % data_map.Length];
            if (data.ID == type_id)
                return true;

            while (data.next >= 0)
            {
                data = data_map[data.next];
                if (data.ID == type_id)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Resizes archetypes backing arrays to minium power of 2 needed to store components
        /// </summary>
        public void Resize()
        {
            ((IPool)entity_pool).Resize();
            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Resize();
        }

        struct Data
        {
            public int next;
            public int ID;
            public IPool pool;
        }

        public override string ToString()
            => $"Archetype [{signature}] [{entity_pool.Count}e]";

        public static implicit operator bool(Archetype archetype)
            => archetype == null ? false : true;

        // pool readonly interface
        IEnumerator<IPool> IEnumerable<IPool>.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        int IReadOnlyCollection<IPool>.Count => component_count;

        IPool IReadOnlyList<IPool>.this[int index] => data_map[index].pool;
    }

    public interface IPool
    {
        void Add(object obj);

        void Add(int count);

        /// <summary>
        /// removes component at index, returns removed component
        /// </summary>
        object Remove(int index);

        void Set(int index, object obj);

        object Get(int index);

        void Resize();

        int Count { get; }

        int ID { get; }
    }

    public class Pool<T> : IPool, IReadOnlyList<T>
    {
        T IReadOnlyList<T>.this[int index] => Values[index];
        int IPool.ID => TypeID.GetID<T>.Value;
        int count;
        public T[] Values = new T[8];
        public int Count => count;

        public void Add(int amount)
        {
            count += amount;
            if (count > Values.Length)
            {
                int newSize = Values.Length;
                while (newSize < count)
                    newSize *= 2;
                if (newSize > Values.Length)
                    Array.Resize(ref Values, newSize);
            }
        }

        public void Add(T obj)
        {
            if (count == Values.Length)
                Array.Resize(ref Values, count * 2);
            Values[count] = obj;
            count++;
        }

        public object Remove(int index)
        {
            count--;
            var component = Values[index];
            Values[index] = Values[count];
            Values[count] = default;
            return component;
        }

        void IPool.Add(object obj)
            => Add((T)obj);

        void IPool.Set(int index, object obj)
        {
            Values[index] = (T)obj;
        }

        void IPool.Resize()
        {
            int new_size = 8;
            while (new_size < count)
                new_size *= 2;
            if (new_size == Values.Length)
                return;
            Array.Resize(ref Values, new_size);
        }

        object IPool.Get(int index)
            => Values[index];

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            for (int i = count - 1; i >= 0; --i)
                yield return Values[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = count - 1; i >= 0; --i)
                yield return Values[i];
        }
    }


    public class TypeSignature : IEquatable<TypeSignature>,
                                    IReadOnlyList<Type>,
                                    IReadOnlyList<int>,
                                    TypeSignature.IReadOnly
    {
        public interface IReadOnly
        {
            IReadOnlyList<Type> Types { get; }
            IReadOnlyList<int> TypeIds { get; }
            bool HasAny(TypeSignature signature);
            bool HasAll(TypeSignature signature);
            bool Has<T>();
            int Count { get; }
            int ID { get; }
        }

        int[] type_ids = new int[4];
        Type[] types = new Type[4];
        int type_count;
        public int ID => GetHashCode();
        /// <summary>
        /// Number of types that make up the signature
        /// </summary>
        public int Count => type_count;
        public IReadOnlyList<int> TypeIds => this;  // neat trick to save me having to make another class
        public IReadOnlyList<Type> Types => this;

        public TypeSignature(IReadOnly signature)
        {
            type_count = signature.Count;
            type_ids = new int[type_count + 1];
            types = new Type[type_count + 1];

            for (int i = 0; i < type_count; ++i)
            {
                type_ids[i] = signature.TypeIds[i];
                types[i] = signature.Types[i];
            }
        }
        public TypeSignature(params Type[] types)
        {
            this.type_ids = new int[types.Length + 4];
            this.types = new Type[types.Length + 4];
            foreach (var type in types)
                Add(type);
        }
        public void Clear()
           => type_count = 0;
        TypeSignature Add(int type_id, Type type)
        {
            if (type == null)
                return this;
            sig = null;

            for (int i = 0; i < type_count; ++i)
            {
                if (type_ids[i] == type_id) // if same exit
                    return this;

                if (type_id > type_ids[i])  // since the hash is generated from this, ordering is important
                {
                    var stored_id = type_ids[i];
                    var stored_type = types[i];
                    type_ids[i] = type_id;
                    types[i] = type;
                    type_id = stored_id;
                    type = stored_type;
                }
            }

            if (type_count++ == types.Length)
            {
                Array.Resize(ref types, type_count + 8);
                Array.Resize(ref type_ids, type_count + 8);
            }

            type_ids[type_count - 1] = type_id;
            types[type_count - 1] = type;
            return this;
        }

        public TypeSignature Remove(int type_id)
        {
            sig = null;
            bool swap = type_ids[0] == type_id;
            for (int i = 1; i < type_count; ++i)
            {
                if (swap)
                {
                    type_ids[i - 1] = type_ids[i];
                    types[i - 1] = types[i];
                }
                else
                    swap = type_ids[i] == type_id;
            }
            if (swap)
            {
                type_count--;
            }
            return this;
        }

        public TypeSignature Add(Type type)
            => Add(TypeID.Get(type), type);

        public TypeSignature Add<T>()
            => Add(TypeID.GetID<T>.Value, typeof(T));

        public TypeSignature Remove(Type type)
            => Remove(TypeID.Get(type));

        public TypeSignature Remove<T>()
            => Remove(TypeID.GetID<T>.Value);

        public bool Has<T>() => Has(TypeID.GetID<T>.Value);

        public bool Has(Type type) => Has(TypeID.Get(type));

        public bool Has(int typeid)
        {
            for (int i = 0; i < type_count; ++i)
                if (type_ids[i] == typeid)
                    return true;
            return false;
        }

        /// <summary>
        /// returns true if signatures share any types
        /// </summary>
        public bool HasAny(TypeSignature other)
        {
            for (int a = 0; a < type_count; ++a)
            {
                for (int b = 0; b < other.type_count; ++b)
                {
                    if (type_ids[a] == other.type_ids[b])
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// returns true if this signature has all the other signature's types
        /// </summary>
        /// <returns></returns>
        public bool HasAll(TypeSignature other)
        {
            for (int a = 0; a < other.type_count; ++a)
            {
                for (int b = 0; b < type_count; ++b)
                {
                    if (other.type_ids[a] == type_ids[b])
                        goto next;
                }
                return false;
            next:
                continue;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int prime = 53;
            int power = 1;
            int hashval = 0;

            unchecked
            {
                for (int i = 0; i < type_count; ++i)
                {
                    power *= prime;
                    hashval = (hashval + type_ids[i] * power);
                }
            }
            return hashval;
        }

        public bool Equals(TypeSignature other)
        {
            if (type_count != other.type_count)
                return false;
            for (int i = 0; i < type_count; ++i)
            {
                if (type_ids[i] != other.type_ids[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        => obj is TypeSignature sig ? sig.Equals(this) : false;

        string sig;
        public override string ToString()
        {
            if (sig == null)
            {
                int count = 0;
                for (int i = 0; i < type_count; ++i)
                {
                    sig += $"{types[i].Name} ";
                    count++;
                    if (count > 4)
                    {
                        sig += $"...+{type_count - 4} more";
                        return sig;
                    }
                }
            }
            return sig;
        }

        // Interface methods

        Type IReadOnlyList<Type>.this[int index] => types[index];
        int IReadOnlyList<int>.this[int index] => type_ids[index];

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            for (int i = 0; i < type_count; ++i)
                yield return types[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var type in Types)
                yield return type;
        }

        IEnumerator<int> IEnumerable<int>.GetEnumerator()
        {
            foreach (var id in type_ids)
                yield return id;
        }
    }
}