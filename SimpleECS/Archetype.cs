namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// stores component data of entities that matches the archetype's type signature
    /// </summary>
    public struct Archetype : IEquatable<Archetype>, IEnumerable<Entity> 
    {
        internal Archetype(World world, int index, int version)
        {
            this.world = world; this.index = index; this.version = version;
        }

        /// <summary>
        /// returns a copy of archetype's type signature
        /// </summary>
        public TypeSignature GetTypeSignature()
            => this.TryGetArchetypeInfo(out var archetype_Info) ? new TypeSignature(archetype_Info.signature) : new TypeSignature();

        /// <summary>
        /// returns a copy of component types in this archetype
        /// </summary>
        public Type[] GetTypes()
            => this.TryGetArchetypeInfo(out var archetype_Info) ? archetype_Info.GetComponentTypes() : new Type[0];
        
        /// <summary>
        /// the world this archetype belongs to
        /// </summary>
        public readonly World world;

        /// <summary>
        /// the index and version create a unique identifier for the archetype
        /// </summary>
        public readonly int index;

        /// <summary>
        /// the index and version create a unique identifier for the archetype
        /// </summary>
        public readonly int version;

        /// <summary>
        /// [structural]
        /// creates an entity that matches this archetype
        /// </summary>
        public Entity CreateEntity()
        {
            if (this.TryGetArchetypeInfo(out var world_info, out var archetype_info))
                return world_info.StructureEvents.CreateEntity(archetype_info);
            return default;
        }

        /// <summary>
        /// returns a copy of all the entities stored in the archetype
        /// </summary>
        public Entity[] GetEntities()
        {
            Entity[] entities = new Entity[EntityCount];
            if (this.TryGetArchetypeInfo(out var archetype_info))
                for (int i = 0; i < archetype_info.entity_count; ++i)
                    entities[i] = archetype_info.entities[i];
            return entities;
        }

        /// <summary>
        /// returns the total amount of entities stored in the archetype
        /// </summary>
        public int EntityCount => this.TryGetArchetypeInfo(out var archetype_Info) ? archetype_Info.entity_count : 0;

        /// <summary>
        /// returns false if the archetype is invalid or destroyed.
        /// outputs the raw entity storage buffer.
        /// should be treated as readonly as changing values will break the ecs.
        /// only entities up to archetype's EntityCount are valid, DO NOT use the length of the array
        /// </summary>
        public bool TryGetEntityBuffer(out Entity[] entity_buffer)
        {
            if (this.TryGetArchetypeInfo(out var data))
            {
                entity_buffer = data.entities;
                return true;
            }
            entity_buffer = default;
            return false;
        }

        /// <summary>
        /// returns false if the archetype is invalid or does not store the component buffer
        /// outputs the raw component storage buffer.
        /// only components up to archetype's EntityCount are valid
        /// entities in the entity buffer that share the same index as the component in the component buffer own that component
        /// </summary>
        public bool TryGetComponentBuffer<Component>(out Component[] comp_buffer)
        {
            if (this.TryGetArchetypeInfo(out var data))
                return data.TryGetArray(out comp_buffer);
            comp_buffer = default;
            return false;
        }

        /// <summary>
        /// [structural]
        /// destroys the archetype along with all the entities within it
        /// </summary>
        public void Destroy()
        {
            if (world.IsValid())
                World_Info.All[world.index].data.StructureEvents.DestroyArchetype(this);
        }

        /// <summary>
        /// [structural]
        /// resizes the archetype's backing arrays to the minimum number of 2 needed to store the entities
        /// </summary>
        public void ResizeBackingArrays()
        {
            if (world.IsValid())
                World_Info.All[world.index].data.StructureEvents.ResizeBackingArrays(this);
        }

        bool IEquatable<Archetype>.Equals(Archetype other)
            => world == other.world && index == other.index && version == other.version;
 
        /// <summary>
        /// returns true if the archetype is not null or destroyed
        /// </summary>
        public bool IsValid()
            => world.TryGetWorldInfo(out var info) && info.archetypes[index].version == version;

        public static implicit operator bool(Archetype archetype) => archetype.IsValid();

        public override bool Equals(object obj) => obj is Archetype a ? a == this : false;

        public static implicit operator int(Archetype a) => a.index;

        public static bool operator ==(Archetype a, Archetype b) => a.world == b.world && a.index == b.index && a.version == b.version;

        public static bool operator !=(Archetype a, Archetype b) => !(a == b);

        public override int GetHashCode() => index;

        public override string ToString() => $"{(IsValid() ? "" : "~")}Arch [{GetTypeString()}]";

        string GetTypeString()
        {
            string val = "";
            if (this.TryGetArchetypeInfo(out var archetype_info))
            {
                for(int i = 0; i < archetype_info.component_count; ++ i)
                {
                    val += $" {TypeID.Get(archetype_info.component_buffers[i].type_id).Name}";
                }
            }
            return val;
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            if (this.TryGetArchetypeInfo(out var info))
                for(int i = 0; i < info.entity_count; ++ i)
                    yield return info.entities[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (this.TryGetArchetypeInfo(out var info))
                for(int i = 0; i < info.entity_count; ++ i)
                    yield return info.entities[i];
        }
    }
}

namespace SimpleECS.Internal
{
    using System;
    using System.Collections;

    public static partial class Extensions
    {
        public static bool TryGetArchetypeInfo(this Archetype archetype, out World_Info world_info, out Archetype_Info arch_info)
        {
            if (archetype.world.TryGetWorldInfo(out  world_info))
            {
                var arch = world_info.archetypes[archetype.index];
                if (arch.version == archetype.version)
                {
                    arch_info = arch.data;
                    return true;
                }
            }
            arch_info = default;
            world_info = default;
            return false;
        }

        public static bool TryGetArchetypeInfo(this Archetype archetype, out Archetype_Info arch_info)
        {
            if (archetype.world.TryGetWorldInfo(out var world_info))
            {
                var arch = world_info.archetypes[archetype.index];
                if (arch.version == archetype.version)
                {
                    arch_info = arch.data;
                    return true;
                }
            }
            arch_info = default;
            return false;
        }
    }

    public class Archetype_Info
    {
        public Archetype_Info(World_Info world, TypeSignature signature, int arch_index, int arch_version)
        {
            this.world_info = world;
            this.signature = signature;
            this.archetype = new Archetype(world.world, arch_index, arch_version);

            component_buffers = new CompBufferData[signature.Count == 0 ? 1 : signature.Count];
            component_count = signature.Count;

            for (int i = 0; i < component_buffers.Length; ++i)
                component_buffers[i].next = -1;

            // add components into empty bucket, skip if bucket is occupied
            for(int i = 0 ; i < component_count; ++ i)
            {
                var type = signature.Types[i];
                var type_id = TypeID.Get(type);
                var index = type_id % component_buffers.Length;
                ref var buffer_data = ref component_buffers[index];
                if (buffer_data.type_id == 0)
                {
                    buffer_data.type_id = type_id;
                    buffer_data.buffer = CreatePool(type);
                }
            }
            
            // add skipped components into buckets not filled in first pass
            // hopefully this minimizes lookup time
            for(int i = 0; i < component_count; ++ i)   
            {
                var type = signature.Types[i];
                var type_id = TypeID.Get(type);
                if (ContainsType(type_id)) continue;
                var index = GetEmptyIndex(type_id%component_buffers.Length);
                ref var buffer_data = ref component_buffers[index];
                buffer_data.type_id = type_id;
                buffer_data.buffer = CreatePool(type);
            }

            bool ContainsType(int type_id)
            {
                foreach(var val in component_buffers)
                    if (val.type_id == type_id) return true;
                return false;
            }

            // if current index is filled, will return an empty index with a way to get to that index from the provided one
            int GetEmptyIndex(int current_index)
            {
                if (component_buffers[current_index].type_id == 0)
                    return current_index;

                while (component_buffers[current_index].next >= 0)
                {
                    current_index = component_buffers[current_index].next;
                }

                for (int i = 0; i < component_count; ++i)
                    if (component_buffers[i].type_id == 0)
                    {
                        component_buffers[current_index].next = i;
                        return i;
                    }
                throw new Exception("FRAMEWORK BUG: not enough components in archetype");
            }

            CompBuffer CreatePool(Type type)
                => Activator.CreateInstance(typeof(CompBuffer<>).MakeGenericType(type)) as CompBuffer;
        }


        public int entity_count;
        public Entity[] entities = new Entity[8];
        public World_Info world_info;
        public TypeSignature signature;
        public readonly Archetype archetype;
        public readonly int component_count;
        public CompBufferData[] component_buffers;

        public struct CompBufferData
        {
            public int next;
            public int type_id;
            public CompBuffer buffer;
        }

        /// <summary>
        /// resizes all backing arrays to minimum power of 2
        /// </summary>
        public void ResizeBackingArrays()
        {
            int size = 8;
            while (size <= entity_count)
                size *= 2;
            System.Array.Resize(ref entities, size);
            for(int i = 0; i < component_count; ++ i)
                component_buffers[i].buffer.Resize(size);
        }

        public void EnsureCapacity(int capacity)
        {
            if (capacity >= entities.Length)
            {
                int size = entities.Length;
                while (capacity >= size)
                    size *= 2;
                System.Array.Resize(ref entities, size);
                for (int i = 0; i < component_count; ++i)
                    component_buffers[i].buffer.Resize(size);
            }
        }

        public bool Has(int type_id)
        {
            var data = component_buffers[type_id % component_buffers.Length];
            if (data.type_id == type_id)
                return true;

            while (data.next >= 0)
            {
                data = component_buffers[data.next];
                if (data.type_id == type_id)
                    return true;
            }
            return false;
        }

        public bool TryGetArray<Component>(out Component[] components)
        {
            int type_id = TypeID<Component>.Value;
            var data = component_buffers[type_id % component_buffers.Length];
            if (data.type_id == type_id)
            {
                components = (Component[])data.buffer.array;
                return true;
            }
            while (data.next >= 0)
            {
                data = component_buffers[data.next];
                if (data.type_id == type_id)
                {
                    components = (Component[])data.buffer.array;
                    return true;
                }
            }
            components = default;
            return false;
        }

        public bool TryGetCompBuffer(int type_id, out CompBuffer buffer)
        {
            var data = component_buffers[type_id % component_buffers.Length];
            if (data.type_id == type_id)
            {
                buffer = data.buffer;
                return true;
            }
            while (data.next >= 0)
            {
                data = component_buffers[data.next];
                if (data.type_id == type_id)
                {
                    buffer = data.buffer;
                    return true;
                }
            }
            buffer = default;
            return false;
        }

        public object[] GetAllComponents(int entity_arch_index)
        {
            object[] components = new object[component_count];

            for (int i = 0; i < component_count; ++i)
                components[i] = component_buffers[i].buffer.array[entity_arch_index];
            return components;
        }

        public Type[] GetComponentTypes()
        {
            Type[] components = new Type[component_count];
            for (int i = 0; i < component_count; ++i)
                components[i] = TypeID.Get(component_buffers[i].type_id);
            return components;
        }

        public abstract class CompBuffer    //handles component data
        {
            public IList array;
            public abstract void Resize(int capacity);
            /// <summary>
            /// returns removed component
            /// </summary>
            public abstract object Remove(int entity_arch_index, int last);
            public abstract void Move(int entity_arch_index, int last_entity_index, Archetype_Info target_archetype, int target_index);
            public abstract void Move(int entity_arch_index, int last_entity_index, object buffer, int target_index);
        }

        public sealed class CompBuffer<Component> : CompBuffer
        {
            public CompBuffer()
            {
                array = components;
            }

            public Component[] components = new Component[8];

            public override void Resize(int capacity)
            {
                System.Array.Resize(ref components, capacity);
                array = components;
            }

            public override object Remove(int entity_arch_index, int last)
            {
                var comp = components[entity_arch_index];
                components[entity_arch_index] = components[last];
                components[last] = default;
                return comp;
            }

            public override void Move(int entity_arch_index, int last_entity_index, Archetype_Info target_archetype, int target_index)
            {
                if (target_archetype.TryGetArray<Component>(out var target_array))
                {
                    target_array[target_index] = components[entity_arch_index];
                }
                components[entity_arch_index] = components[last_entity_index];
                components[last_entity_index] = default;
            }

            public override void Move(int entity_arch_index, int last_entity_index, object buffer, int target_index)
            {
                ((Component[])buffer)[target_index] = components[entity_arch_index];
                components[entity_arch_index] = components[last_entity_index];
                components[last_entity_index] = default;
            }
        }
    }
}