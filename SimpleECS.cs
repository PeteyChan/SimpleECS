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
            var signature = new World.Type_Signature(components.Length);
            signature.Add(typeof(Entity));
            foreach (var component in components)
                signature.Add(component?.GetType());
            var archetype = World.GetArchetype(World.Default, signature);
            var entity = World.CreateEntity(archetype);
            this.index = entity.index;
            this.version = entity.version;
            this.world = entity.world;

            foreach (var item in components)
                if (item != null || item.GetType() != typeof(Entity))
                    if (archetype.TryGetPool(item.GetType(), out var pool))
                        pool.SetComponent(pool.Count - 1, item);
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

        /// <summary>
        /// Gets a reference to component. Automatically adds the component to entity if it does not have one already
        /// </summary>
        public ref Component Get<Component>()
            => ref World.Get<Component>(this);

        /// <summary>
        /// Automatically adds the component to entity if it does not have one already
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
        /// Removes the component type from entity if it has one.
        /// Components implementing IDisposable will have it called when they are removed
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
            if (TryGet(out string name) || string.IsNullOrEmpty(name))
                name = "Entity";
            return $"{name} {index}.{version}";
        }
    }

    public class World : IEnumerable<World.Archetype>
    {
        static int world_ids = 0;
        public readonly int ID = world_ids++;
        public static World Default = new World();

        public IReadOnlyList<Archetype> Archetypes => archetypes;

        List<Archetype> archetypes = new List<Archetype>();

        Dictionary<int, Archetype> id_to_archetype = new Dictionary<int, Archetype>();
        Stack<int> free_entities = new Stack<int>();
        Entity_Data[] entity_data = new Entity_Data[256];
        int entity_data_count;

        public int EntityCount => entity_data_count - free_entities.Count;
        public int ArchetypeCount => archetypes.Count;

        public static bool TryGetEntity(World world, int entity_index, out Entity entity)
        {
            if (entity_index >= 0 && entity_index < world.entity_data.Length)
                entity = Entity.Create(world, entity_index, world.entity_data[entity_index].version);
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

            foreach (var pool in archetype.pools)
                pool.AddComponents(1);
            archetype.entity_pool.Values[archetype.Count - 1] = entity;
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
                pool.AddComponents(entities.Length);

            for (int i = 0; i < entities.Length; ++i)
                archetype.entity_pool.Values[i + offset] = entities[i];
            return entities;
        }

        /// <summary>
        /// Destroys Entity, any components implementing IDisposable will have it called.
        /// Entity is invalid before the call to Dispose()
        /// </summary>
        public static void DestroyEntity(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];
                world.free_entities.Push(entity.index);
                data.version++;

                world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index]
                                .component_index = data.component_index;

                foreach (var pool in data.archetype.pools)
                    pool.RemoveComponent(data.component_index);

            }
        }

        public static List<object> GetAllComponents(Entity entity)
        {
            var components = new List<object>();
            if (IsValid(entity))
            {
                var data = entity.world.entity_data[entity.index];

                foreach (var pool in data.archetype.pools)
                {
                    var obj = pool.GetComponent(data.component_index);
                    if (obj is Entity) continue;
                    components.Add(obj);
                }
                return components;
            }
            return components;
        }

        /// <summary>
        /// Gets a reference to component on entity. Automatically adds component to entity if none found
        /// </summary>
        public static ref T Get<T>(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];
                {
                    if (data.archetype.TryGetPool<T>(out var pool))
                        return ref pool.Values[data.component_index];
                }
                {
                    var target_arch = GetArchetype(world, data.archetype.signature.Copy().Add<T>()); // get target archetype
                    var target_index = target_arch.Count;
                    // this gnarly line simply updates the soon-to-be swapped entity with it's new component index
                    world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index].component_index = data.component_index;

                    foreach (var pool in data.archetype.pools)
                        pool.MoveComponent(data.component_index, target_arch);

                    data.component_index = target_index;
                    data.archetype = target_arch;

                    if (target_arch.TryGetPool<T>(out var poolT))
                    {
                        poolT.AddComponents(1);
                        return ref poolT.Values[target_index];
                    }
                    else
                        throw new Exception($"Tried adding component to the wrong archetype {typeof(T)} {target_arch}");
                }
            }
            throw new Exception($"{entity} has been destroyed or is not valid, cannot get component");
        }

        public static Entity Set<T>(Entity entity, T component)
        {
            if (component is Entity) throw new Exception("Cannot set Entity as a Component");
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

        public static bool IsValid(Entity entity)
            => entity.world != null &&
                entity.index >= 0 &&
                entity.index < entity.world.entity_data.Length &&
                entity.version == entity.world.entity_data[entity.index].version;

        public static Entity Remove<T>(Entity entity)
        {
            if (IsValid(entity))
            {
                var world = entity.world;
                ref var data = ref world.entity_data[entity.index];
                if (data.archetype.Has<T>())
                {
                    var target_arch = GetArchetype(entity.world, data.archetype.signature.Copy().Remove<T>()); // get target archetype
                    var target_index = target_arch.Count;

                    world.entity_data[data.archetype.entity_pool.Values[data.archetype.Count - 1].index].component_index = data.component_index;
                    foreach (var pool in data.archetype.pools)
                        pool.MoveComponent(data.component_index, target_arch);

                    data.component_index = target_index;
                    data.archetype = target_arch;
                }
            }
            return entity;
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

                foreach (var pool in data.archetype.pools)
                    pool.MoveComponent(data.component_index, world_archetype);

                world_data.archetype.entity_pool.Values[world_data.component_index] = world_entity; // updating the entity value in entity pool of archetype
                entity.world.free_entities.Push(entity.index);   // delete entity from this world
                data.version++;
                return world_entity;
            }

            if (world == null) throw new Exception($"Cannot move {entity} to NULL world");
            throw new Exception($"{entity} has been destroyed or is invalid, cannot move to {world}");
        }
        public static Archetype GetArchetype(Entity entity)
        {
            if (IsValid(entity))
                return entity.world.entity_data[entity.index].archetype;
            throw new Exception($"{entity} is invalid. Cannot retrieve archetype");
        }

        public static Archetype GetArchetype(World world, Type_Signature signature)
        {
            if (!world.id_to_archetype.TryGetValue(signature.ID, out var archetype))
            {
                world.id_to_archetype[signature.ID] = archetype = new Archetype(world, signature);
                world.archetypes.Add(archetype);
            }
            else
            {
                if (archetype.signature != signature)   //expensive but just in case
                    throw new Exception($"Archetype Hash Collision : {signature} <--> {archetype.signature}");
            }
            return archetype;
        }

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
            => $"World {ID} [{archetypes.Count}a {EntityCount}e]";

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
            readonly int ID;
            public readonly World world;
            public Type_Signature signature;
            public override int GetHashCode() => ID;

            public int Count => entity_pool.Count;
            public Pool<Entity> entity_pool;

            public Archetype(World world, Type_Signature signature)
            {
                this.world = world;
                this.signature = signature;
                List<IPool> temp = new List<IPool>();
                foreach (var type in signature)
                {
                    IPool pool = Activator.CreateInstance(typeof(Pool<>).MakeGenericType(type)) as IPool;
                    components.Add(TypeID.Get(type), pool);
                    temp.Add(pool);
                }

                pools = temp.ToArray();
                ID = signature.GetHashCode();

                if (!TryGetPool(out entity_pool))
                    throw new Exception("Archetypes cannot be created without an entity component");
            }

            Dictionary<int, IPool> components = new Dictionary<int, IPool>();
            public IPool[] pools;

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
                //void AddComponent(object obj);

                void AddComponents(int count);

                void MoveComponent(int index, Archetype to_archetype);

                void RemoveComponent(int index);

                void SetComponent(int index, object obj);

                object GetComponent(int index);

                void Resize();

                int Count { get; }
            }

            public class Pool<T> : IPool
            {
                static bool isDispsable = typeof(IDisposable).IsAssignableFrom(typeof(T));

                public T[] Values = new T[8];
                public int Count => count;
                int count;
                public void AddComponents(int new_components)
                {
                    count += new_components;
                    if (count > Values.Length)
                    {
                        int newSize = Values.Length;
                        while (newSize < count)
                            newSize *= 2;
                        if (newSize > Values.Length)
                            Array.Resize(ref Values, newSize);
                    }
                }

                public void AddComponent(T obj)
                {
                    if (count == Values.Length)
                        Array.Resize(ref Values, count * 2);
                    Values[count] = (T)obj;
                    count++;
                }

                public void MoveComponent(int index, Archetype to_archetype)
                {
                    var component = Values[index];
                    count--;
                    Values[index] = Values[count];
                    Values[count] = default;
                    if (to_archetype.TryGetPool(out Pool<T> pool))
                        pool.AddComponent(component);
                }

                public void RemoveComponent(int index)
                {
                    count--;
                    var component = Values[index];
                    Values[index] = Values[count];
                    Values[count] = default;
                    if (isDispsable)
                        (component as IDisposable).Dispose();
                }

                public void SetComponent(int index, object obj)
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

                public object GetComponent(int index)
                    => Values[index];
            }
        }

        public class Type_Signature : IEnumerable<Type>, IEquatable<Type_Signature>
        {
            public Type_Signature(int capacity)
            {
                this.ids = new int[capacity];
                this.types = new Type[capacity];
            }

            public Type_Signature(List<Type> types)
            {
                this.ids = new int[types.Count];
                this.types = new Type[types.Count];
                foreach (var type in types)
                    Add(type);
            }

            public Type_Signature(params Type[] types)
            {
                this.ids = new int[types.Length];
                this.types = new Type[types.Length];
                foreach (var type in types)
                    Add(type);
            }

            public void Clear()
            {
                Count = 0;
            }

            public int[] ids;
            public Type[] types;
            public int Count;
            public int ID => GetHashCode();

            Type_Signature Add(int type_id, Type type)
            {
                if (type == null)
                    return this;
                sig = null;

                for (int i = 0; i < Count; ++i)
                {
                    if (ids[i] == type_id) // if same exit
                        return this;

                    if (type_id > ids[i])
                    {
                        var stored_id = ids[i];
                        var stored_type = types[i];
                        ids[i] = type_id;
                        types[i] = type;
                        type_id = stored_id;
                        type = stored_type;
                    }
                }

                if (Count++ == types.Length)
                {
                    Array.Resize(ref types, Count + 4);
                    Array.Resize(ref ids, Count + 4);
                }

                ids[Count - 1] = type_id;
                types[Count - 1] = type;
                return this;
            }

            Type_Signature Remove(Type type, int type_id)
            {
                sig = null;
                bool swap = ids[0] == type_id;
                for (int i = 1; i < Count; ++i)
                {
                    if (swap)
                    {
                        ids[i - 1] = ids[i];
                        types[i - 1] = types[i];
                    }
                    else
                        swap = ids[i] == type_id;
                }
                if (swap)
                {
                    Count--;
                }
                return this;
            }

            public Type_Signature Add(Type type)
                => Add(TypeID.Get(type), type);

            public Type_Signature Add<T>()
                => Add(TypeID.GetID<T>.Value, typeof(T));

            public Type_Signature Remove(Type type)
                => Remove(type, TypeID.Get(type));

            public Type_Signature Remove<T>()
                => Remove(typeof(T), TypeID.GetID<T>.Value);

            public bool Has<T>() => Has(TypeID.GetID<T>.Value);

            public bool Has(Type type) => Has(TypeID.Get(type));

            public bool Has(int typeid)
            {
                for (int i = 0; i < Count; ++i)
                    if (ids[i] == typeid)
                        return true;
                return false;
            }

            public Type_Signature Copy()
            {
                var signature = new Type_Signature(Count + 1);
                signature.Count = Count;
                for (int i = 0; i < Count; ++i)
                {
                    signature.ids[i] = this.ids[i];
                    signature.types[i] = this.types[i];
                }
                return signature;
            }

            IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
            {
                for (int i = 0; i < Count; ++i)
                {
                    yield return types[i];
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                foreach (var type in this)
                    yield return type;
            }

            public override int GetHashCode()
            {
                int p = 53;
                int power = 1;
                int hashval = 0;

                unchecked
                {
                    for (int i = 0; i < Count; ++i)
                    {
                        power *= p;
                        hashval = (hashval + ids[i] * power);
                    }
                }
                return hashval;
            }

            public bool Equals(Type_Signature other)
            {
                if (Count != other.Count)
                    return false;
                for (int i = 0; i < Count; ++i)
                {
                    if (ids[i] != other.ids[i])
                        return false;
                }
                return true;
            }

            public override bool Equals(object obj)
            {
                if (obj is Type_Signature sig)
                    return sig.Equals(this);
                return false;
            }

            string sig;
            public override string ToString()
            {
                if (sig == null)
                {
                    int count = 0;
                    foreach (Type type in this)
                    {
                        sig += $"{type.Name} ";
                        count++;
                        if (count > 4)
                        {
                            sig += $"...+{Count - 4} more";
                            return sig;
                        }
                    }
                }
                return sig;
            }

            public static bool operator ==(Type_Signature a, Type_Signature b)
            => a.Equals(b);

            public static bool operator !=(Type_Signature a, Type_Signature b)
            => !a.Equals(b);
        }
    }

    public class Blueprint
    {
        public Blueprint() { }

        /// <summary>
        /// World the entites are created in
        /// </summary>
        public Blueprint(World world)
        {
            this.world = world;
        }

        World _world = World.Default;
        public World world
        {
            get => _world;
            set
            {
                archetype = null;
                _world = value;
            }
        }
        World.Type_Signature signature = new World.Type_Signature(typeof(Entity));
        World.Archetype archetype;
        Action<Entity> set_components = delegate { };
        Action<Entity> on_complete = delegate { };

        public Blueprint Set<Component>()
        {
            if (typeof(Component) == typeof(Entity))
                throw new Exception("Cannot Set Entity as a Component");

            signature.Add<Component>();
            archetype = null;
            return this;
        }

        public Blueprint Set<Component>(Func<Component> component_creation_function)
        {
            if (typeof(Component) == typeof(Entity))
                throw new Exception("Cannot Set Entity as a Component");

            signature.Add<Component>();
            set_components += entity => entity.Get<Component>() = component_creation_function();
            archetype = null;
            return this;
        }

        public Blueprint Set<Component>(Func<Entity, Component> component_creation_function)
        {
            if (typeof(Component) == typeof(Entity))
                throw new Exception("Cannot Set Entity as a Component");

            signature.Add<Component>();
            set_components += entity => entity.Get<Component>() = component_creation_function(entity);
            archetype = null;
            return this;
        }

        /// <summary>
        /// Action to perform after all components are set
        /// </summary>
        public Blueprint OnComplete(Action<Entity> onComplete)
        {
            this.on_complete = onComplete;
            return this;
        }

        World.Archetype GetArchetype()
        {
            if (archetype == null)
                archetype = World.GetArchetype(world, signature);
            return archetype;
        }

        public Entity CreateEntity()
        {
            var entity = World.CreateEntity(GetArchetype());
            set_components(entity);
            on_complete(entity);
            return entity;
        }

        public Entity[] CreateEntities(int count)
        {
            var entities = World.CreateEntities(GetArchetype(), count);
            foreach (var entity in entities)
            {
                set_components(entity);
                on_complete(entity);
            }
            return entities;
        }

        public override string ToString()
            => $"Blueprint [W{world?.ID}: {signature}]";

    }

    public class Query : IEnumerable<World.Archetype>
    {
        public Query()
        {
            _world = World.Default;
        }

        /// <summary>
        /// Specify which wolrd the query should operate on
        /// </summary>
        public Query(World world)
        {
            _world = world;
        }
        World.Type_Signature has = new World.Type_Signature();
        World.Type_Signature not = new World.Type_Signature();


        World.Archetype[] matching_archetypes = new World.Archetype[8];
        int archetype_count;

        int last_world_count;

        World _world = World.Default;

        /// <summary>
        /// Current world the query operates on
        /// </summary>
        public World world
        {
            get => _world;
            set
            {
                archetype_count = 0;
                last_world_count = 0;
                _world = value;
            }
        }

        public int Matching_Archetypes => archetype_count;

        public int Matching_Entities
        {
            get
            {
                UpdateQuery();
                int number = 0;
                for (int i = 0; i < archetype_count; ++i)
                    number += matching_archetypes[i].Count;
                return number;
            }
        }

        /// <summary>
        /// Filters entities to those that have component
        /// </summary>
        public Query Has<T>()
        {
            has.Add<T>();
            last_world_count = 0;
            archetype_count = 0;
            name = null;
            return this;
        }

        /// <summary>
        /// Filters entities to those without component
        /// </summary>
        public Query Not<T>()
        {
            not.Add<T>();
            last_world_count = 0;
            archetype_count = 0;
            name = null;
            return this;
        }

        public Query Clear()
        {
            has.Clear();
            not.Clear();
            last_world_count = 0;
            archetype_count = 0;
            name = null;
            return this;
        }

        string name;
        public override string ToString()
        {
            if (name == null)
            {
                name = "Query ";
                if (has.Count > 0)
                {
                    name += "[HAS: ";

                    foreach (var type in has)
                        name += type.Name;
                    name += "] ";
                }
                if (not.Count > 0)
                {
                    name += "[NOT: ";
                    foreach (var type in not)
                        name += type.Name;
                    name += "]";
                }
            }

            return $"{name} [W{world.ID}: {archetype_count}a {Matching_Entities}e]";
        }

        public delegate void query<C1>(ref C1 c1);
        public delegate void query<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void query<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);

        void UpdateQuery() // checks for any new archetypes since last run and updates accordingly
        {
            if (last_world_count != _world.Archetypes.Count)
            {
                for (int i = last_world_count; i < _world.Archetypes.Count; ++i)
                {
                    var archetype = _world.Archetypes[i];
                    {
                        for (int itr = 0; itr < has.Count; ++itr)
                        {
                            var type = has.ids[itr];
                            if (!archetype.signature.Has(type))
                                goto next_archetype;
                        }
                    }
                    {
                        for (int itr = 0; itr < not.Count; ++itr)
                        {
                            var type = not.ids[itr];
                            if (archetype.signature.Has(type))
                                goto next_archetype;
                        }
                    }

                    if (archetype_count == matching_archetypes.Length)
                        Array.Resize(ref matching_archetypes, matching_archetypes.Length * 2);
                    matching_archetypes[archetype_count] = archetype;
                    archetype_count++;

                next_archetype:
                    continue;
                }
                last_world_count = _world.Archetypes.Count;
            }
        }

        /// <summary>
        /// performs action on all entities matching query and including components in action
        /// </summary>
        public void Foreach<C1>(query<C1> action)
        {
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)  // go backwards so new archetypes aren't updating
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1))  // skips archetype if not all components in action are contained in archetype
                {
                    for (int itr = archetype.Count - 1; itr >= 0; --itr) // go backwards so entity operations can be performed synchonously
                        action(ref pool_c1.Values[itr]);
                }
            }
        }

        public void Foreach<C1, C2>(query<C1, C2> action)
        {
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;

                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
            UpdateQuery();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.Count == 0) continue;
                
                if (archetype.TryGetPool<C1>(out var pool_c1) &&
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
    }
}
