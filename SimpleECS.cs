using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// A very simple ECS Implementation
/// </summary>
namespace SimpleECS
{
    public class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// returns all entities with atleast one component
        /// </summary>
        public static IReadOnlyList<Entity> All => AllEntities;
        readonly static ECSCollection<Entity> AllEntities = new ECSCollection<Entity>();

        /// <summary>
        /// returns all entities with component
        /// fastest way to iterate entities with component
        /// </summary>
        public static IReadOnlyList<Entity> AllWith<T>() => Components<T>.entities;

        /// <summary>
        /// returns all components of type assigned to entities
        /// fastest way to iterate all components
        /// </summary>
        public static IReadOnlyList<T> AllComponents<T>() => Components<T>.components;

        /// <summary>
        /// returns a list of all types that have been used as a 
        /// component atleast once during the life time of the program
        /// </summary>
        public static IReadOnlyList<Type> AllComponentTypes => Components.ComponentTypes;

        /// <summary>
        /// returns all entities with component type
        /// </summary>
        public static IReadOnlyList<Entity> GetEntitiesWithType(Type type)
            => Components.entity_pools[Components.GetTypeID(type)];

        /// <summary>
        /// After removing large amounts of components, you can use this
        /// to resize backing arrays and reclaim memory
        /// </summary>
        public static void ResizeBackingArrays()
        {
            Components.ResizeBackingArrays();
            GC.Collect();
        }

        int index;
        static int new_id;

        /// <summary>
        /// Unique Entity Identifier
        /// </summary>
        public readonly int ID = new_id++;

        ECSMap component_lookup = new ECSMap();
        int component_count = 0;

        public Entity() { }

        /// <summary>
        /// Components supplied are set by their type
        /// </summary>
        public Entity(params object[] components)
        {
            SetByType(components);
        }

        /// <summary>
        /// Sets/Adds the component to entity as is
        /// </summary>
        public Entity Set<T>(T component)
        {
            Components<T>.Set(this, component);
            return this;
        }

        public Entity Set<T1, T2>(T1 t1, T2 t2)
            => Set(t1).Set<T2>(t2);

        public Entity Set<T1, T2, T3>(T1 t1, T2 t2, T3 t3)
            => Set(t1).Set(t2).Set(t3);

        public Entity Set<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4)
            => Set(t1).Set(t2).Set(t3).Set(t4);

        /// <summary>
        /// Sets/Adds components to entity by their type
        /// </summary>
        public Entity SetByType(params object[] components)
        {
            foreach (var component in components)
            {
                var id = Components.GetTypeID(component.GetType());
                Components.component_pools[id].SetComponent(this, component);
            }
            return this;
        }

        /// <summary>
        /// Removes component from entity
        /// </summary>
        public Entity Remove<T>()
        {
            Components<T>.Remove(this);
            return this;
        }

        public Entity Remove<T1, T2>()
            => Remove<T1>().Remove<T2>();

        public Entity Remove<T1, T2, T3>()
            => Remove<T1>().Remove<T2>().Remove<T3>();

        public Entity Remove<T1, T2, T3, T4>()
            => Remove<T1>().Remove<T2>().Remove<T3>().Remove<T4>();

        /// <summary>
        /// Returns true if entity has component
        /// </summary>
        public bool Has<T>()
            => component_lookup[Components<T>.ID] >= 0;

        public bool Has<T1, T2>()
            => Has<T1>() && Has<T2>();

        public bool Has<T1, T2, T3>()
            => Has<T1>() && Has<T2>() && Has<T3>();

        public bool Has<T1, T2, T3, T4>()
            => Has<T1>() && Has<T2>() && Has<T3>() && Has<T4>();

        /// <summary>
        /// returns true if entity doesn't have component
        /// </summary>
        public bool Not<T>()
            => component_lookup[Components<T>.ID] < 0;

        public bool Not<T1, T2>()
            => Not<T1>() && Not<T2>();

        public bool Not<T1, T2, T3>()
            => Not<T1>() && Not<T2>() && Not<T3>();

        public bool Not<T1, T2, T3, T4>()
            => Not<T1>() && Not<T2>() && Not<T3>() && Not<T4>();

        /// <summary>
        /// returns true if component was sucessfully retrived from entity
        /// </summary>
        public bool TryGet<T>(out T value)
        {
            var index = component_lookup[Components<T>.ID];
            if (index >= 0)
            {
                value = Components<T>.components[index];
                return true;
            }
            value = default;
            return false;
        }

        public bool TryGet<T1, T2>(out T1 t1, out T2 t2)
            => TryGet(out t1) & TryGet(out t2);

        public bool TryGet<T1, T2, T3>(out T1 t1, out T2 t2, out T3 t3)
            => TryGet(out t1) & TryGet(out t2) & TryGet(out t3);

        public bool TryGet<T1, T2, T3, T4>(out T1 t1, out T2 t2, out T3 t3, out T4 t4)
            => TryGet(out t1) & TryGet(out t2) & TryGet(out t3) & TryGet(out t4);

        /// <summary>
        /// Returns all components associated with entity
        /// </summary>
        public List<object> GetAllComponents()
        {
            var list = new List<object>();
            foreach (var item in component_lookup.map)
            {
                if (item.index > 0)
                {
                    list.Add(Components.component_pools[item.index - 1].GetComponent(item.value));
                }
            }
            return list;
        }

        /// <summary>
        /// Removes all components associated with entity
        /// </summary>
        public Entity RemoveAll()
        {
            foreach (var item in component_lookup.map)
            {
                if (item.index > 0)
                {
                    Components.component_pools[item.index - 1].RemoveComponent(this);
                }
            }
            return this;
        }

        public override int GetHashCode()
        => ID;

        bool IEquatable<Entity>.Equals(Entity other) => ID == other.ID;

        public override string ToString()
        => $"Entity {ID}";

        abstract class Components
        {
            public readonly static Dictionary<Type, int> IDlookups = new Dictionary<Type, int>();

            public static int GetTypeID(Type type)
            {
                if (!IDlookups.TryGetValue(type, out var value))
                {
                    ComponentTypes.Add(type);
                    IDlookups[type] = value = IDlookups.Count;
                    if (value == component_pools.Length)
                    {
                        Array.Resize(ref entity_pools, value * 2);
                        Array.Resize(ref component_pools, value * 2);
                    }

                    entity_pools[value] = new ECSCollection<Entity>();                                      
                    var poolType = typeof(Components<>).MakeGenericType(new Type[] { type });
                    component_pools[value] = (Activator.CreateInstance(poolType) as Components);
                }
                return value;
            }
            
            public static ECSCollection<Entity>[] entity_pools = new ECSCollection<Entity>[32];
            public static Components[] component_pools = new Components[32];
            public static Action ResizeBackingArrays = delegate { };
            public static List<Type> ComponentTypes = new List<Type>();

            public abstract object GetComponent(int index);
            public abstract void RemoveComponent(Entity entity);
            public abstract void SetComponent(Entity entity, Object component);
        }



        class Components<T> : Components
        {
            static Components()
            {
                Components.ResizeBackingArrays += () =>
                {
                    entities.Resize();
                    components.Resize();
                };
            }

            public readonly static int ID = Components.GetTypeID(typeof(T));
            public readonly static ECSCollection<Entity> entities = Components.entity_pools[ID];
            public readonly static ECSCollection<T> components = new ECSCollection<T>();

            public static void Set(Entity entity, T component)
            {
                var index = entity.component_lookup[ID];
                if (index >= 0)
                    components[index] = component;
                else
                {
                    index = entities.Add(entity);
                    components.Add(component);
                    entity.component_lookup[ID] = index;
                    entity.component_count++;

                    if (entity.component_count == 1)
                    {
                        entity.index = AllEntities.Add(entity);
                    }
                    Events<T>.OnAdd?.Invoke(entity, component);
                }
            }

            public static void Remove(Entity entity)
            {
                var index = entity.component_lookup[ID];
                if (index >= 0)
                {
                    entities.last.component_lookup[ID] = index;
                    entity.component_lookup.Remove(ID);
                    var component = components.items[index];
                    entities.RemoveAndSwapLast(index);
                    components.RemoveAndSwapLast(index);
                    entity.component_count--;
                    if (entity.component_count == 0)
                    {
                        AllEntities.last.index = entity.index;
                        AllEntities.RemoveAndSwapLast(entity.index);
                    }
                    Events<T>.OnRemove?.Invoke(entity, component);
                }
            }

            public override object GetComponent(int index)
                => components.items[index];

            public override void RemoveComponent(Entity entity)
                => Remove(entity);

            public override void SetComponent(Entity entity, Object component)
                => Set(entity, (T)component);
        }



        /// <summary>
        /// Provides callbacks for when an entity adds or removes a component
        /// </summary>
        public class Events<Component>
        {
            public static Action<Entity, Component> OnAdd;
            public static Action<Entity, Component> OnRemove;
        }



        /// <summary>
        /// Allows easy filtering of entities based on component composition.
        /// Iterate matching entities with foreach on query
        /// Include the most specific case first to improve query times
        /// </summary>
        public class Query : IEnumerable<Entity>
        {
            List<int> include = new List<int>();
            List<int> exclude = new List<int>();
            bool update;
            int[] include_array;
            int[] exclude_array;

            /// <summary>
            /// filters entities to those that have component. 
            /// Iteration times can be improved by including the component
            /// with the least entities first
            /// </summary>
            public Query Include<T>()
            {
                include.Add(Components<T>.ID);
                update = true;
                return this;
            }

            public Query Include<T1, T2>()
            => Include<T1>().Include<T2>();

            public Query Include<T1, T2, T3>()
            => Include<T1>().Include<T2>().Include<T3>();

            public Query Include<T1, T2, T3, T4>()
            => Include<T1>().Include<T2>().Include<T3>().Include<T4>();

            /// <summary>
            /// filters entities to those that do not have component
            /// </summary>
            public Query Exclude<T>()
            {
                exclude.Add(Components<T>.ID);
                update = true;
                return this;
            }

            public Query Exclude<T1, T2>()
                => Exclude<T1>().Exclude<T2>();

            public Query Exclude<T1, T2, T3>()
                => Exclude<T1>().Exclude<T2>().Exclude<T3>();

            public Query Exclude<T1, T2, T3, T4>()
                => Exclude<T1>().Exclude<T2>().Exclude<T3>().Exclude<T4>();

            ECSCollection<Entity> GetEntities()
            {
                if (update)
                {
                    include_array = include.ToArray();
                    exclude_array = exclude.ToArray();
                    update = false;
                }

                if (include_array.Length > 0)   // always iterate shortest entity list
                {
                    var entities = Components.entity_pools[include_array[0]];
                    for(int i= 1; i < include_array.Length; ++ i)
                    {
                        var newpool = Components.entity_pools[include_array[i]];
                        if (newpool.count < entities.count)
                        {
                            entities = newpool;
                            var current = include_array[0];
                            include_array[0] = include_array[i];
                            include_array[i] = current;                 
                        }
                    }
                    return entities;
                }
                return Entity.AllEntities;
            }

            /// <summary>
            /// Clears current filtering
            /// </summary>
            public void Clear()
            {
                include.Clear();
                exclude.Clear();
                update = true;
            }

            /// <summary>
            /// Count of entities this query will test for matches
            /// </summary>
            public int QueryCount => GetEntities().count;

            /// <summary>
            /// iterates over matching entities split across multiple threads
            /// </summary>
            public void ForeachParallel(Action<Entity> action)
            {
                var entities = GetEntities();
                System.Threading.Tasks.Parallel.For(0, entities.count, (int index) =>
                {
                    var entity = entities.items[index];

                    for (int i = 1; i < include_array.Length; ++i)  // 0 is the iterating array so can be skipped
                        if (entity.component_lookup[i] < 0)
                            return;

                    for (int i = 0; i < exclude_array.Length; ++i)
                        if (entity.component_lookup[i] >= 0)
                            return;
                            
                    action(entity);
                });
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return new Iterator(this);
            }

            IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
            {
                return new Iterator(this);
            }

            struct Iterator : IEnumerator<Entity>
            {
                public Iterator(Query query)
                {
                    this.query = query;
                    entities = query.GetEntities();
                    index = entities.count;
                }

                public Query query;
                public ECSCollection<Entity> entities;
                public int index;

                public Entity Current => entities.items[index];

                object IEnumerator.Current => entities.items[index];

                public void Dispose() { }

                public bool MoveNext()  // we iterate backwards so that we can do 
                {                       // structural changes without invalidating iterators
                    while (index > 0)
                    {
                        index--;
                        var e = entities.items[index];

                        for (int i = 1; i < query.include_array.Length; ++i)
                            if (e.component_lookup[i] < 0)
                                goto Next;

                        for (int i = 0; i < query.exclude_array.Length; ++i)
                            if (e.component_lookup[i] >= 0)
                                goto Next;

                        return true;

                    Next:
                        continue;
                    }
                    return false;
                }

                public void Reset()
                {
                    index = entities.count;
                }
            }
        }


        /// <summary>
        /// custom collection with custom enumeration so that 
        /// removal of entities don't invalidate iterators 
        /// </summary>
        class ECSCollection<T> : IReadOnlyList<T>
        {
            public ECSCollection()
            {
                items = new T[8];
            }

            public T[] items;
            public int count = 0;

            public ref T last => ref items[count - 1];
            
            int IReadOnlyCollection<T>.Count => count;

            public void Resize()
            {
                var newSize = 8;
                while (newSize < count)
                    newSize *= 2;
                if (items.Length > newSize)
                    Array.Resize(ref items, newSize);
            }

            public T this[int index]
            {
                get => items[index];
                set => items[index] = value;
            }

            /// <summary>
            /// returns index of added item
            /// </summary>
            public int Add(T item)
            {
                if (count == items.Length)
                    Array.Resize(ref items, count * 2);
                items[count] = item;
                count++;
                return count - 1;
            }

            // swapping with back ensures arrays are packed
            public void RemoveAndSwapLast(int index)
            {
                count--;
                items[index] = items[count];
                items[count] = default;
            }

            T IReadOnlyList<T>.this[int index] => items[index];

            IEnumerator IEnumerable.GetEnumerator()
            => new Iterator(this);

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            => new Iterator(this);

            struct Iterator : IEnumerator<T>
            {
                public Iterator(ECSCollection<T> list)
                {
                    this.list = list;
                    position = list.count;
                }
                ECSCollection<T> list;
                int position;

                T IEnumerator<T>.Current => list.items[position];

                object IEnumerator.Current => list.items[position];

                void IDisposable.Dispose() { }

                // iterating backwards means we can remove components without invalidating iterators
                bool IEnumerator.MoveNext()
                {
                    position--;
                    return position >= 0;
                }

                void IEnumerator.Reset()
                {
                    position = list.count;
                }
            }
        }

        //simple openset hashmap for faster lookups than a normal dictionary
        class ECSMap
        {
            public (int index, int value)[] map =  new (int index, int value)[map_data[0].prime + map_data[0].steps];
            int factor = map_data[0].prime;
            int steps = map_data[0].steps;
            int current_data = 0;

            void Resize()
            {
                current_data++;
                factor = map_data[current_data].prime;
                steps = map_data[current_data].steps;

                var data = map_data[current_data];
                (int index, int value)[] newMap = new (int, int)[factor + steps];

                for (int index = 0; index < map.Length; ++index)
                {
                    var item = map[index];
                    if (item.index == 0)
                        continue;

                    var pos = item.index % factor;

                    for (int i = 0; i < steps; ++i)
                    {
                        if (newMap[pos + i].index == 0)
                        {
                            newMap[pos + i] = item;
                            break;
                        }
                    }
                }
                map = newMap;
            }

            public void Remove(int index)
            {
                index++;
                var pos = index % factor;
                int next = 0;
                int gap = 0;

                while (next < steps)
                {
                    var data = map[pos + next];
                    if (index == data.index)
                    {
                        gap = pos + next;
                        map[gap] = default;
                        next++;
                        break;
                    }
                    next++;
                }

                while (next < steps)
                {
                    var data = map[pos + next];
                    if (data.index % factor == pos)
                    {
                        map[gap] = data;
                        gap = pos + next;
                        map[gap] = default;
                    }
                    next++;
                }
            }

            public int this[int index]
            {
                get
                {
                    index += 1;
                    var pos = index % factor;
                    for (int i = 0; i < steps; ++i)
                    {
                        var data = map[pos + i];
                        if (index == data.index)
                            return data.value;
                        if (index == 0)
                            return -1;
                    }
                    return -1;
                }

                set
                {
                    index += 1;
                    var pos = index % factor;

                    for (int i = 0; i < steps; ++i)
                    {
                        var data = map[pos + i];
                        if (data.index == 0 || data.index == index)
                        {
                            map[pos + i] = (index, value);
                            return;
                        }
                    }

                    Resize();

                    pos = index % factor;

                    for (int i = 0; i < steps; ++i)
                    {
                        var data = map[pos + i];
                        if (data.index == 0 || data.index == index)
                        {
                            map[pos + i] = (index, value);
                            return;
                        }
                    }
                }
            }

            static (int prime, int steps)[] map_data = new (int, int)[]
            {
                (7, 3),
                (13, 4),
                (31, 5),
                (53, 6),
                (97, 7),
                (193, 8),   
                (389, 9),
                (769, 10),
                (1543, 11),
                (3079, 12),
                (6151, 13),
                (12289, 14)
            };
        }
    }
}