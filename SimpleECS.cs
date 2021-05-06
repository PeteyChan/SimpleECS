namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public struct Entity : IEquatable<Entity>, IEnumerable<Object>
    {
        /// <summary>
        /// Creates an entity in the deafult world containing supplied components
        /// </summary>
        public Entity(params object[] components)
        {
            var signature = new World.TypeSignature();
            foreach (var component in components)
                signature.Add(component?.GetType());

            var archetype = World.GetArchetype(World.Default, signature);
            var entity = World.CreateEntity(archetype);
            this.index = entity.index;
            this.version = entity.version;
            this.world = entity.world;

            foreach (var item in components)
                if (item != null)
                    if (archetype.TryGetPool(item.GetType(), out var pool))
                        pool.Set(pool.Count - 1, item);
        }

        /// <summary>
        /// Creates an entity in the world provided containing supplied components
        /// </summary>
        public Entity(World world, params object[] components)
        {
            var signature = new World.TypeSignature();
            foreach (var component in components)
                signature.Add(component?.GetType());

            var archetype = World.GetArchetype(world, signature);
            var entity = World.CreateEntity(archetype);
            this.index = entity.index;
            this.version = entity.version;
            this.world = entity.world;

            foreach (var item in components)
                if (item != null)
                    if (archetype.TryGetPool(item.GetType(), out var pool))
                        pool.Set(pool.Count - 1, item);
        }

        /// <summary>
        /// Do Not Use Directly, use Blueprint or the component params constructor instead
        /// </summary>
        public static Entity Create(World world, int id, int version)
            => new Entity(world, id, version);

        Entity(World world, int id, int version)
        {
            this.index = id; this.version = version; this.world = world;
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
        /// World entity belongs to
        /// </summary>
        public readonly World world;

        public int component_count
            => World.GetComponentCount(this);

        /// <summary>
        /// Gets a reference to component. Adds and retrieves a default component it does not have one already
        /// </summary>
        public ref Component Get<Component>()
            => ref World.Get<Component>(this);

        /// <summary>
        /// Sets the component on entity, adds it if it does not have one already
        /// </summary>
        public Entity Set<Component>(Component component)
            => World.Set(this, component);

        /// <summary>
        /// Returns true if entity has component
        /// </summary>
        public bool Has<Component>()
            => World.Has<Component>(this);

        /// <summary>
        /// Tries to get the component, returns false if entity does not have one
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
        /// Entity is invalid when Dispose() is called
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

        /// <summary>
        /// Moves entity to specified world.
        /// Return value is the entity's value in that world.
        /// Current entity will become invalid
        /// </summary>
        public Entity MoveTo(World world)
            => World.MoveEntityToWorld(this, world);

        public bool Equals(Entity other)
            => other.index == index && other.version == version && other.world == world;

        public static bool operator ==(Entity a, Entity b)
            => a.index == b.index && a.version == b.version && a.world == b.world;

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

        IEnumerator<object> IEnumerable<object>.GetEnumerator()
        {
            foreach (var obj in World.GetAllComponents(this))
            {
                yield return obj;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var obj in World.GetAllComponents(this))
            {
                yield return obj;
            }
        }

        public override string ToString()
        {
            if (!TryGet(out string name) || string.IsNullOrEmpty(name))
                name = "Entity";
            return $"{name} {index}.{version}";
        }
    }

    public class World : IEnumerable<World.Archetype>
    {
        public readonly string Name;
        static int world_ids = 0;
        public readonly int ID = world_ids++;
        public static World Default = new World("Default World");

        public IReadOnlyList<Archetype> Archetypes => archetypes;

        List<Archetype> archetypes = new List<Archetype>();

        Dictionary<int, Archetype> id_to_archetype = new Dictionary<int, Archetype>();
        Stack<int> free_entities = new Stack<int>();
        Entity_Data[] entity_data = new Entity_Data[256];
        int entity_data_count;

        public int EntityCount => entity_data_count - free_entities.Count;
        public int ArchetypeCount => archetypes.Count;

        public World()
        {
            this.Name = $"World {ID}";
        }
        public World(string name)
        {
            this.Name = name;
        }

        public static bool TryGetEntity(World world, int index, out Entity entity)
        {
            if (world != null && index >= 0 && index < world.entity_data.Length)
            {
                entity = Entity.Create(world, index, world.entity_data[index].version);
            }
            else entity = default;
            return IsValid(entity);
        }

        Entity CreateEntity()
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
            return Entity.Create(this, entity_index, entity_data[entity_index].version);
        }

        public static Entity CreateEntity(Archetype archetype)
        {
            if (archetype?.world == null)
                throw new Exception("Archetype is invalid, cannot create Entities");
            var world = archetype.world;

            int entity_index;
            if (world.free_entities.Count > 0)
            {
                entity_index = world.free_entities.Pop();
            }
            else
            {
                if (world.entity_data_count == world.entity_data.Length)
                    Array.Resize(ref world.entity_data, world.entity_data.Length * 2);
                entity_index = world.entity_data_count;
                world.entity_data_count++;
            }

            ref var data = ref world.entity_data[entity_index];
            data.archetype = archetype;
            data.component_index = data.archetype.Count;

            var entity = Entity.Create(world, entity_index, data.version);

            archetype.entity_pool.Add(entity);
            foreach (var pool in archetype.pools)
                pool.Add(1);
            return entity;
        }

        public static Entity[] CreateEntities(Archetype archetype, int count)
        {
            if (archetype?.world == null)
                throw new Exception("Archetype is invalid, cannot create Entities");
            var world = archetype.world;

            Entity[] entities = new Entity[count];
            for (int i = 0; i < count; ++i)
            {
                int entity_index;
                if (world.free_entities.Count > 0)
                {
                    entity_index = world.free_entities.Pop();
                }
                else
                {
                    if (world.entity_data_count == world.entity_data.Length)
                        Array.Resize(ref world.entity_data, world.entity_data.Length * 2);
                    entity_index = world.entity_data_count;
                    world.entity_data_count++;
                }
                ref var data = ref world.entity_data[entity_index];
                data.archetype = archetype;
                data.component_index = archetype.Count + i;

                entities[i] = Entity.Create(world, entity_index, data.version);
            }

            int offset = archetype.Count;
            foreach (var pool in archetype.pools)
                pool.Add(entities.Length);

            archetype.entity_pool.Add(entities.Length);
            for (int i = 0; i < entities.Length; ++i)
                archetype.entity_pool.Values[i + offset] = entities[i];
            return entities;
        }
        public static bool IsValid(Entity entity)
            => entity.world != null &&
                //entity.index >= 0 &&          // there is no real way to have wrong indices under normal operations
                //entity.index < entity.world.entity_data.Length &&
                entity.version == entity.world.entity_data[entity.index].version;

        /// <summary>
        /// Gets a reference to component on entity. Automatically adds component to entity if none found
        /// </summary>
        public static ref T Get<T>(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];
                {// if component exists return it
                    if (data.archetype.TryGetPool<T>(out var pool))
                        return ref pool.Values[data.component_index];
                }
                {// otherwise create and return one
                    var target_arch = GetArchetype(world, new TypeSignature().Copy(data.archetype.signature).Add<T>());
                    var target_index = target_arch.Count;

                    // updating archetype entities
                    world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index].component_index = data.component_index;
                    data.archetype.entity_pool.Remove(data.component_index);
                    target_arch.entity_pool.Add(entity);

                    // move the components over
                    foreach (var pool in data.archetype.pools)
                    {
                        if (target_arch.TryGetPool(pool.ID, out var target_pool))
                            target_pool.Add(pool.Remove(data.component_index));
                        else // should never happen as the new archetype should have all types of the previous one by definition
                            throw new Exception($"Not all components where moved to new archetype, {entity}, {data.archetype} -> {target_arch}");
                    }

                    data.component_index = target_index;
                    data.archetype = target_arch;

                    // add the new component
                    if (target_arch.TryGetPool<T>(out var poolT))
                    {
                        poolT.Add(1);
                        return ref poolT.Values[target_index];
                    }
                    else    // should never happen since the archetype should have the component by definition
                        throw new Exception($"Tried adding component to the wrong archetype {typeof(T)} {target_arch}");
                }
            }
            throw new Exception($"{entity} has been destroyed or is not valid, cannot get component");
        }

        public static Entity Remove<T>(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];
                if (data.archetype.TryGetPool<T>(out var remove_pool))
                {
                    var comp = remove_pool.Values[data.component_index];
                    var target_arch = GetArchetype(world, new TypeSignature().Copy(data.archetype.signature).Remove<T>()); // get target archetype
                    var target_index = target_arch.Count;

                    // updating entity
                    world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index].component_index = data.component_index;
                    data.archetype.entity_pool.Remove(data.component_index);
                    target_arch.entity_pool.Add(entity);

                    foreach (var pool in data.archetype.pools)
                    {
                        var to_move = pool.Remove(data.component_index);
                        if (target_arch.TryGetPool(pool.ID, out var target_pool))
                            target_pool.Add(to_move);
                    }
                    data.component_index = target_index;
                    data.archetype = target_arch;
                    (comp as IDisposable)?.Dispose();
                }
            }
            return entity;
        }

        public static void DestroyEntity(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];

                data.version++;
                world.free_entities.Push(entity.index);
                world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index]
                                .component_index = data.component_index;

                data.archetype.entity_pool.Remove(data.component_index);
                var stack = new Stack<IDisposable>();
                foreach (var pool in data.archetype.pools)
                {
                    var removed = pool.Remove(data.component_index);
                    if (removed is IDisposable disposable)
                        stack.Push(disposable);
                }
                while (stack.Count > 0)      // don't want to call dispose until after all the structure changes are done
                    stack.Pop()?.Dispose();  // though this is annoying, maybe a better way?
            }
        }

        public static Entity MoveEntityToWorld(Entity entity, World world)
        {
            if (IsValid(entity) && world != null)
            {
                if (entity.world == world)
                    return entity;

                ref var data = ref entity.world.entity_data[entity.index];

                var world_archetype = World.GetArchetype(world, data.archetype.signature);
                var world_entity = world.CreateEntity();    // create an entity without an archetype
                ref var world_data = ref world.entity_data[world_entity.index];
                world_data.archetype = world_archetype;     // then assign it an archetype
                world_data.component_index = world_archetype.Count;     // moving sets components to last spot in archetype

                entity.world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index]
                                            .component_index = data.component_index;    // remember to update swapped entity when this entity leaves current world

                data.archetype.entity_pool.Remove(data.component_index);
                world_archetype.entity_pool.Add(world_entity);

                foreach (var pool in data.archetype.pools)
                    if (world_archetype.TryGetPool(pool.ID, out var target_pool))
                        target_pool.Add(pool.Remove(data.component_index));
                    else    // should never be thrown since they should have the same type signature 
                        throw new Exception($"{entity} Failed to move all components to {world}: {data.archetype} -> {world_archetype}");

                world_data.archetype.entity_pool.Values[world_data.component_index] = world_entity; // updating the entity value in entity pool of archetype
                entity.world.free_entities.Push(entity.index);   // delete entity from this world
                data.version++;
                return world_entity;
            }
            if (world == null) throw new Exception($"Cannot move {entity} to NULL world");
            throw new Exception($"{entity} has been destroyed or is invalid, cannot move to {world}");
        }

        public static List<object> GetAllComponents(Entity entity)
        {
            var components = new List<object>();
            if (IsValid(entity))
            {
                var data = entity.world.entity_data[entity.index];

                foreach (var pool in data.archetype.pools)
                    components.Add(pool.Get(data.component_index));
                return components;
            }
            return components;
        }

        public static Entity Set<T>(Entity entity, T component)
        {
            Get<T>(entity) = component;
            return entity;
        }

        public static bool Has<T>(Entity entity)
            => IsValid(entity) && entity.world.entity_data[entity.index].archetype.Has<T>();


        public static bool TryGet<T>(Entity entity, out T value)
        {
            if (IsValid(entity))
            {
                var data = entity.world.entity_data[entity.index];
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
                return entity.world.entity_data[entity.index].archetype;
            throw new Exception($"{entity} is invalid. Cannot retrieve archetype");
        }

        public static Archetype GetArchetype(World world, IReadOnly_TypeSignature signature)
        {
            if (world.id_to_archetype.TryGetValue(signature.ID, out var archetype))
            {
                if (signature.Equals(archetype.signature))
                    return archetype;
                // this exception hopefully never gets thrown, but if it does just change the prime used in 
                // the TypeSignature.GetHashCode function to a bigger one
                throw new Exception($"Archetype Hash Collision : {signature} <--> {archetype.signature}");
            }

            world.id_to_archetype[signature.ID] = archetype = new Archetype(world, signature);
            world.archetypes.Add(archetype);
            return archetype;
        }

        public static bool TryGetArchetype(World world, int archetype_ID, out Archetype archetype)
            => world.id_to_archetype.TryGetValue(archetype_ID, out archetype);

        public static int GetComponentCount(Entity entity)
            => IsValid(entity) ? entity.world.entity_data[entity.index].archetype.pools.Length : 0;

        /// <summary>
        /// resizes backing arrays to the minimum power of 2 needed to hold it's components.
        /// use after deleting large amounts of entities to reclaim memory
        /// </summary>
        public void Compact()
        {
            foreach (var archetype in archetypes)
            {
                foreach (var pool in archetype.pools)
                    pool.Resize();
            }
        }


        public override string ToString()
            => $"{Name} [{archetypes.Count}a {EntityCount}e]";

        IEnumerator<Archetype> IEnumerable<Archetype>.GetEnumerator()
        {
            for (int i = archetypes.Count - 1; i >= 0; --i)
                yield return archetypes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = archetypes.Count - 1; i >= 0; --i)
                yield return archetypes[i];
        }

        struct Entity_Data
        {
            public int version;
            public int component_index;
            public Archetype archetype;
        }

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

        public class Archetype : IEnumerable<Entity>
        {
            Dictionary<int, IPool> components = new Dictionary<int, IPool>();
            readonly int ID;
            public readonly World world;
            public IReadOnly_TypeSignature signature;

            public override int GetHashCode() => ID;
            public int Count => entity_pool.Count;
            public readonly Pool<Entity> entity_pool;
            public readonly IPool[] pools;

            public Archetype(World world, IReadOnly_TypeSignature signature)
            {
                this.world = world;
                this.signature = new TypeSignature().Copy(signature);
                pools = new IPool[this.signature.Count];
                for (int i = 0; i < signature.Count; ++i)
                {
                    var type = signature.Types[i];
                    IPool pool = Activator.CreateInstance(typeof(Pool<>).MakeGenericType(type)) as IPool;
                    components.Add(TypeID.Get(type), pool);
                    pools[i] = pool;
                }
                ID = signature.ID;
                entity_pool = new Pool<Entity>();
            }

            public bool TryGetPool<T>(out Pool<T> pool)
            {
                bool success = components.TryGetValue(TypeID.GetID<T>.Value, out var val);
                pool = (Pool<T>)val;
                return success;
            }

            public bool TryGetPool(Type type, out IPool pool)
                => TryGetPool(TypeID.Get(type), out pool);

            public bool Has<T>()
                => components.ContainsKey(TypeID.GetID<T>.Value);

            public bool TryGetPool(int type_id, out IPool pool)
            {
                bool success = components.TryGetValue(type_id, out pool);
                return success;
            }

            string types;
            public override string ToString()
                => $"Archetype [{signature}] [{Count}e]";

            IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
            {
                for (int i = entity_pool.Count - 1; i >= 0; --i)
                    yield return entity_pool.Values[i];
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                for (int i = entity_pool.Count - 1; i >= 0; --i)
                    yield return entity_pool.Values[i];
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
                public T[] Values = new T[8];
                public int Count => count;
                int IPool.ID => TypeID.GetID<T>.Value;
                int count;

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
                void IPool.Add(object obj)
                    => Add((T)obj);

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

                public void Set(int index, object obj)
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

                public object Get(int index)
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
        }

        public interface IReadOnly_TypeSignature
        {
            IReadOnlyList<Type> Types { get; }
            IReadOnlyList<int> TypeIds { get; }
            bool HasAny(TypeSignature signature);
            bool HasAll(TypeSignature signature);
            bool Has<T>();
            int Count { get; }
            int ID { get; }
        }

        public class TypeSignature : IEquatable<TypeSignature>,
                                        IReadOnlyList<Type>,
                                        IReadOnlyList<int>,
                                        IReadOnly_TypeSignature
        {
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

            TypeSignature Remove(Type type, int type_id)
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
                => Remove(type, TypeID.Get(type));

            public TypeSignature Remove<T>()
                => Remove(typeof(T), TypeID.GetID<T>.Value);

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

            /// <summary>
            /// Copies other signature to this signature
            /// </summary>
            public TypeSignature Copy(IReadOnly_TypeSignature other)
            {
                var count = other.TypeIds.Count;
                if (type_count < count)
                {
                    type_ids = new int[count + 1];
                    types = new Type[count + 1];
                }
                type_count = count;
                for (int i = 0; i < count; ++i)
                {
                    type_ids[i] = other.TypeIds[i];
                    types[i] = other.Types[i];
                }
                return this;
            }

            public override int GetHashCode()   // there's only around 4 billion or so possiblities
            {                                   // so on the off chance it does fail
                int prime = 53;                 // just change the prime to a bigger one
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

    /// <summary>
    /// By Default Blueprints spawn entities in World.Default.
    /// 
    /// </summary>
    public class Blueprint
    {
        public Blueprint() { }

        /// <summary>
        /// World this blueprint creates entities in
        /// </summary>
        public Blueprint(World world)
        {
            this.world = world;
        }
        public Blueprint(string name, World world = null)
        {
            this.name = name;
            this.world = world;
        }

        public World world;
        World.TypeSignature signature = new World.TypeSignature();
        World.Archetype archetype;
        Action<Entity> set_components = delegate { };
        Action<Entity> on_complete = delegate { };

        /// <summary>
        /// Adds a defaulted value to entity
        /// </summary>
        public Blueprint Set<Component>()
        {
            signature.Add<Component>();
            archetype = null;
            return this;
        }

        /// <summary>
        /// If component is a class, all entities made by the blueprint will
        /// share the component
        /// </summary>
        public Blueprint Set<Component>(Component component)
        {
            signature.Add<Component>();
            set_components += entity => entity.Get<Component>() = component;
            archetype = null;
            return this;
        }

        /// <summary>
        /// The result of the component created by the function will added to the entity
        /// </summary>
        public Blueprint Set<Component>(Func<Component> component_creation_function)
        {
            signature.Add<Component>();
            set_components += entity => entity.Get<Component>() = component_creation_function();
            archetype = null;
            return this;
        }

        /// <summary>
        /// the entity provided by the function will have all previous components set,
        /// use this if you need information from previous components to make this component
        /// </summary>
        public Blueprint Set<Component>(Func<Entity, Component> component_creation_function)
        {
            signature.Add<Component>();
            set_components += entity => entity.Get<Component>() = component_creation_function(entity);
            archetype = null;
            return this;
        }

        /// <summary>
        /// Action to be performed when all components are set,
        /// subsequent calls will replace previous calls
        /// </summary>
        public Blueprint OnComplete(Action<Entity> onComplete)
        {
            this.on_complete = onComplete;
            return this;
        }

        int last_world_id;
        void UpdateBlueprint()
        {
            var current_world = world == null ? World.Default : world;
            if (last_world_id != current_world.ID)
            {
                archetype = null;
                last_world_id = current_world.ID;
            }
            if (archetype == null)
                archetype = World.GetArchetype(current_world, signature);
        }

        public Entity CreateEntity()
        {
            UpdateBlueprint();
            var entity = World.CreateEntity(archetype);
            set_components(entity);
            on_complete(entity);
            return entity;
        }

        public Entity[] CreateEntities(int count)
        {
            UpdateBlueprint();
            var entities = World.CreateEntities(archetype, count);
            for (int i = 0; i < entities.Length; ++i)
            {
                var entity = entities[i];
                set_components(entity);
                on_complete(entity);
            }
            return entities;
        }

        string name;
        public override string ToString()
        {
            UpdateBlueprint();
            if (name == null)
                name = "Blueprint";
            return $"{name} : {signature}]";
        }
    }

    public class Query : IReadOnlyList<World.Archetype>
    {
        public IReadOnlyList<Type> IncludesTypes => has;
        public IReadOnlyList<Type> ExcludesTypes => not;
        World.TypeSignature has = new World.TypeSignature();
        World.TypeSignature not = new World.TypeSignature();
        int archetype_count;
        World.Archetype[] matching_archetypes = new World.Archetype[8];
        public IReadOnlyList<World.Archetype> MatchingArchetypes => this;
        int current_archetype_index;
        /// <summary>
        /// Current world the query operates on, if null will query World.Default
        /// </summary>
        public World world;
        public int MatchingEntities
        {
            get
            {
                Refresh();
                int count = 0;
                for (int i = 0; i < archetype_count; ++i)
                    count += matching_archetypes[i].Count;
                return count;
            }
        }

        int IReadOnlyCollection<World.Archetype>.Count => archetype_count;
        World.Archetype IReadOnlyList<World.Archetype>.this[int index] => matching_archetypes[index];

        IEnumerator<World.Archetype> IEnumerable<World.Archetype>.GetEnumerator()
        {
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }

        public Query() { }

        /// <summary>
        /// Specify which wolrd the query should operate on
        /// </summary>
        public Query(World world)
        {
            this.world = world;
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
            matching_archetypes = new World.Archetype[8];
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

            return $"{name} [{archetype_count}a {MatchingEntities}e]";
        }

        int lastWorldID;

        /// <summary>
        /// Only needs to be called during manual iteration.
        /// Checks to see if the world has changed, and if so
        /// updates the query as necessary
        /// </summary>
        public void Refresh() // checks for any new archetypes since last run and updates accordingly
        {
            var current_world = world == null ? World.Default : world;
            if (lastWorldID != current_world.ID)                // if the world changed redo the query
            {
                current_archetype_index = 0;
                archetype_count = 0;
                matching_archetypes = new World.Archetype[8];   // new array so the old archetypes can be garbaged collected
                lastWorldID = current_world.ID;
            }

            if (current_archetype_index != current_world.Archetypes.Count)  // check for any new archetypes
            {
                for (int i = current_archetype_index; i < current_world.Archetypes.Count; ++i)
                {
                    var archetype = current_world.Archetypes[i];

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
                current_archetype_index = current_world.Archetypes.Count;
            }
        }

        /// <summary>
        /// Moves all matching entities to world
        /// </summary>
        public void MoveMatchesTo(World world)  // could potenially make this extremely efficient by moving the
        {                                       // archetypes to the other world instead, but good enough for now
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.Count - 1; itr >= 0; --itr)
                    archetype.entity_pool.Values[itr].MoveTo(world);
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
                for (int itr = archetype.Count - 1; itr >= 0; --itr)
                    archetype.entity_pool.Values[itr].Destroy();
            }
        }

        public delegate void query<C1>(ref C1 c1);
        public delegate void query<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void query<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);

        /// <summary>
        /// performs action on all entities matching the query and all components in action
        /// </summary>
        public void Foreach<C1>(query<C1> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)  // go backwards so new archetypes aren't updating
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1))  // skips archetype if not all components in action are contained in archetype
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr) // go backwards so entity operations can be performed synchonously
                        action(ref pool_c1.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2>(query<C1, C2> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3>(query<C1, C2, C3> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4>(query<C1, C2, C3, C4> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5>(query<C1, C2, C3, C4, C5> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(query<C1, C2, C3, C4, C5, C6> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6) &&
                    archetype.TryGetPool<C7>(out var pool_c7))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr],
                                ref pool_c7.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6) &&
                    archetype.TryGetPool<C7>(out var pool_c7) &&
                    archetype.TryGetPool<C8>(out var pool_c8))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr],
                                ref pool_c7.Values[itr],
                                ref pool_c8.Values[itr]);
                }
            }
        }

        public delegate void entity_query(in Entity entity);
        public delegate void entity_query<C1>(in Entity entity, ref C1 c1);
        public delegate void entity_query<C1, C2>(in Entity entity, ref C1 c1, ref C2 c2);
        public delegate void entity_query<C1, C2, C3>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void entity_query<C1, C2, C3, C4>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void entity_query<C1, C2, C3, C4, C5>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);

        public void Foreach(entity_query action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0)
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr]);
                }
            }
        }

        /// <summary>
        /// performs action on all entities matching the query and all components in action
        /// </summary>
        public void Foreach<C1>(entity_query<C1> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)  // go backwards so new archetypes aren't updating
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1))  // skips archetype if not all components in action are contained in archetype
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr) // go backwards so entity operations can be performed synchonously
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2>(entity_query<C1, C2> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3>(entity_query<C1, C2, C3> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4>(entity_query<C1, C2, C3, C4> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5>(entity_query<C1, C2, C3, C4, C5> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(entity_query<C1, C2, C3, C4, C5, C6> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(entity_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6) &&
                    archetype.TryGetPool<C7>(out var pool_c7))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr],
                                ref pool_c7.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Refresh();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count > 0 &&
                    archetype.TryGetPool<C1>(out var pool_c1) &&
                    archetype.TryGetPool<C2>(out var pool_c2) &&
                    archetype.TryGetPool<C3>(out var pool_c3) &&
                    archetype.TryGetPool<C4>(out var pool_c4) &&
                    archetype.TryGetPool<C5>(out var pool_c5) &&
                    archetype.TryGetPool<C6>(out var pool_c6) &&
                    archetype.TryGetPool<C7>(out var pool_c7) &&
                    archetype.TryGetPool<C8>(out var pool_c8))
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr)
                        action(archetype.entity_pool.Values[itr],
                                ref pool_c1.Values[itr],
                                ref pool_c2.Values[itr],
                                ref pool_c3.Values[itr],
                                ref pool_c4.Values[itr],
                                ref pool_c5.Values[itr],
                                ref pool_c6.Values[itr],
                                ref pool_c7.Values[itr],
                                ref pool_c8.Values[itr]);
                }
            }
        }
    }
}
