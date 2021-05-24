namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Stores all entities and their components that match it's signature.
    /// Can iterate over entities and thier components just like with queries using Foreach()
    /// </summary>
    public partial class Archetype : IReadOnlyList<Entity>
    {
        int ID;
        internal TypeSignature signature;
        internal readonly Pool<Entity> entity_pool;
        internal int entity_count;
        Data[] data_map;
        readonly int component_count;

        /// <summary>
        /// Entities currently stored in this archetype
        /// </summary>
        public IReadOnlyList<Entity> Entities => this;
        
        /// <summary>
        /// Archetype's current type signature
        /// </summary>
        public IReadOnlyList<Type> TypeSignature => signature;

        public override int GetHashCode() => ID;
        internal Archetype(TypeSignature signature)
        {
            this.signature = new TypeSignature(signature);
            this.entity_pool = new Pool<Entity>();
            ID = signature.GetHashCode();

            Stack<(int id, System.Type type)> to_allocate = new Stack<(int, System.Type)>();
            data_map = new Data[signature.type_count == 0 ? 1 : signature.type_count];
            component_count = signature.type_count;

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

        internal void AddEntity(Entity entity)   // returns component id
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
                RemoveCallbackPools[i].callback?.OnRemoveBy(entity_pool.Values[component_index]);
                RemoveCallbackPools[i].callback = default;
            }
            entity_pool.Remove(component_index, entity_count);
            entity_count--;
        }

        internal void GetAllComponents(int component_index, List<object> components)
        {
            foreach (var data in data_map)
                components.Add(data.pool.Get(component_index));
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

        /// <summary>
        /// Gets the component pool associated with the entities in this archetype.
        /// Returns false if archetype does not have the component pool.
        /// </summary>
        public bool TryGetPool<Component>(out Pool<Component> pool)
        {
            int type_id = TypeID.GetID<Component>.Value;
            var data = data_map[type_id % data_map.Length];
            if (data.ID == type_id)
            {
                pool = (Pool<Component>)data.pool;
                return true;
            }
            while (data.next >= 0)
            {
                data = data_map[data.next];
                if (data.ID == type_id)
                {
                    pool = (Pool<Component>)data.pool;
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

        /// <summary>
        /// Returns true if archetype's signature contains component type
        /// </summary>
        public bool Has<Component>()
        {
            var type_id = TypeID.GetID<Component>.Value;
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

            entity_pool.Resize(length);
            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Resize(length);
        }

        internal struct Data
        {
            public int next;
            public int ID;
            public Pool pool;
        }

        public override string ToString()
            => $"Archetype [{signature}]";

        public static implicit operator bool(Archetype archetype)
            => archetype == null ? false : true;

        // pool readonly interface
        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            for (int i = 0; i < entity_count; ++i)
                yield return entity_pool.Values[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        int IReadOnlyCollection<Entity>.Count => entity_count;

        Entity IReadOnlyList<Entity>.this[int index] => entity_pool.Values[index];

        public abstract class Pool
        {
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
                Values[index]?.OnSetBy(entity);
            }

            internal override void Set(in Entity entity, int index, in T obj)
            {
                Values[index] = (T)obj;
                Values[index]?.OnSetBy(entity);
            }
        }

        public class Pool<T> : Pool
        {
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
    }
}