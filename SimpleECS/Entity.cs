namespace SimpleECS
{
    using System;

    /// <summary>
    /// Is called on the component when added to the entity with Set()
    /// </summary>
    public interface IOnSetCallback
    {
        void OnSetBy (Entity entity);
    }

    /// <summary>
    /// Is called on the component when owner entity remove's the component or entity is destroyed.
    /// If entity was destroyed, entity will be invalid during the callback
    /// </summary>
    public interface IOnRemoveCallback
    {
        void OnRemoveBy (Entity entity);
    }

    public partial struct Entity : IEquatable<Entity>, IComparable<Entity>
    {
        internal Entity(int id, int version)
        {
            this.index = id; this.version = version;
        }

        /// <summary>
        /// Identifier to map entity to components
        /// </summary>
        public readonly int index;

        /// <summary>
        /// Versioning to verify validity 
        /// </summary>
        public readonly int version;

        public static implicit operator bool(Entity entity)
            => World.IsValid(entity);

        public bool Equals(Entity other)
            => other.index == index && other.version == version;

        public static bool operator ==(Entity a, Entity b)
            => a.index == b.index && a.version == b.version;

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