namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Allows for efficient filtering and iterating of entities and their components
    /// </summary>
    public partial class Query : IReadOnlyList<Archetype>, IEnumerable<Entity>
    {
        /// <summary>
        /// Types archetypes need to have to pass the filter
        /// </summary>
        public IReadOnlyList<Type> HasTypes => has;
        /// <summary>
        /// Types archetypes cannot have to pass the filter
        /// </summary>
        public IReadOnlyList<Type> NotTypes => not;
        Archetype[] matching_archetypes = new Archetype[8];
        /// <summary>
        /// Archetypes currently matching query's filter
        /// </summary>
        public IReadOnlyList<Archetype> MatchingArchetypes => this;
        /// <summary>
        /// Entities currently matching queries's filter
        /// </summary>
        public IEnumerable<Entity> MatchingEntities => this;

        TypeSignature has = new TypeSignature();
        TypeSignature not = new TypeSignature();
        int current_archetype_index; // index of last archetype in world that we checked for a match
        int current_version;
        int archetype_count;    // number of matching archetypes

        /// <summary>
        /// Current count of entities matching the query
        /// </summary>
        public int EntityCount 
        {
            get
            {
                Update();
                int count = 0;
                for (int i = archetype_count - 1; i >= 0; --i)
                    count += matching_archetypes[i].entity_count;
                return count;
            }
        }

        /// <summary>
        /// Filters entities to those that have component
        /// </summary>
        public Query Has<T>()
        {
            current_archetype_index = 0;
            archetype_count = 0;
            has.Add<T>();
            return this;
        }

        /// <summary>
        /// Filters entities to those without component
        /// </summary>
        public Query Not<T>()
        {
            current_archetype_index = 0;
            archetype_count = 0;
            not.Add<T>();
            return this;
        }
        
        /// <summary>
        /// Clears the query's current filters and matches
        /// </summary>
        public Query Clear()
        {
            has.Clear();
            not.Clear();
            for (int i = 0; i < archetype_count; ++i)
                matching_archetypes[i] = default;
            current_archetype_index = 0;
            archetype_count = 0;
            return this;
        }
        
        #pragma warning disable
        public override string ToString()
        {
            Update();

            var name = "Query ";
            if (has.type_count > 0)
            {
                name += "[ HAS: ";

                foreach (var type in has.Types)
                    name += type.Name;
                name += " ] ";
            }
            if (not.type_count > 0)
            {
                name += "[ NOT: ";
                foreach (var type in not.Types)
                    name += type.Name;
                name += " ]";
            }
            if (has.type_count == 0 && not.type_count == 0)
                name += "ALL";

            return $"{name}";
        }

        void Update() // checks for any new archetypes since last run and updates accordingly
        {
            
            if (World.Version > current_version) // check to see if world's version changed, if so need to update
            {
                for(int i = archetype_count-1; i>= 0; --i)
                    matching_archetypes[i] = default;

                current_version = World.Version;
                current_archetype_index = 0;
                archetype_count = 0;
            }

            if (current_archetype_index < World.Archetypes.Count)  // check for any new archetypes
            {
                for (int i = current_archetype_index; i < World.Archetypes.Count; ++i)
                {
                    var archetype = World.Archetypes[i];
                    
                    if (!archetype.signature.HasAll(has))
                        goto next_archetype;

                    if (archetype.signature.HasAny(not))
                        goto next_archetype;

                    if (archetype_count == matching_archetypes.Length)
                        Array.Resize(ref matching_archetypes, matching_archetypes.Length * 2);
                    matching_archetypes[archetype_count] = archetype;
                    archetype_count++;

                next_archetype:
                    continue;
                }
                current_archetype_index = World.Archetypes.Count;
            }
        }

        IEnumerator<Entity> IEnumerable<Entity>.GetEnumerator()
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    yield return archetype.entity_pool[itr];
            }
        }

        IEnumerator<Archetype> IEnumerable<Archetype>.GetEnumerator()
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
                yield return matching_archetypes[i];
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int itr = archetype.entity_count - 1; itr >= 0; --itr)
                    yield return archetype.entity_pool[itr];
            }
        }
        int IReadOnlyCollection<Archetype>.Count
        {
            get
            {
                Update();
                return archetype_count;
            }
        }

        Archetype IReadOnlyList<Archetype>.this[int index] => matching_archetypes[index];
    }
}