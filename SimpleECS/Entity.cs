namespace SimpleECS
{
    using System;

    /// <summary>
    /// Basic container of components
    /// </summary>
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

        #pragma warning disable
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

        /// <summary>
        /// When an entity sets a component, the supplied callback will be invoked
        /// </summary>
        /// <param name="callback">callback params (Entity entity, ref Component component)</param>
        /// <param name="register">Set to false to unregister the callback</param>
        public static void OnSet<Component>(Delegates.ComponentCallback<Component> callback, bool register = true)
        {
            if (register)
                SimpleECS.OnSet<Component>.Callback += callback;
            else SimpleECS.OnSet<Component>.Callback -= callback;
        }

        /// <summary>
        /// When an entity removes a component, the supplied callback will be invoked
        /// </summary>
        /// <param name="callback">callback params (Entity entity, ref Component component)</param>
        /// <param name="register">Set to false to unregister the callback</param>
        public static void OnRemove<Component>(Delegates.ComponentCallback<Component> callback, bool register = true)
        {
            if (register)
                SimpleECS.OnRemove<Component>.Callback += callback;
            else SimpleECS.OnRemove<Component>.Callback -= callback;
        } 
    }
}