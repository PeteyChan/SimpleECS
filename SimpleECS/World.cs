namespace SimpleECS
{
    using System;
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// manages all entities and archetype information
    /// </summary>
    public partial struct World : IEquatable<World>
    {
        World(int index, int version)
        {
            this.index = index; this.version = version;
        }

        /// <summary>
        /// the index and version together create a unique identifier for the world
        /// </summary>
        public readonly int index;

        /// <summary>
        /// the index and version together create a unique identifier for the world
        /// </summary>
        public readonly int version;

        /// <summary>
        /// Name of the world
        /// </summary>
        public string Name
        {
            get => this.TryGetWorldInfo(out var info) ? info.name : "~World";
            set
            {
                if (this.TryGetWorldInfo(out var info))
                    info.name = value;
            }
        }

        /// <summary>
        /// Returns a copy of all the archetypes in the current world
        /// </summary>
        public Archetype[] GetArchetypes()
        {
            Archetype[] archetypes;
            if (this.TryGetWorldInfo(out var info))
            {
                archetypes = new Archetype[info.archetype_count];
                int count = 0;
                foreach (var arch in info.archetypes)
                    if (arch.data != null)
                    {
                        archetypes[count] = arch.data.archetype;
                        count++;
                    }
            }
            else
                archetypes = new Archetype[0];
            return archetypes;
        }

        /// <summary>
        /// Returns a copy of all the entities in the the current world
        /// </summary>
        public Entity[] GetEntities()
        {
            Entity[] entities;
            if (this.TryGetWorldInfo(out var info))
            {
                entities = new Entity[EntityCount];
                int count = 0;
                foreach (var archetype in info.archetypes)
                {
                    if (archetype.data != null)
                        for (int e = 0; e < archetype.data.entity_count; ++e)
                        {
                            entities[count] = archetype.data.entities[e];
                            count++;
                        }
                }
            }
            else entities = new Entity[0];
            return entities;
        }

        public static World Create() => Create("World");

        /// <summary>
        /// Creates an new world with Name
        /// </summary>
        public static World Create(string Name)
        {
            var index = -1;
            for (int i = 0; i < World_Info.All.Length; ++i)
            {
                if (World_Info.All[i].data == null)
                {
                    index = i;
                    break;
                }
            }
            if (index < 0)
            {
                index = World_Info.All.Length;
                System.Array.Resize(ref World_Info.All, index + 4);
            }

            ref var world_data = ref World_Info.All[index];
            var version = world_data.version;
            world_data.data = new World_Info(Name, new World(index, version));
            World_Info.world_count++;
            return world_data.data.world;
        }

        /// <summary>
        /// Returns true if the world is not null or destroyed
        /// </summary>
        public bool IsValid() => World_Info.All[index].version == version;

        /// <summary>
        /// Destroys the world along with all it's archetypes and entities
        /// </summary>
        public void Destroy()
        {
            if (this.TryGetWorldInfo(out var info))
                info.StructureEvents.DestroyWorld();
        }

        /// <summary>
        /// Creates an entity in this world
        /// </summary>
        public Entity CreateEntity()
        {
            if (this.TryGetWorldInfo(out var info))
                return info.StructureEvents.CreateEntity(info.GetArchetypeData(info.buffer_signature.Clear()));
            return default;
        }

        /// <summary>
        /// Returns how many entities are currently in this world
        /// </summary>
        public int EntityCount => this.TryGetWorldInfo(out var info) ? info.entity_count : 0;

        /// <summary>
        /// Creates a query that operates on this world
        /// </summary>
        public Query CreateQuery() => new Query(this);

        /// <summary>
        /// Tries to get the archetype that matches the supplied TypeSignature.
        /// Returns false if the world is destroyed or null
        /// </summary>
        public bool TryGetArchetype(out Archetype archetype, TypeSignature signature)
        {
            if (this.TryGetWorldInfo(out var info))
            {
                archetype = info.GetArchetypeData(signature).archetype;
                return true;
            }
            archetype = default;
            return false;
        }

        /// <summary>
        /// WorldData is data unique to this world
        /// Set's the world's data to alue.
        /// </summary>
        public World SetData<WorldData>(WorldData world_data)
        {
            if (this.TryGetWorldInfo(out var info))
                info.GetData<WorldData>().data = world_data;
            return this;
        }

        /// <summary>
        /// WorldData is data unique to this world
        /// Get's a reference to the data which can be assigned.
        /// Throws an exception if the world is destroyed or null
        /// </summary>
        public ref WorldData GetData<WorldData>()
        {
            if (this.TryGetWorldInfo(out var info))
                return ref info.GetData<WorldData>().data;
            throw new Exception($"{this} is invalid, cannot get resource {typeof(WorldData).Name}");
        }

        /// <summary>
        /// Adds a callback to be invoked whenever an entity sets a component of type
        /// </summary>
        /// <param name="callback">callback to invoke</param>
        /// <param name="register">set true to add callback, false to remove the callback</param>
        public World OnSet<Component>(ComponentEvent<Component> callback, bool register = true)
        {
            if (this.TryGetWorldInfo(out var info))
            {
                var data = info.GetData<Component>();
                if (register)
                    data.set_callback += callback;
                else data.set_callback -= callback;
                data.has_set_callback = data.set_callback != null;
            }
            return this;
        }

        /// <summary>
        /// Adds a callback to be invoked whenever an entity removes a component of type
        /// </summary>
        /// <param name="callback">callback to invoke</param>
        /// <param name="register">set true to add callback, false to remove the callback</param>
        public World OnRemove<Component>(ComponentEvent<Component> callback, bool register = true)
        {
            if (this.TryGetWorldInfo(out var world_info))
            {
                var data = world_info.GetData<Component>();
                if (register)
                    data.remove_callback += callback;
                else data.remove_callback -= callback;
                data.has_remove_callback = data.remove_callback != null;
            }
            return this;
        }

        /// <summary>
        /// Resizes all archetype's backing arrays to the minimum power of 2 needed to store their entities
        /// </summary>
        public void ResizeBackingArrays()
        {
            if (this.TryGetWorldInfo(out var info))
                foreach (var arch_info in info.archetypes)
                    arch_info.data?.archetype.ResizeBackingArrays();
        }

        /// <summary>
        /// Destroys all archetypes with 0 entities
        /// </summary>
        public void DestroyEmptyArchetypes()
        {
            if (this.TryGetWorldInfo(out var world_info))
            {
                foreach (var arch in world_info.archetypes)
                {
                    if (arch.data == null) continue;
                    if (arch.data.entity_count == 0)
                        arch.data.archetype.Destroy();
                }
            }
        }

        public override string ToString()
         => $"{(IsValid() ? "" : "~")}{Name} {index}.{version}";

        bool IEquatable<World>.Equals(World other) => index == other.index && version == other.version;

        public override int GetHashCode() => index;

        public override bool Equals(object obj)
        {
            if (obj is World world)
                return world == this;
            return false;
        }

        public static bool operator ==(World a, World b) => a.index == b.index && a.version == b.version;
        public static bool operator !=(World a, World b) => !(a == b);

        public static implicit operator bool(World world) => World_Info.All[world.index].version == world.version;

        /// <summary>
        /// Returns a copy of all active Worlds
        /// </summary>
        public static World[] GetAll()
        {
            var worlds = new List<World>();
            foreach (var info in World_Info.All)
            {
                if (info.data != null)
                    worlds.Add(info.data.world);
            }
            return worlds.ToArray();
        }

        /// <summary>
        /// Tries to get the entity from the world by index
        /// </summary>
        public bool TryGetEntity(int index, out Entity entity)
        {
            if (this.TryGetWorldInfo(out var world_info))
            {
                var entity_info = world_info.entity_data[index];
                if (index > 0 && index < world_info.entity_count && entity_info.archetype_data != null)
                {
                    entity = new Entity(this, index, entity_info.version);
                    return true;
                }
            }
            entity = default;
            return false;
        }
    }
}

namespace SimpleECS.Internal
{
    using System.Collections.Generic;

    public delegate void ComponentEvent<T>(Entity entity, ref T component);

    public static partial class InternalExtensions
    {
        public static bool TryGetWorldInfo(this World world, out World_Info info)
        {
            var data = World_Info.All[world.index];
            if (data.version == world.version)
            {
                info = data.data;
                return true;
            }
            info = default;
            return false;
        }
    }

    public partial class World_Info
    {
        public static (World_Info data, int version)[] All =
            new (World_Info data, int version)[] { (default, 1), default }; // added a version to the 0th index so that a default world will be invalid
        public static int world_count;

        public string name;
        public World world;
        public World_Info(string name, World world)
        {
            this.name = name;
            this.world = world;
            archetypes[0].version++;    // this is just to prevent default archetype and default entity from being valid
            entity_data[0].version++;
            StructureEvents = new StructureEventHandler(this);
        }

        public struct Entity_Info
        {
            public Archetype_Info archetype_data;
            public int version;
            public int arch_index;
        }

        public int archetype_count => archetype_terminating_index - free_archetypes.Count;
        public int entity_count => entity_data_count - free_entities.Count;
        public Entity_Info[] entity_data = new Entity_Info[1024];
        int entity_data_count;

        public int archetype_terminating_index;
        public int archetype_structure_update_count;

        Stack<int> free_archetypes = new Stack<int>();
        public WorldData[] world_data = new WorldData[32];

        public (Archetype_Info data, int version)[] archetypes = new (Archetype_Info, int)[32];
        public Dictionary<TypeSignature, int> signature_to_archetype_index = new Dictionary<TypeSignature, int>();

        Stack<int> free_entities = new Stack<int>();
        public TypeSignature buffer_signature = new TypeSignature(); // just a scratch signature so that I'm not making new ones all the time

        public Archetype_Info GetArchetypeData(TypeSignature signature)
        {
            if (!signature_to_archetype_index.TryGetValue(signature, out var index))
            {
                if (free_archetypes.Count > 0)
                {
                    index = free_archetypes.Pop();
                    archetype_structure_update_count++;
                }
                else
                {
                    if (archetype_terminating_index == archetypes.Length)
                        System.Array.Resize(ref archetypes, archetype_terminating_index * 2);
                    index = archetype_terminating_index;
                    archetype_terminating_index++;
                }
                var sig = new TypeSignature(signature);
                signature_to_archetype_index[sig] = index;
                archetypes[index].data = new Archetype_Info(this, sig, index, archetypes[index].version);
            }
            return archetypes[index].data;
        }

        public WorldData<T> GetData<T>()
        {
            int type_id = TypeID<T>.Value;
            if (type_id >= world_data.Length)
            {
                var size = world_data.Length;
                while (size <= type_id)
                    size *= 2;
                System.Array.Resize(ref world_data, size);
            }
            if (world_data[type_id] == null)
                world_data[type_id] = new WorldData<T>();
            return (WorldData<T>)world_data[type_id];
        }

        public WorldData GetData(int type_id)
        {
            if (type_id >= world_data.Length)
            {
                var size = world_data.Length;
                while (size <= type_id)
                    size *= 2;
                System.Array.Resize(ref world_data, size);
            }
            if (world_data[type_id] == null)
                world_data[type_id] = (WorldData)System.Activator.CreateInstance(typeof(WorldData<>).MakeGenericType(TypeID.Get(type_id)));
            return world_data[type_id];
        }

        public abstract class WorldData
        {
            public abstract void InovkeSet(Entity entity, object comp_buffer, int entity_arch_index);
            public abstract void InvokeRemove(Entity entity, object component);
            public bool has_remove_callback, has_set_callback;
        }

        public sealed class WorldData<T> : WorldData
        {
            public T data;
            public ComponentEvent<T> set_callback, remove_callback;

            public override void InovkeSet(Entity entity, object comp_buffer, int entity_arch_index)
            {
                set_callback?.Invoke(entity, ref ((T[])comp_buffer)[entity_arch_index]);
            }

            public override void InvokeRemove(Entity entity, object component)
            {
                T comp = (T)component;
                remove_callback?.Invoke(entity, ref comp);
            }
        }

        /// <summary>
        /// Handles all structural changes to the world
        /// </summary>
        public StructureEventHandler StructureEvents;

        public struct StructureEventHandler
        {
            public StructureEventHandler(World_Info world)
            {
                cache_events = 0;
                events = new Queue<EventData>();
                this.world = world;
            }

            World_Info world;
            int cache_events;
            public int EnqueueEvents
            {
                get => cache_events;
                set
                {
                    cache_events = value;
                    ExecuteEventPlayback();
                }
            }
            Queue<EventData> events;

            struct EventData
            {
                public EventType type;
                public Entity entity;
                public Archetype archetype;
                public object obj_args;
                public int type_id;
            }

            enum EventType
            {
                CreateEntity,
                DestroyEntity,
                SetComponent,
                RemoveComponent,
                TransferEntity,
                DestroyArchetype,
                DestroyWorld,
                ResizeBackingArrays
            }

            public void ExecuteEventPlayback()
            {
                while (cache_events == 0 && events.Count > 0)
                {
                    var e = events.Dequeue();
                    switch (e.type)
                    {
                        case EventType.CreateEntity:
                        {
                            ref var data = ref world.entity_data[e.entity.index];
                            if (e.archetype.IsValid())
                            {
                                SetUpEntity(e.entity, world.archetypes[e.archetype.index].data);
                            }
                            else world.free_entities.Push(e.entity.index);
                        }
                        break;

                        case EventType.SetComponent:
                            Set(e.entity, e.type_id, e.obj_args);
                            break;

                        case EventType.RemoveComponent:
                            Remove(e.entity, e.type_id);
                            break;

                        case EventType.DestroyEntity:
                            Destroy(e.entity);
                            break;

                        case EventType.TransferEntity:
                            Transfer(e.entity, (World)e.obj_args);
                            break;

                        case EventType.DestroyArchetype:
                            if (e.archetype.TryGetArchetypeInfo(out var info))
                                DestroyArchetype(info);
                            break;

                        case EventType.DestroyWorld:
                            DestroyWorld();
                            break;

                        case EventType.ResizeBackingArrays:
                            ResizeBackingArrays(e.archetype);
                            break;
                    }
                }
            }

            public void DestroyArchetype(Archetype_Info data)
            {
                if (cache_events > 0)
                    events.Enqueue(new EventData { type = EventType.DestroyArchetype, archetype = data.archetype });
                else
                {
                    world.signature_to_archetype_index.Remove(data.signature);   // update archetype references
                    world.archetypes[data.archetype.index].version++;
                    world.archetypes[data.archetype.index].data = null;
                    world.free_archetypes.Push(data.archetype.index);
                    world.archetype_structure_update_count++;

                    for (int i = 0; i < data.entity_count; ++i)
                    {
                        var entity = data.entities[i];
                        world.entity_data[entity.index].version++;
                        world.entity_data[entity.index].archetype_data = null;
                        world.free_entities.Push(entity.index);
                    }

                    for (int i = 0; i < data.component_count; ++i)
                    {
                        var pool = data.component_buffers[i];
                        var callback = world.GetData(pool.type_id);
                        if (callback.has_remove_callback)
                        {
                            for (int e = 0; e < data.entity_count; ++e)
                            {
                                callback.InvokeRemove(data.entities[e], pool.buffer.Get(e));
                            }
                        }
                    }
                }
            }

            public void DestroyWorld()
            {
                if (cache_events > 0)
                    events.Enqueue(new EventData { type = EventType.DestroyWorld });
                else
                {
                    ref var world_info = ref All[world.world.index];
                    if (world_info.version == world.world.version)  // still needs to be checked incase multiple destorys are queued
                    {
                        world_info.version++;
                        foreach (var archetype in world_info.data.archetypes)
                        {
                            var arche_info = archetype.data;
                            if (arche_info == null) continue;

                            for (int i = 0; i < arche_info.component_count; ++i)
                            {
                                var pool = arche_info.component_buffers[i];
                                var world_data = world_info.data.GetData(pool.type_id);
                                if (world_data.has_remove_callback)
                                {
                                    for (int e = 0; e < arche_info.entity_count; ++e)
                                    {
                                        world_data.InvokeRemove(arche_info.entities[e], pool.buffer.Get(e));
                                    }
                                }
                            }
                        }
                        world_info.data = null;
                    }
                }
            }

            public Entity CreateEntity(Archetype_Info archetype_data)
            {
                int index = 0;
                if (world.free_entities.Count > 0)
                    index = world.free_entities.Pop();
                else
                {
                    index = world.entity_data_count;
                    if (index == world.entity_data.Length)
                        System.Array.Resize(ref world.entity_data, index * 2);
                    world.entity_data_count++;
                }
                var version = world.entity_data[index].version;
                var entity = new Entity(world.world, index, version);

                if (cache_events > 0)
                {
                    world.entity_data[index].version++;
                    events.Enqueue(new EventData { type = EventType.CreateEntity, entity = entity, archetype = archetype_data.archetype });
                }
                else SetUpEntity(entity, archetype_data);
                return entity;
            }

            void SetUpEntity(Entity entity, Archetype_Info archetype_data)
            {
                ref var entity_data = ref world.entity_data[entity.index];
                entity_data.version = entity.version;
                entity_data.archetype_data = archetype_data;
                var arch_index = entity_data.arch_index = archetype_data.entity_count;
                archetype_data.entity_count++;
                archetype_data.EnsureCapacity(arch_index);
                archetype_data.entities[arch_index] = entity;
            }

            ref Entity_Info GetEntityData(Entity entity) => ref world.entity_data[entity.index];

            public StructureEventHandler Set(Entity entity, int type_id, object component)
            {
                if (cache_events > 0)
                {
                    events.Enqueue(new EventData { type = EventType.SetComponent, entity = entity, obj_args = component, type_id = type_id });
                }
                else
                {
                    ref var entity_data = ref GetEntityData(entity);
                    if (entity.version == entity_data.version)
                    {
                        var archetype = entity_data.archetype_data;
                        if (archetype.TryGetCompBuffer(type_id, out var set_pool))
                        {
                            set_pool.Set(entity_data.arch_index, component);

                            var data = world.GetData(type_id);
                            if (data.has_set_callback)
                                data.InovkeSet(entity, set_pool.array, entity_data.arch_index);
                        }
                        else
                        {
                            var target_archetype = entity_data.archetype_data = world.GetArchetypeData(world.buffer_signature.Copy(archetype.signature).Add(type_id));
                            // removing entity from current archetype
                            var entity_index = entity_data.arch_index;
                            archetype.entity_count--;
                            var last = archetype.entities[entity_index] = archetype.entities[archetype.entity_count];
                            GetEntityData(last).arch_index = entity_index; // reassign moved entity to to index

                            // adding entity to target archetype
                            var target_index = entity_data.arch_index = target_archetype.entity_count;
                            target_archetype.EnsureCapacity(target_index);
                            target_archetype.entity_count++;
                            target_archetype.entities[target_index] = entity;

                            // moving components over
                            for (int i = 0; i < archetype.component_count; ++i)
                                archetype.component_buffers[i].buffer.Move(entity_index, archetype.entity_count, target_archetype, target_index);

                            // setting the added component and calling the callback event
                            if (target_archetype.TryGetCompBuffer(type_id, out var target_buffer))
                            {
                                target_buffer.Set(target_index, component);
                                var data = world.GetData(type_id);
                                if (data.has_set_callback)
                                    data.InovkeSet(entity, target_buffer.array, entity_data.arch_index);
                            }
                            else
                                throw new System.Exception("Frame Work Bug");
                        }
                    }
                }
                return this;
            }

            public void Remove(Entity entity, int type_id)
            {
                if (cache_events > 0)
                {
                    events.Enqueue(new EventData { type = EventType.RemoveComponent, entity = entity, type_id = type_id });
                }
                else
                {
                    ref var entity_data = ref GetEntityData(entity);
                    if (entity.version == entity_data.version)
                    {
                        var archetype = entity_data.archetype_data;
                        if (archetype.TryGetCompBuffer(type_id, out var set_pool))
                        {
                            var target_archetype = entity_data.archetype_data = world.GetArchetypeData(world.buffer_signature.Copy(archetype.signature).Remove(type_id));
                            // removing entity from current archetype
                            var entity_arch_index = entity_data.arch_index;
                            archetype.entity_count--;
                            var last = archetype.entities[entity_arch_index] = archetype.entities[archetype.entity_count];
                            GetEntityData(last).arch_index = entity_arch_index; // reassign moved entity to to index

                            // adding entity to target archetype
                            var target_index = entity_data.arch_index = target_archetype.entity_count;
                            target_archetype.EnsureCapacity(target_index);
                            target_archetype.entity_count++;
                            target_archetype.entities[target_index] = entity;

                            var removed = set_pool.Get(entity_arch_index);

                            // moving components over
                            for (int i = 0; i < archetype.component_count; ++i)
                                archetype.component_buffers[i].buffer.Move(entity_arch_index, archetype.entity_count, target_archetype, target_index);

                            var data = world.GetData(type_id);
                            if (data.has_remove_callback)
                                world.GetData(type_id).InvokeRemove(entity, removed);
                        }
                    }
                }
            }

            public void Transfer(Entity entity, World target_world)
            {
                if (cache_events > 0)
                    events.Enqueue(new EventData { type = EventType.TransferEntity, entity = entity, obj_args = target_world });
                else
                {
                    if (entity.IsValid() && target_world.TryGetWorldInfo(out var target_world_info))
                    {
                        ref var entity_data = ref GetEntityData(entity);
                        var entity_archetype = entity_data.archetype_data;
                        var target_archtype = target_world_info.GetArchetypeData(entity_archetype.signature);
                        var target_entity = target_archtype.archetype.CreateEntity();
                        var target_entity_data = target_world_info.StructureEvents.GetEntityData(target_entity);
                        var entity_index = entity_data.arch_index;
                        var target_index = target_entity_data.arch_index;
                        target_archtype.EnsureCapacity(target_index);

                        // swapping current entity with last entity
                        entity_archetype.entity_count--;
                        var last = entity_archetype.entities[entity_index] = entity_archetype.entities[entity_archetype.entity_count];
                        GetEntityData(last).arch_index = entity_index;
                        for (int i = 0; i < entity_archetype.component_count; ++i)
                        {
                            var entity_comp_buffer = entity_archetype.component_buffers[i].buffer;
                            var target_array = target_archtype.component_buffers[i].buffer.array;
                            entity_comp_buffer.Move(entity_index, entity_archetype.entity_count, target_array, target_index);
                        }

                        // freeing transfered entity
                        entity_data.version++;
                        entity_data.archetype_data = default;
                        world.free_entities.Push(entity.index);
                    }
                }
            }

            public void Destroy(Entity entity)
            {
                if (cache_events > 0)
                    events.Enqueue(new EventData { type = EventType.DestroyEntity, entity = entity });
                else
                {
                    if (entity)
                    {
                        ref var entity_data = ref GetEntityData(entity);
                        var archetype_data = entity_data.archetype_data;
                        var entity_index = entity_data.arch_index;
                        entity_data.version++;
                        entity_data.archetype_data = default;
                        archetype_data.entity_count--;

                        var last = archetype_data.entities[entity_index] = archetype_data.entities[archetype_data.entity_count];
                        GetEntityData(last).arch_index = entity_index;

                        int count = events.Count;
                        object[] removed = new object[archetype_data.component_count];
                        for (int i = 0; i < archetype_data.component_count; ++i)
                        {
                            var pool_data = archetype_data.component_buffers[i];
                            removed[i] = pool_data.buffer.Get(entity_index);
                            pool_data.buffer.Remove(entity_index, archetype_data.entity_count);

                        }
                        world.free_entities.Push(entity.index);

                        for (int i = 0; i < archetype_data.component_count; ++i)
                        {
                            var pool_data = archetype_data.component_buffers[i];
                            var data = world.GetData(pool_data.type_id);
                            if (data.has_remove_callback)
                                data.InvokeRemove(entity, removed[i]);
                        }
                    }
                }
            }

            public void ResizeBackingArrays(Archetype archetype)
            {
                if (cache_events > 0)
                    events.Enqueue(new EventData { type = EventType.ResizeBackingArrays, archetype = archetype });
                else
                    if (archetype.TryGetArchetypeInfo(out var info))
                    info.ResizeBackingArrays();
            }
        }
    }
}