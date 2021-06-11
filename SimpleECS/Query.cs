namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Delegates;
    
    /// <summary>
    /// Allows for efficient filtering and iterating of entities and their components
    /// </summary>
    public sealed partial class Query : IReadOnlyList<World.Archetype>, IEnumerable<Entity>   // queries iterate backwards because for some reason it does so faster
    {
        /// <summary>
        /// Creates new Query
        /// </summary>
        /// <param name="world">The world the query operates on</param>
        public Query(World world)
        {
            this.world = world;
        }
        World world;
        /// <summary>
        /// Types archetypes need to have to pass the filter
        /// </summary>
        public IReadOnlyList<Type> HasTypes => has;
        /// <summary>
        /// Types archetypes cannot have to pass the filter
        /// </summary>
        public IReadOnlyList<Type> NotTypes => not;
        World.Archetype[] matching_archetypes = new World.Archetype[8];
        /// <summary>
        /// Archetypes currently matching query's filter
        /// </summary>
        public IReadOnlyList<World.Archetype> MatchingArchetypes => this;
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

        /// <summary>
        /// Gets first entity that matches query
        /// Returns false if query is empty
        /// </summary>
        public bool TryGetFirstEntity(out Entity entity) // because iteration is backwards, the first entity is the last one
        {
            Update();
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count == 0) continue;
                entity = archetype.entity_pool[archetype.entity_count - 1];
                return true;
            }
            entity = default;
            return false;
        }

        /// <summary>
        /// Gets last entity that matches query.
        /// Returns false if query is empty
        /// </summary>
        public bool TryGetLastEntity(out Entity entity) // because iteration is backwards, the first entity is last
        {
            Update();
            for (int i = 0; i < archetype_count; ++i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count == 0) continue;
                entity = archetype.entity_pool[0];
                return true;
            }
            entity = default;
            return false;
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

            if (world.Version > current_version) // check to see if world's version changed, if so need to update
            {
                for (int i = archetype_count - 1; i >= 0; --i)
                    matching_archetypes[i] = default;

                current_version = world.Version;
                current_archetype_index = 0;
                archetype_count = 0;
            }

            if (current_archetype_index < world.Archetypes.Count)  // check for any new archetypes
            {
                for (int i = current_archetype_index; i < world.Archetypes.Count; ++i)
                {
                    var archetype = world.Archetypes[i];

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
                current_archetype_index = world.Archetypes.Count;
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

        IEnumerator<World.Archetype> IEnumerable<World.Archetype>.GetEnumerator()
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
        int IReadOnlyCollection<World.Archetype>.Count
        {
            get
            {
                Update();
                return archetype_count;
            }
        }

        World.Archetype IReadOnlyList<World.Archetype>.this[int index] => matching_archetypes[index];

        /// <summary>
        /// Iterates over entities that matches query.
        /// </summary>
        public void Foreach(in query_e action)
        {
            Update();
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int e = archetype.entity_count - 1; e >= 0; --e)
                    action(archetype.entity_pool[e]);
            }
            world.AllowStructuralChanges = true;
        }
    }

    namespace Delegates
    {
        public delegate void query_e(Entity entity);
    }
}