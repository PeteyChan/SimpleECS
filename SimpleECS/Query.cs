
namespace SimpleECS
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Internal;

    /// <summary>
    /// Operates on all entities that match it's filters
    /// </summary>
    public partial class Query : IEnumerable<Archetype>
    {
        public Query() { }

        public Query(World world)
        {
            this.world = world;
        }

        World world;

        /// <summary>
        /// the world the query operates on
        /// </summary>
        public World World
        {
            get => world;
            set
            {
                structure_update = -1;
                world = value;
            }
        }

        public static implicit operator bool(Query query) => query == null ? false : query.world;

        TypeSignature include = new TypeSignature(), exclude = new TypeSignature();

        Archetype[] matching_archetypes = new Archetype[8];
        int last_lookup, structure_update, archetype_count;


        /// <summary>
        /// Returns a copy of all archetypes matching the query
        /// </summary>
        public Archetype[] GetArchetypes()
        {
            if (Update(out World_Info world_info))
            {
                Archetype[] archetypes = new Archetype[archetype_count];
                for (int i = 0; i < archetype_count; ++i)
                    archetypes[i] = matching_archetypes[i];
                return archetypes;
            }
            return new Archetype[0];
        }

        /// <summary>
        /// Returns a copy of all entities matching the query
        /// </summary>
        public Entity[] GetEntities()
        {
            if (Update(out var world_info))
            {
                Entity[] entities = new Entity[EntityCount];
                int count = 0;
                for (int i = 0; i < archetype_count; ++i)
                {
                    if (matching_archetypes[i].TryGetArchetypeInfo(out var arch_info))
                    {
                        for (int e = 0; e < arch_info.entity_count; ++e)
                        {
                            entities[count] = arch_info.entities[e];
                            count++;
                        }
                    }
                }
                return entities;
            }
            return new Entity[0];
        }

        /// <summary>
        /// filters entities to those that have component
        /// </summary>
        public Query Has<T>()
        {
            archetype_count = 0;
            structure_update = -1;
            include.Add<T>();
            return this;
        }


        /// <summary>
        /// filters entities to those that do not have component
        /// </summary>
        public Query Not<T>()
        {
            archetype_count = 0;
            structure_update = -1;
            exclude.Add<T>();
            return this;
        }

        /// <summary>
        /// filters entities to those that have components
        /// </summary>
        public Query Has(params Type[] types)
        {
            archetype_count = 0;
            structure_update = -1;
            include.Add(types);
            return this;
        }

        /// <summary>
        /// filters entities to those that do not have components
        /// </summary>
        public Query Not(params Type[] types)
        {
            archetype_count = 0;
            structure_update = -1;
            exclude.Add(types);
            return this;
        }

        /// <summary>
        /// filters entities to those that have components
        /// </summary>
        public Query Has(IEnumerable<Type> types)
        {
            if (types != null)
                foreach (var type in types)
                    Has(type);
            return this;
        }

        /// <summary>
        /// filters entities to those that do not have components
        /// </summary>
        public Query Not(IEnumerable<Type> types)
        {
            if (types != null)
                foreach (var type in types)
                    Not(type);
            return this;
        }

        /// <summary>
        /// clears all previous filters on the query
        /// </summary>
        public Query Clear()
        {
            include.Clear();
            exclude.Clear();
            archetype_count = 0;
            structure_update = -1;
            return this;
        }

        /// <summary>
        /// iterates and peforms action on all entities that match the query
        /// </summary>
        public void Foreach(in Action<Entity> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0)
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }

        /// <summary>
        /// Destroys matching archetypes along with their entities.
        /// Most efficient way to destroy entities.
        /// </summary>
        public void DestroyMatching()
        {
            if (Update(out var world_info))
                foreach (var archetype in GetArchetypes()) // using a copy is safer
                    archetype.Destroy();
        }

        // keeps the queried archtypes up to date, return false if the query is not valid
        bool Update(out World_Info world_info)
        {
            if (world.TryGetWorldInfo(out world_info))
            {
                if (world_info.archetype_structure_update_count != structure_update)
                {
                    last_lookup = 0;
                    archetype_count = 0;
                    structure_update = world_info.archetype_structure_update_count;
                }
                for (; last_lookup < world_info.archetype_terminating_index; ++last_lookup)
                {
                    var arch = world_info.archetypes[last_lookup].data;
                    if (arch == null) continue;
                    if (arch.signature.HasAll(include) && !arch.signature.HasAny(exclude))
                    {
                        if (archetype_count == matching_archetypes.Length)
                            System.Array.Resize(ref matching_archetypes, archetype_count * 2);
                        matching_archetypes[archetype_count] = arch.archetype;
                        ++archetype_count;
                    }
                }
                return true;
            }
            structure_update = -1;
            archetype_count = 0;
            return false;
        }

        /// <summary>
        /// the total number of entities that currently match the query
        /// </summary>
        /// <value></value>
        public int EntityCount
        {
            get
            {
                int count = 0;
                if (Update(out var world_Info))
                    for (int i = 0; i < archetype_count; ++i)
                        count += world_Info.archetypes[matching_archetypes[i]].data.entity_count;
                return count;
            }
        }

        public override string ToString()
        {
            return "Query" +
            (include.Count > 0 ? $" -> Has {include.TypesToString()}" : "") +
            (exclude.Count > 0 ? $" -> Not {exclude.TypesToString()}" : "");
        }

        /// <summary>
        /// returns all the types in the queries' has filter
        /// </summary>
        public IReadOnlyList<Type> GetHasFilterTypes() => include.Types;

        /// <summary>
        /// returns all the types in the queries' not filter
        /// </summary>
        public IReadOnlyList<Type> GetNotFilterTypes() => exclude.Types;


        IEnumerator<Archetype> IEnumerable<Archetype>.GetEnumerator()
        {
            if (Update(out var info))
            {
                for (int i = 0; i < archetype_count; ++i)
                {
                    yield return info.archetypes[matching_archetypes[i]].data.archetype;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            if (Update(out var info))
            {
                for (int i = 0; i < archetype_count; ++i)
                {
                    yield return info.archetypes[matching_archetypes[i]].data.archetype;
                }
            }
        }
    }
}