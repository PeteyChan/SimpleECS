using System;
using System.Collections;
using System.Collections.Generic;

namespace SimpleECS
{
    using Internal;

    /// <summary>
    /// Is called on the component when added to entity with Set()
    /// </summary>
    public interface IOnSetCallback
    {
        void OnSet(Entity entity);
    }

    /// <summary>
    /// Is called on the component when owner entity removed it or is destroyed.
    /// </summary>
    public interface IOnRemoveCallback
    {
        void OnRemove(Entity entity);
    }

    public partial struct Entity : IEquatable<Entity>
    {
        internal Entity(int id, int version)
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
        public Entity Set<Component>(in Component component)
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
        static int[] free_entities = new int[1024];
        static int free_entity_count = 0;
        static Entity_Data[] entity_data = new Entity_Data[1024];
        static int entity_data_count;
        public static int EntityCount => entity_data_count - free_entity_count;

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
                            Set(item.entity, item.component_ID, item.args);
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
        }

        public static bool TryGetEntity(int index, out Entity entity)
        {
            if (index >= 0 && index < entity_data.Length)
                entity = new Entity(index, entity_data[index].version);
            else entity = default;
            return IsValid(entity);
        }

        public static Entity CreateEntity(Archetype archetype)
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

        public static bool IsValid(Entity entity)
            => entity.version == entity_data[entity.index].version;

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

        static TypeSignature signature = new TypeSignature(64);

        public static Entity Set<Component>(in Entity entity, in Component component)
        {
            if (IsValid(entity))
            {
                ref var data = ref entity_data[entity.index];
                {// if component exists set it
                    if (data.archetype.TryGetPool<Component>(out var pool))
                    {
                        pool.Set(entity, data.component_index, component);
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
                        component_ID = TypeID.GetID<Component>.Value
                    });
                    return entity;
                }

                {// otherwise create and return one
                    var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Add<Component>());
                    var target_index = target_arch.entity_count;

                    // updating archetype entities
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool<Component>(out var poolT))
                        poolT.Set(entity, target_index, component);
                    else
                        throw new Exception($"FRAMEWORK BUG: Tried adding component to the wrong archetype {typeof(Component)} {target_arch}");
                }
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
                    pool.Set(entity, data.component_index, component);
                    return entity;
                }

                if (!allow_changes) // if changes are not allowed, queue them and apply the actions later
                {
                    structureEvents.Enqueue(new StructureEvent
                    {
                        event_type = StructureEvent.Type.Set,
                        entity = entity,
                        args = component,
                        component_ID = component_ID
                    });
                    return entity;
                }

                {// otherwise create and return one
                    var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Add(component_ID));
                    var target_index = target_arch.entity_count;

                    // updating archetype entities
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool(component_ID, out var target_pool))
                        target_pool.Set(entity, target_index, component);
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
                    structureEvents.Enqueue(new StructureEvent { event_type = StructureEvent.Type.Remove, entity = entity, component_ID = comp_id });
                    return entity;
                }

                ref var data = ref entity_data[entity.index];
                if (data.archetype.TryGetPool(comp_id, out var pool))
                {
                    var comp = pool.Get(data.component_index);
                    var target_arch = GetArchetype(signature.Copy(data.archetype.signature).Remove(comp_id)); // get target archetype
                    var target_index = target_arch.entity_count;

                    // updating entity
                    entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index].component_index = data.component_index;
                    data.archetype.MoveEntity(data.component_index, target_arch, target_index);
                    data.component_index = target_index;
                    data.archetype = target_arch;

                    if (comp is IOnRemoveCallback removeComponent)
                        removeComponent.OnRemove(entity);
                }
            }
            return entity;
        }

        public static Entity Remove<Component>(Entity entity) => RemoveComponent(entity, TypeID.GetID<Component>.Value);
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

                if (free_entity_count == free_entities.Length)
                    Array.Resize(ref free_entities, free_entities.Length * 2);

                free_entities[free_entity_count] = entity.index;
                free_entity_count++;

                entity_data[data.archetype.entity_pool.Values[data.archetype.entity_count - 1].index]
                                .component_index = data.component_index;

                data.archetype.DestroyEntity(data.component_index);
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

        public static Archetype GetArchetype(TypeSignature signature)
        {
            if (!id_to_archetype.TryGetValue(signature.GetHashCode(), out var archtypes))
                id_to_archetype[signature.GetHashCode()] = archtypes = new List<Archetype>();

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
                Update();
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
            name = null;
            has.Add<T>();
            return this;
        }

        /// <summary>
        /// Filters entities to those without component
        /// </summary>
        public Query Not<T>()
        {
            name = null;
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
            Update();
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

        internal void Update() // checks for any new archetypes since last run and updates accordingly
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
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    yield return archetype.entity_pool.Values[itr];
            }
        }

        IEnumerator<Archetype> IEnumerable<Archetype>.GetEnumerator()
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    yield return archetype.entity_pool.Values[itr];
            }
        }
        int IReadOnlyCollection<Archetype>.Count
        {
            get
            {
                Update();
                return archetype_count;
            }
        }

        Archetype IReadOnlyList<Archetype>.this[int index] => matching_archetypes[index];
    }
}

namespace SimpleECS.Internal
{
    static class TypeID
    {
        static Dictionary<Type, int> newIDs = new Dictionary<Type, int>();
        static Type[] id_to_type = new Type[64];
        public static Type Get(int type_id) => id_to_type[type_id];
        public static int Get(Type type)
        {
            if (!newIDs.TryGetValue(type, out var id))
            {
                newIDs[type] = id = newIDs.Count + 1;
                if (id == id_to_type.Length)
                    Array.Resize(ref id_to_type, id_to_type.Length * 2);
                id_to_type[id] = type;
            }
            return id;
        }

        public static class GetID<T>
        {
            public static readonly int Value = Get(typeof(T));
        }
    }

    public partial class Archetype : IReadOnlyList<Pool>
    {
        internal TypeSignature signature;
        public readonly Pool<Entity> entity_pool;
        public IReadOnlyList<Pool> pools => this;
        int ID;
        public override int GetHashCode() => ID;
        public int entity_count { get; private set; }
        Data[] data_map;
        readonly int component_count;

        internal Archetype(TypeSignature signature)
        {
            this.signature = new TypeSignature(signature);
            this.entity_pool = new Pool<Entity>();
            ID = signature.GetHashCode();

            Stack<(int id, System.Type type)> to_allocate = new Stack<(int, System.Type)>();
            data_map = new Data[signature.Count == 0 ? 1 : signature.Count];
            component_count = signature.Count;

            for (int i = 0; i < data_map.Length; ++i)
                data_map[i].next = -1;

            for (int i = 0; i < component_count; ++i)
            {
                var value = signature.type_ids[i];
                var type = signature.Types[i];
                var index = value % data_map.Length;
                ref var pool = ref data_map[index];
                if (pool.ID == 0)
                {
                    pool.ID = value;
                    pool.pool = CreatePool(type);
                }
                else
                    to_allocate.Push((value, type));
            }

            for (int index = 0; index < component_count; ++index)
            {
                ref var data = ref data_map[index];
                if (data.ID != 0)
                    continue;
                var values = to_allocate.Pop();
                data.ID = values.id;
                data.pool = CreatePool(values.type);
                var goalIndex = data.ID % data_map.Length;
                while (data_map[goalIndex].next >= 0)
                    goalIndex = data_map[goalIndex].next;
                data_map[goalIndex].next = index;
                if (to_allocate.Count == 0)
                    break;
            }

            List<Pool> removables = new List<Pool>();
            for (int i = 0; i < component_count; ++i)
            {
                if (data_map[i].pool.HasOnRemoveCallbacks)
                    removables.Add(data_map[i].pool);
            }
            RemoveCallbackPools = new (Pool, IOnRemoveCallback)[removables.Count];
            for (int i = 0; i < removables.Count; ++i)
                RemoveCallbackPools[i].pool = removables[i];
        }

        internal int AddEntity(Entity entity)   // returns component id
        {
            if (entity_pool.Values.Length == entity_count)
            {
                int capacity = entity_pool.Values.Length * 2;
                entity_pool.Resize(capacity);
                for (int i = 0; i < component_count; ++i)
                    data_map[i].pool.Resize(capacity);
            }
            entity_pool.Values[entity_count] = entity;
            entity_count++;
            return entity_count - 1;
        }

        internal void MoveEntity(int component_index, Archetype archetype, int target_index)
        {
            archetype.AddEntity(entity_pool.Values[component_index]);
            entity_pool.Remove(component_index, entity_count);
            for (int i = 0; i < component_count; ++i)
            {
                data_map[i].pool.Move(component_index, archetype, target_index);
                data_map[i].pool.Remove(component_index, entity_count);
            }
            entity_count--;
        }

        internal void DestroyEntity(int component_index)
        {
            for (int i = 0; i < RemoveCallbackPools.Length; ++i)
                RemoveCallbackPools[i].callback = RemoveCallbackPools[i].pool.Get(component_index) as IOnRemoveCallback;

            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Remove(component_index, entity_count);

            var entity = entity_pool.Values[component_index];
            for (int i = 0; i < RemoveCallbackPools.Length; ++i)
            {
                RemoveCallbackPools[i].callback?.OnRemove(entity_pool.Values[component_index]);
                RemoveCallbackPools[i].callback = default;
            }
            entity_pool.Remove(component_index, entity_count);
            entity_count--;
        }

        (Pool pool, IOnRemoveCallback callback)[] RemoveCallbackPools;

        Pool CreatePool(Type type)
        {
            Type pool_type;
            if (typeof(IOnSetCallback).IsAssignableFrom(type))
                pool_type = typeof(SettablePool<>).MakeGenericType(type);
            else pool_type = typeof(Pool<>).MakeGenericType(type);
            return Activator.CreateInstance(pool_type) as Pool;
        }

        public Entity CreateEntity() => World.CreateEntity(this);

        public bool TryGetPool(Type type, out Pool pool)
            => TryGetPool(TypeID.Get(type), out pool);

        public bool TryGetPool<T>(out Pool<T> pool)
        {
            int type_id = TypeID.GetID<T>.Value;
            var data = data_map[type_id % data_map.Length];
            if (data.ID == type_id)
            {
                pool = (Pool<T>)data.pool;
                return true;
            }
            while (data.next >= 0)
            {
                data = data_map[data.next];
                if (data.ID == type_id)
                {
                    pool = (Pool<T>)data.pool;
                    return true;
                }
            }
            pool = default;
            return false;
        }

        internal bool TryGetPool(int type_id, out Pool pool)
        {
            var data = data_map[type_id % data_map.Length];
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
        /// Resizes archetype's backing arrays to minimum power of 2 needed to store components
        /// </summary>
        public void Resize()
        {
            int length = 8;
            while (length < entity_count)
                length *= 2;
            if (length == entity_pool.Values.Length)
                return;

            ((Pool)entity_pool).Resize(length);
            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Resize(length);
        }

        struct Data
        {
            public int next;
            public int ID;
            public Pool pool;
        }

        public override string ToString()
            => $"Archetype [{signature}] [{entity_count}e]";

        public static implicit operator bool(Archetype archetype)
            => archetype == null ? false : true;

        // pool readonly interface
        IEnumerator<Pool> IEnumerable<Pool>.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        int IReadOnlyCollection<Pool>.Count => component_count;

        Pool IReadOnlyList<Pool>.this[int index] => data_map[index].pool;
    }

    public abstract class Pool
    {
        internal int type_id;
        /// <summary>
        /// removes component at index, returns removed component
        /// </summary>
        internal abstract void Remove(int index, int entity_count);

        internal abstract void Set(in Entity entity, int index, in object obj);

        internal abstract object Get(int index);

        internal abstract void Resize(int capcity);

        internal abstract void Move(int index, Archetype archetype, int new_index);

        internal abstract bool HasOnRemoveCallbacks { get; }
    }

    sealed class SettablePool<T> : Pool<T> where T : IOnSetCallback   // pain in the arse but needed to allow structs
    {                                                                 // to mutate during their OnSetCallback
        internal override void Set(in Entity entity, int index, in object obj)
        {
            Values[index] = (T)obj;
            Values[index]?.OnSet(entity);
        }

        internal override void Set(in Entity entity, int index, in T obj)
        {
            Values[index] = (T)obj;
            Values[index]?.OnSet(entity);
        }
    }

    public class Pool<T> : Pool
    {
        public Pool()
        {
            type_id = TypeID.GetID<T>.Value;
        }

        internal override bool HasOnRemoveCallbacks => typeof(IOnRemoveCallback).IsAssignableFrom(typeof(T));

        public T[] Values = new T[8];

        internal override object Get(int index) => Values[index];

        internal override void Remove(int index, int entity_count)
        {
            Values[index] = Values[entity_count - 1];
            Values[entity_count - 1] = default;
        }

        internal override void Set(in Entity entity, int index, in object obj) => Values[index] = (T)obj;

        internal virtual void Set(in Entity entity, int index, in T obj) => Values[index] = (T)obj;

        internal override void Resize(int capacity) => Array.Resize(ref Values, capacity);

        internal override void Move(int index, Archetype archetype, int target_index)
        {
            if (archetype.TryGetPool<T>(out var pool))
                pool.Values[target_index] = Values[index];
        }
    }


    public sealed class TypeSignature : IEquatable<TypeSignature>, IReadOnlyList<Type>
    {
        internal int[] type_ids;
        internal int type_count;

        /// <summary>
        /// Number of types that make up the signature
        /// </summary>
        public int Count => type_count;
        public IReadOnlyList<Type> Types => this;

        public TypeSignature(int capacity = 4)
        {
            type_ids = new int[capacity];
        }

        public TypeSignature(IEnumerable<Type> types)
        {
            type_ids = new int[4];
            foreach (var type in types)
                Add(type);
        }

        public TypeSignature(TypeSignature signature)
        {
            type_count = signature.Count;
            type_ids = new int[type_count + 1];

            for (int i = 0; i < type_count; ++i)
            {
                type_ids[i] = signature.type_ids[i];
            }
        }
        public TypeSignature(params Type[] types)
        {
            this.type_ids = new int[types.Length];
            foreach (var type in types)
                Add(type);
        }
        public void Clear()
           => type_count = 0;

        internal TypeSignature Add(int type_id)
        {
            for (int i = 0; i < type_count; ++i)
            {
                if (type_ids[i] == type_id) // if same exit
                    return this;

                if (type_id > type_ids[i])  // since the hash is generated from this, ordering is important
                {
                    var stored_id = type_ids[i];
                    type_ids[i] = type_id;
                    type_id = stored_id;
                }
            }

            if (type_count++ == type_ids.Length)
                Array.Resize(ref type_ids, type_count + 4);

            type_ids[type_count - 1] = type_id;
            return this;
        }

        internal TypeSignature Remove(int type_id)
        {
            bool swap = type_ids[0] == type_id;
            for (int i = 1; i < type_count; ++i)
            {
                if (swap)
                    type_ids[i - 1] = type_ids[i];
                else
                    swap = type_ids[i] == type_id;
            }
            if (swap)
                type_count--;
            return this;
        }

        public TypeSignature Copy(TypeSignature signature)
        {
            if (type_ids.Length < signature.type_count)
                Array.Resize(ref type_ids, signature.type_count + 1);
            for (int i = 0; i < signature.type_count; ++i)
                type_ids[i] = signature.type_ids[i];
            type_count = signature.type_count;
            return this;
        }

        public TypeSignature Add(Type type)
            => Add(TypeID.Get(type));

        public TypeSignature Add<T>()
            => Add(TypeID.GetID<T>.Value);

        public TypeSignature Remove(Type type)
            => Remove(TypeID.Get(type));

        public TypeSignature Remove<T>()
            => Remove(TypeID.GetID<T>.Value);

        public bool Has<T>() => Has(TypeID.GetID<T>.Value);

        public bool Has(Type type) => Has(TypeID.Get(type));

        internal bool Has(int typeid)
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

        public override string ToString()
        {
            string sig = "Types [";
            for (int i = 0; i < type_count; ++i)
            {
                var type = TypeID.Get(type_ids[i]);
                sig += $" {type.Name}";
            }
            sig += "]";

            return sig;
        }

        // Interface methods

        Type IReadOnlyList<Type>.this[int index] => TypeID.Get(type_ids[index]);

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            for (int i = 0; i < type_count; ++i)
                yield return TypeID.Get(type_ids[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < type_count; ++i)
                yield return TypeID.Get(type_ids[i]);
        }
    }
}