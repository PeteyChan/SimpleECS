namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Stores all entities and their components that match it's signature.
    /// Entities and components are stored in contiguous arrays for fast iterations.
    /// Can iterate over entities and thier components just like with queries using Foreach()
    /// </summary>
    public partial class Archetype : IReadOnlyList<Entity>  // think I may change this to a struct in the future
    {
        int ID;
        internal TypeSignature signature;
        internal Entity[] entity_pool = new Entity[8];
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

        internal Archetype(TypeSignature signature)
        {
            this.signature = new TypeSignature(signature);
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
        }

        internal void AddEntity(Entity entity)   // returns component id
        {
            if (entity_pool.Length == entity_count)
            {
                int capacity = entity_pool.Length * 2;
                Array.Resize(ref entity_pool, capacity);
                for (int i = 0; i < component_count; ++i)
                    data_map[i].pool.Resize(capacity);
            }
            entity_pool[entity_count] = entity;
            entity_count++;
        }

        internal void MoveEntity(int component_index, Archetype archetype, int target_index)
        {
            archetype.AddEntity(entity_pool[component_index]);
            entity_pool[component_index] = entity_pool[entity_count - 1];

            for (int i = 0; i < component_count; ++i)
            {
                data_map[i].pool.Move(component_index, archetype, target_index);
                data_map[i].pool.Remove(component_index, entity_count);
            }
            entity_count--;
        }

        internal void DestroyEntity(int component_index)
        {
            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Remove(component_index, entity_count);

            var entity = entity_pool[component_index];
            entity_pool[component_index] = entity_pool[--entity_count];

            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.remove_callback?.Invoke(entity);
        }

        internal void GetAllComponents(int component_index, List<object> components)
        {
            for(int i = 0;i < component_count; ++ i)
                components.Add(data_map[i].pool.Get(component_index));
        }

        Pool CreatePool(Type type)
        {
            return Activator.CreateInstance(typeof(Pool<>).MakeGenericType(type)) as Pool;
        }

        /// <summary>
        /// Tries to retrieve the component array of the stored entities.
        /// Returns false if stored entities don't have the component type.
        /// The amount of components is equal to this archetype's Entities.Count NOT the length of the component array.
        /// </summary>
        public bool TryGetArray<Component>(out Component[] components)
        {
            int type_id = TypeID<Component>.Value;
            var data = data_map[type_id % data_map.Length];
            if (data.ID == type_id)
            {
                components = (Component[])data.pool.array;
                return true;
            }
            while (data.next >= 0)
            {
                data = data_map[data.next];
                if (data.ID == type_id)
                {
                    components = (Component[])data.pool.array;
                    return true;
                }
            }
            components = default;
            return false;
        }

        internal bool TryGetPool<T>(out Pool<T> pool)
        {
            int type_id = TypeID<T>.Value;
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

        /// <summary>
        /// Returns true if archetype's signature contains component type
        /// </summary>
        public bool Has<Component>()
        {
            var type_id = TypeID<Component>.Value;
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
        /// Returns true if archetype's signature contains component type
        /// </summary>
        public bool Has(Type type)
        {
            var type_id = TypeID.Get(type);
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
        public void ResizeBackingArrays()
        {
            int length = 8;
            while (length < entity_count)
                length *= 2;
            if (length == entity_pool.Length)
                return;
            Array.Resize(ref entity_pool, length);
            for (int i = 0; i < component_count; ++i)
                data_map[i].pool.Resize(length);
        }

        #pragma warning disable

        public override int GetHashCode() => ID;

        internal void Destroy()
        {
            data_map = default;
            signature = default;
            entity_pool = default;
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
            => archetype?.entity_pool == null ? false : true;

        // pool readonly interface
        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            for (int i = 0; i < entity_count; ++i)
                yield return entity_pool[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < component_count; ++i)
                yield return data_map[i].pool;
        }

        int IReadOnlyCollection<Entity>.Count => entity_count;

        Entity IReadOnlyList<Entity>.this[int index] => entity_pool[index];

        internal abstract class Pool
        {
            internal delegate void set_by_object(in Entity entity, int index, in object obj);
            internal delegate void set_by_value<T>(in Entity entity, int index, in T obj);

            internal abstract void Remove(int index, int entity_count);

            internal set_by_object SetObject;

            internal abstract object Get(int index);

            internal abstract void Resize(int capcity);

            internal abstract void Move(int index, Archetype archetype, int new_index);

            internal object array;

            internal Action<Entity> remove_callback;
        }

        internal sealed class Pool<T> : Pool
        {
            public Pool()
            {
                array = Values;
                SetValue = (in Entity e, int index, in T obj) =>
                {
                    Values[index] = obj;
                    SimpleECS.OnSet<T>.Callback?.Invoke(e, ref Values[index]);
                };
                SetObject = (in Entity e, int index, in object obj) =>
                {
                    Values[index] = (T)obj;
                    SimpleECS.OnSet<T>.Callback?.Invoke(e, ref Values[index]);
                };
                remove_callback = e => OnRemove<T>.Callback?.Invoke(e, ref removed);
            }

            T removed;

            public T[] Values = new T[8];

            internal override object Get(int index) => Values[index];

            internal override void Remove(int index, int entity_count)
            {
                removed = Values[index];
                Values[index] = Values[entity_count - 1];
                Values[entity_count - 1] = default;
            }

            internal set_by_value<T> SetValue;

            internal override void Resize(int capacity)
            {
                Array.Resize(ref Values, capacity);
                array = Values;
            }

            internal override void Move(int index, Archetype archetype, int target_index)
            {
                if (archetype.TryGetArray<T>(out var pool))
                    pool[target_index] = Values[index];
            }
        }
    }
}