namespace SimpleECS
{
    using System;
    using Internal;

    /// <summary>
    /// Acts as a container of a set of components. Can be filtered by queries to get entities that have speicified components.
    /// </summary>
    public struct Entity : IEquatable<Entity>
    {
        internal Entity(World world, int index, int version)
        {
            this.world = world; this.index = index; this.version = version;
        }

        /// <summary>
        /// the world that the entity belongs to
        /// </summary>
        public readonly World world;

        /// <summary>
        /// the archetype that the entity belongs to
        /// </summary>
        public Archetype archetype => this.TryGetArchetypeInfo(out var archetype_info) ? archetype_info.archetype : default;

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
            if (!TryGet<string>(out name))
            {
                name = IsValid() ? "Entity" : "~Entity";
                return $"{name} {index}.{version}";
            }
            return name;
        }

        /// <summary>
        /// returns true if the the entity is not destroyed or null
        /// </summary>
        public bool IsValid() => World_Info.All[world.index].version == world.version && World_Info.All[world.index].data.entity_data[index].version == version;

        /// <summary>
        /// returns true if the entity has the component
        /// </summary>
        public bool Has<Component>()
        {
            if (this.TryGetArchetypeInfo(out var archetype_info))
                return archetype_info.Has(TypeID<Component>.Value);
            return false;
        }

        /// <summary>
        /// removes the component from the entity.
        /// if component was removed will trigger the corresponding onremove component event
        /// </summary>
        public Entity Remove<Component>()
        {
            if (world.TryGetWorldInfo(out var world_info))
                world_info.StructureEvents.Remove(this, TypeID<Component>.Value);
            return this;
        }

        /// <summary>
        /// sets the entity's component to value. 
        /// If the entity does not have the component, will move the entity to an archetype that does.
        /// will trigger the onset component event if component was set
        /// </summary>
        public Entity Set<Component>(in Component component)
        {
            if (world.TryGetWorldInfo(out var world_info))
                world_info.StructureEvents.Set(this, TypeID<Component>.Value, component);
            return this;
        }

        /// <summary>
        /// returns true if the entity has component, outputs the component
        /// </summary>
        public bool TryGet<Component>(out Component component)
        {
            if (world.TryGetWorldInfo(out var world_info))
            {
                var entity_data = world_info.entity_data[index];
                if (entity_data.version == version)
                {
                    if (entity_data.archetype_data.TryGetArray<Component>(out var pool))
                    {
                        component = pool[entity_data.arch_index];
                        return true;
                    }
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
            if (world.TryGetWorldInfo(out var world_info))
            {
                var entity_data = world_info.entity_data[index];
                if (entity_data.version == version)
                {
                    if (entity_data.archetype_data.TryGetArray<Component>(out var pool))
                        return ref pool[entity_data.arch_index];
                    throw new Exception($"{this} does not contain a {typeof(Component).Name}");
                }
                throw new Exception($"{this} is invalid and cannot get {typeof(Component).Name}");
            }
            throw new Exception($"{this} world is not valid, cannot get {typeof(Component).Name}");
        }

        /// <summary>
        /// transfers the entity to the target world
        /// </summary>
        public void TransferTo(World target_world)
        {
            if (world.TryGetWorldInfo(out var world_info))
                world_info.StructureEvents.Transfer(this, target_world);
        }

        /// <summary>
        /// destroys the entity
        /// </summary>
        public void Destroy()
        {
            if (world.TryGetWorldInfo(out var world_info))
                world_info.StructureEvents.Destroy(this);
        }

        bool IEquatable<Entity>.Equals(Entity other) => index == other.index && version == other.version;

        public override bool Equals(object obj) => obj is Entity e ? e == this : false;

        public static bool operator ==(Entity a, Entity b) => a.world == b.world && a.index == b.index && a.version == b.version;

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        public override int GetHashCode() => index;

        public static implicit operator bool(Entity entity) => entity.IsValid();

        /// <summary>
        /// returns a copy of all the entity's components
        /// </summary>
        public object[] GetAllComponents()
        {
            if (world.TryGetWorldInfo(out var world_info))
            {
                var entity_info = world_info.entity_data[index];
                if (entity_info.version == version)
                    return entity_info.archetype_data.GetAllComponents(entity_info.arch_index);
            }
            return new object[0];
        }

        /// <summary>
        /// returns the type of all the entity's components
        /// </summary>
        public Type[] GetAllComponentTypes()
        {
            if (this.TryGetArchetypeInfo(out var archetype_info))
                return archetype_info.GetComponentTypes();
            return new Type[0];
        }
    }
}

namespace SimpleECS.Internal
{
    public static partial class InternalExtensions
    {
        public static bool TryGetArchetypeInfo(this Entity entity, out Archetype_Info archetypeData)
        {
            if (entity.world.TryGetWorldInfo(out var world_Info))
            {
                if (world_Info.entity_data[entity.index].version == entity.version)
                {
                    archetypeData = world_Info.entity_data[entity.index].archetype_data;
                    return true;
                }
            }
            archetypeData = default;
            return false;
        }
    }    
}
