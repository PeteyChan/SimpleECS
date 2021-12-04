namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Aggregates types into a unique signature
    /// </summary>
    public sealed class TypeSignature : IEquatable<TypeSignature>, IReadOnlyList<Type>
    {
        int[] type_ids;
        int type_count;

        TypeSignature(int capacity = 4)
        {
            type_ids = new int[capacity];
        }

        /// <summary>
        /// number of types that make up the signature
        /// </summary>
        public int Count => type_count;

        /// <summary>
        /// Creates a new type signature using the supplied types
        /// </summary>
        public TypeSignature(IEnumerable<Type> types)
        {
            type_ids = new int[4];
            foreach (var type in types)
                Add(type);
        }

        /// <summary>
        /// Creates a new type signature that matches the supplied type signature
        /// </summary>
        /// <param name="signature"></param>
        public TypeSignature(TypeSignature signature)
        {
            type_count = signature.type_count;
            type_ids = new int[type_count + 1];

            for (int i = 0; i < type_count; ++i)
            {
                type_ids[i] = signature.type_ids[i];
            }
        }

        /// <summary>
        /// Creates a new type signature with the supplied types
        /// </summary>
        /// <param name="types"></param>
        public TypeSignature(params Type[] types)
        {
            this.type_ids = new int[types.Length];
            foreach (var type in types)
                Add(type);
        }

        /// <summary>
        /// Create a new type signature with the same signature as the supplied archetype
        /// </summary>
        /// <param name="archetype"></param>
        public TypeSignature(Archetype archetype)
        {
            if (archetype.IsValid())
            {
                var signature = archetype.GetTypeSignature();
                type_ids = new int[signature.type_count + 1];
                this.Copy(signature);
            }
            else type_ids = new int[2];
        }

        /// <summary>
        /// Clears signature to be an empty type
        /// </summary>
        public TypeSignature Clear()
        {
            type_count = 0;
            return this;
        }

        public TypeSignature Add(params Type[] types)
        {
            foreach (var type in types)
                if (type != null)
                    Add(TypeID.Get(type));
            return this;
        }

        internal TypeSignature Add(int type_id)
        {
            for (int i = 0; i < type_count; ++i)
            {
                if (type_ids[i] == type_id) // if same exit
                    return this;

                if (type_id > type_ids[i])  // since the hash is generated from this, ordering is important
                {
                    var stored_id = type_ids[i];
                    type_ids[i] = type_id;
                    type_id = stored_id;
                }
            }

            if (type_count++ == type_ids.Length)
                Array.Resize(ref type_ids, type_count + 4);

            type_ids[type_count - 1] = type_id;
            return this;
        }

        public TypeSignature Remove(params Type[] types)
        {
            foreach (var type in types)
                if (type != null)
                    Remove(TypeID.Get(type));
            return this;
        }

        internal TypeSignature Remove(int type_id)
        {
            bool swap = type_ids[0] == type_id;
            for (int i = 1; i < type_count; ++i)
            {
                if (swap)
                    type_ids[i - 1] = type_ids[i];
                else
                    swap = type_ids[i] == type_id;
            }
            if (swap)
                type_count--;
            return this;
        }

        /// <summary>
        /// Makes this signature an exact copy of other signature
        /// </summary>
        public TypeSignature Copy(TypeSignature signature)
        {
            if (type_ids.Length < signature.type_count)
                Array.Resize(ref type_ids, signature.type_count + 1);
            for (int i = 0; i < signature.type_count; ++i)
                type_ids[i] = signature.type_ids[i];
            type_count = signature.type_count;
            return this;
        }

        /// <summary>
        /// Makes this type signature the same as the archetype's type signature
        /// </summary>
        public TypeSignature Copy(Archetype archetype)
            => this.Copy(archetype.GetTypeSignature());

        /// <summary>
        /// Adds type to the signature
        /// </summary>
        public TypeSignature Add(Type type)
            => Add(TypeID.Get(type));

        /// <summary>
        /// Adds type to the signature
        /// </summary>
        public TypeSignature Add<T>()
            => Add(TypeID<T>.Value);

        /// <summary>
        /// Removes type from signature
        /// </summary>
        public TypeSignature Remove(Type type)
            => Remove(TypeID.Get(type));

        /// <summary>
        /// Removes type from signature
        /// </summary>
        public TypeSignature Remove<T>()
            => Remove(TypeID<T>.Value);

        /// <summary>
        /// Returns true if signature has type
        /// </summary>
        public bool Has<T>() => Has(TypeID<T>.Value);

        /// <summary>
        /// Returns true if signature has type
        /// </summary>
        public bool Has(Type type) => Has(TypeID.Get(type));

        internal bool Has(int typeid)
        {
            for (int i = 0; i < type_count; ++i)
                if (type_ids[i] == typeid)
                    return true;
            return false;
        }

        /// <summary>
        /// Returns true if signatures have any types in common
        /// </summary>
        public bool HasAny(TypeSignature other)
        {
            for (int a = 0; a < type_count; ++a)
            {
                for (int b = 0; b < other.type_count; ++b)
                {
                    if (type_ids[a] == other.type_ids[b])
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns true if this signature has all types contained in the other signature
        /// </summary>
        /// <returns></returns>
        public bool HasAll(TypeSignature other)
        {
            for (int a = 0; a < other.type_count; ++a)
            {
                for (int b = 0; b < type_count; ++b)
                {
                    if (other.type_ids[a] == type_ids[b])
                        goto next;
                }
                return false;
            next:
                continue;
            }
            return true;
        }

#pragma warning disable
        public override int GetHashCode()
        {
            int prime = 53;
            int power = 1;
            int hashval = 0;

            unchecked
            {
                for (int i = 0; i < type_count; ++i)
                {
                    power *= prime;
                    hashval = (hashval + type_ids[i] * power);
                }
            }
            return hashval;
        }

        public bool Equals(TypeSignature other)
        {
            if (type_count != other.type_count)
                return false;
            for (int i = 0; i < type_count; ++i)
            {
                if (type_ids[i] != other.type_ids[i])
                    return false;
            }
            return true;
        }

        public override bool Equals(object obj)
        => obj is TypeSignature sig ? sig.Equals(this) : false;

        public override string ToString()
        {
            string sig = "Type Signature [";
            for (int i = 0; i < type_count; ++i)
            {
                var type = TypeID.Get(type_ids[i]);
                sig += $" {type.Name}";
            }
            sig += "]";

            return sig;
        }

        public string TypesToString()
        {
            string sig = "[";
            for (int i = 0; i < type_count; ++i)
            {
                var type = TypeID.Get(type_ids[i]);
                sig += $" {type.Name}";
            }
            sig += "]";

            return sig;
        }

        /// <summary>
        /// All types that currently make up this signature
        /// </summary>
        public IReadOnlyList<Type> Types => this;
        Type IReadOnlyList<Type>.this[int index] => TypeID.Get(type_ids[index]);

        IEnumerator<Type> IEnumerable<Type>.GetEnumerator()
        {
            for (int i = 0; i < type_count; ++i)
                yield return TypeID.Get(type_ids[i]);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < type_count; ++i)
                yield return TypeID.Get(type_ids[i]);
        }

        int IReadOnlyCollection<Type>.Count => type_count;
    }
}

namespace SimpleECS.Internal
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// assigns ids to types
    /// </summary>
    public static class TypeID<T>
    {
        public static readonly int Value = TypeID.Get(typeof(T));
    }

    /// <summary>
    /// assigns ids to types
    /// </summary>
    public static class TypeID    // class to map types to ids
    {
        static Dictionary<Type, int> newIDs = new Dictionary<Type, int>();
        static Type[] id_to_type = new Type[64];
        public static Type Get(int type_id) => id_to_type[type_id];

        public static int Get(Type type)
        {
            if (!newIDs.TryGetValue(type, out var id))
            {
                newIDs[type] = id = newIDs.Count + 1;
                if (id == id_to_type.Length)
                    Array.Resize(ref id_to_type, id_to_type.Length * 2);
                id_to_type[id] = type;
            }
            return id;
        }

        public static List<Type> GetAssignedTypes()
        {
            var list = new List<Type>();
            foreach (var type in newIDs)
                list.Add(type.Key);
            return list;
        }
    }
}