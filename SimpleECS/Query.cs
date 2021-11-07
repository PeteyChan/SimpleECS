using System;

namespace SimpleECS
{
    using Internal;

    /// <summary>
    /// Operates on all entities that match it's filters
    /// </summary>
    public partial class Query
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

        int[] matching_archetypes = new int[8];
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
                    archetypes[i] = world_info.archetypes[matching_archetypes[i]].data.archetype;
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
                    var index = matching_archetypes[i];
                    var archetype = world_info.archetypes;
                    for (int e = 0; e < archetype[index].data.entity_count; ++e)
                    {
                        entities[count] = archetype[index].data.entities[e];
                        count++;
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
                    var entities = archetype.entities;
                    if (archetype.entity_count > 0)
                    {
                        for (int e = 0; e < archetype.entity_count; ++e)
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
            if (world.TryGetWorldInfo(out var info))
            {
                for(int i = 0; i < archetype_count; ++ i)
                {
                    var index = matching_archetypes[i];
                    info.archetypes[i].data.archetype.Destroy();
                }
            }                
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
                        matching_archetypes[archetype_count] = last_lookup;
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
            (include.Count > 0 ? $": Has {include.TypesToString()}" : "") +
            (exclude.Count > 0 ? $": Not {exclude.TypesToString()}" : "");
        }
    }
}