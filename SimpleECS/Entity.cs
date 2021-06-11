namespace SimpleECS
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Basic container of components
    /// </summary>
    public partial struct Entity : IEquatable<Entity>, IComparable<Entity>
    {
        internal Entity(int id, int version, World world)
        {
            this.index = id; this.version = version; this.world = world;
        }

        /// <summary>
        /// World entity belongs to
        /// </summary>
        public readonly World world;

        /// <summary>
        /// Identifier to map entity to components
        /// </summary>
        public readonly int index;

        /// <summary>
        /// Versioning to verify validity 
        /// </summary>
        public readonly int version;

        /// <summary>
        /// Gets a reference to the component.
        /// Throws an exception if entity is invalid or fails to get the component.
        /// </summary>
        public ref Component Get<Component>() => ref world.Get<Component>(index, version);

        /// <summary>
        /// Returns true if entity has component
        /// </summary>
        public bool Has<Component>() => world.Has<Component>(this);
        
        /// <summary>
        /// Sets the component on Entity.
        /// If Entity does not have component, the component is added instead.
        /// Will trigger callbacks registered with World.OnSet()
        /// </summary>
        public Entity Set<Component>(in Component component) => world.Set(this, component);
        
        /// <summary>
        /// Tries to get the component, returns if sucessful.
        /// </summary>
        public bool TryGet<Component>(out Component component) => world.TryGet(this, out component);
        
        /// <summary>
        /// Removes the component from Entity.
        /// Will trigger callbacks registered with World.OnRemove();
        /// </summary>
        public Entity Remove<Component>() => world.Remove<Component>(this);

        /// <summary>
        /// Destroys the entity.
        /// All components on entity will trigger their respective World.OnRemove() callbacks.
        /// </summary>
        public void Destroy() => world.Destroy(this);

        /// <summary>
        /// Returns the archetype this entity belongs to.
        /// Returns false if the entity is invalid.
        /// </summary>
        public bool TryGetArchetype(out World.Archetype archetype) => world.TryGetArchetype(this, out archetype);
        
        /// <summary>
        /// Gets a list of all components currently on the entity.
        /// </summary>
        /// <param name="storage">where to store the components otherwise creates a new List if null</param>
        /// <returns></returns>
        public List<object> GetAllComponents(List<object> storage = null) => world.GetAllComponents(this, storage);
        
        /// <summary>
        /// Transfers this entity to the specified world.
        /// The current Entity will be invalid.
        /// Returns the Entity's value in the other world.
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public Entity Transfer(World world) => this.world.Transfer(this, world);

        /// <summary>
        /// Returns true if entity is valid, false if entity is invalid or destroyed
        /// </summary>
        public bool IsValid() => World.IsValid(this);

#pragma warning disable
        public static implicit operator bool(Entity entity)
            => World.IsValid(entity);

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

        public override string ToString()
        {
            if (!this.TryGet(out string name) || string.IsNullOrEmpty(name))
                name = "Entity";
            return $"{name} {index}.{version}";
        }

        int IComparable<Entity>.CompareTo(Entity other)
        {
            if (index < other.index) return -1;
            if (index > other.index) return 1;
            if (version < other.version) return -1;
            if (version > other.version) return 1;
            return 0;
        }
    }
}