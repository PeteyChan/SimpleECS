namespace SimpleECS
{
    using System;
    using Internal;

    /// <summary>
    /// Acts as a container of a set of components. Can be filtered by queries to get entities that have speicified components.
    /// </summary>
    public struct Entity : IEquatable<Entity>
    {
        internal Entity(int index, int version)
        {
            this.index = index; this.version = version;
        }

        /// <summary>
        /// the world that the entity belongs to
        /// </summary>
        public World world
        {
            get
            {
                ref var info = ref Entities.All[index];
                if (info.version == version)
                    return info.world_info.world;
                return default;
            }
        }

        /// <summary>
        /// the archetype that the entity belongs to
        /// </summary>
        public Archetype archetype
        {
            get
            {
                ref var info = ref Entities.All[index];
                if (info.version == version)
                    return info.arch_info.archetype;
                return default;
            }
        }

        /// <summary>
        /// the combination of the index and version act as a unique identifier for the entity
        /// </summary>
        public readonly int index;

        /// <summary>
        /// the combination of the index and version act as a unique identifier for the entity
        /// </summary>
        public readonly int version;

        /// <summary>
        /// returns entity's string value if set
        /// </summary>
        public override string ToString()
        {
            string name;
            TryGet<string>(out name);
            if (String.IsNullOrEmpty(name))
                name = IsValid() ? "Entity" : "~Entity";
            return $"{name} {index}.{version}";
        }

        /// <summary>
        /// returns true if the the entity is not destroyed or null
        /// </summary>
        public bool IsValid() => Entities.All[index].version == version;

        /// <summary>
        /// returns true if the entity has the component
        /// </summary>
        public bool Has<Component>()
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
                return info.arch_info.Has(TypeID<Component>.Value);
            return false;
        }

        /// <summary>
        /// returns true if the entity has the component
        /// </summary>
        public bool Has(Type type)
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
                return info.arch_info.Has(TypeID.Get(type));
            return false;
        }

        /// <summary>
        /// [structural]
        /// removes the component from the entity.
        /// if component was removed will trigger the corresponding onremove component event
        /// </summary>
        public Entity Remove<Component>()
        {
            Entities.All[index].world_info?.StructureEvents.Remove<Component>(this);
            return this;
        }

        /// <summary>
        /// [structural]
        /// removes the component from the entity.
        /// if component was removed will trigger the corresponding onremove component event
        /// </summary>
        public Entity Remove(Type type)
        {
            ref var info = ref Entities.All[index];
            if (info.world_info != null)
                info.world_info.GetData(TypeID.Get(type)).Remove(this, info.world_info.StructureEvents);
            return this;
        }

        /// <summary>
        /// [structural]
        /// sets the entity's component to value. 
        /// If the entity does not have the component, will move the entity to an archetype that does.
        /// will trigger the onset component event if component was set
        /// </summary>
        public Entity Set<Component>(in Component component)
        {
            Entities.All[index].world_info?.StructureEvents.Set(this, component);
            return this;
        }

        /// <summary>
        /// [structural]
        /// sets the entity's component to value. 
        /// If the entity does not have the component, will move the entity to an archetype that does.
        /// will trigger the onset component event if component was set
        /// will trigger an exception if component_of_type is not of type
        /// </summary>
        public Entity Set(Type type, object component_of_type)
        {
            ref var info = ref Entities.All[index];
            if (info.world_info != null)
                info.world_info.GetData(TypeID.Get(type)).Set(this, component_of_type, info.world_info.StructureEvents);
            return this;
        }

        /// <summary>
        /// returns true if the entity has component, outputs the component
        /// </summary>
        public bool TryGet<Component>(out Component component)
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
            {
                if (info.arch_info.TryGetArray<Component>(out var buffer))
                {
                    component = buffer[info.arch_index];
                    return true;
                }
            }
            component = default;
            return false;
        }

        /// <summary>
        /// returns true if the entity has component, outputs the component
        /// </summary>
        public bool TryGet(Type type, out object component)
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
            {
                if (info.arch_info.TryGetCompBuffer(TypeID.Get(type), out var buffer))
                {
                    component = buffer.array[info.arch_index];
                    return true;
                }
            }
            component = default;
            return false;
        }

        /// <summary>
        /// gets the reference to the component on the entity.
        /// throws an exception if the entity is invalid or does not have the component
        /// </summary>
        public ref Component Get<Component>()
        {
            ref var entity_info = ref Entities.All[index];
            if (entity_info.version == version)
            {
                if (entity_info.arch_info.TryGetArray<Component>(out var buffer))
                    return ref buffer[entity_info.arch_index];
                throw new Exception($"{this} does not contain {typeof(Component).Name}");
            }
            throw new Exception($"{this} is not a valid entity, cannot get {typeof(Component).Name}");
        }

        /// <summary>
        /// [structural]
        /// transfers the entity to the target world
        /// </summary>
        public void Transfer(World target_world)
        {
            Entities.All[index].world_info?.StructureEvents.Transfer(this, target_world);
        }

        /// <summary>
        /// [structural]
        /// destroys the entity
        /// </summary>
        public void Destroy()
        {
            Entities.All[index].world_info?.StructureEvents.Destroy(this);
        }

        bool IEquatable<Entity>.Equals(Entity other) => index == other.index && version == other.version;

        public override bool Equals(object obj) => obj is Entity e ? e == this : false;

        public static bool operator ==(Entity a, Entity b) => a.index == b.index && a.version == b.version;

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => index;

        public static implicit operator bool(Entity entity) => entity.IsValid();

        /// <summary>
        /// returns a copy of all the entity's components
        /// </summary>
        public object[] GetAllComponents()
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
            {
                return info.arch_info.GetAllComponents(info.arch_index);
            }
            return new object[0];
        }

        /// <summary>
        /// returns a copy of all the types of components attached to the entity
        /// </summary>
        public Type[] GetAllComponentTypes()
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
            {
                return info.arch_info.GetComponentTypes();
            }
            return new Type[0];
        }

        /// <summary>
        /// returns how many components are attached to the entity
        /// </summary>
        public int GetComponentCount()
        {
            ref var info = ref Entities.All[index];
            if (info.version == version)
                return info.arch_info.component_count;
            return 0;
        }
    }
}

namespace SimpleECS.Internal
{
    public partial class Extensions
    {
        /// <summary>
        /// Sets the value to entity only if entity is valid and has component.
        /// Does not invoke set callback event
        /// </summary>
        public static void SetDirectNoInvoke(this Entity entity, System.Type type, in object value)
        {
            var entity_info = Entities.All[entity.index];
            if (entity_info.version == entity.version)
            {
                if (entity_info.arch_info.TryGetCompBuffer(TypeID.Get(type), out var buffer))
                    buffer.array[entity_info.arch_index] = value;
            }
        }
    }
}