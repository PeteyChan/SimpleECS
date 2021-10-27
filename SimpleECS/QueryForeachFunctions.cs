namespace SimpleECS
{
    using Delegates;
    public partial class Query
    {
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1>(in query_c1<C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1>(in query_ec1<C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1>(in query_wec1<C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1>(in query_wc1<C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2>(in query_c2<C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2>(in query_ec2<C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2>(in query_wec2<C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2>(in query_wc2<C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3>(in query_c3<C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3>(in query_ec3<C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3>(in query_wec3<C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3>(in query_wc3<C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in query_c4<C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in query_ec4<C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in query_wec4<C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in query_wc4<C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in query_c5<C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in query_ec5<C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in query_wec5<C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in query_wc5<C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in query_c6<C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in query_ec6<C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in query_wec6<C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in query_wc6<C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query_c7<C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query_ec7<C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query_wec7<C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query_wc7<C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query_c8<C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query_ec8<C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query_wec8<C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query_wc8<C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_c9<C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ec9<C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_wec9<C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_wc9<C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_c10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ec10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_wec10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_wc10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_c11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ec11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_wec11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_wc11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_c12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ec12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_wec12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_wc12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query_c13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query_ec13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query_wec13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query_wc13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query_c14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query_ec14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query_wec14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query_wc14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query_c15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query_ec15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query_wec15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query_wc15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query_c16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15) && archetype.TryGetArray(out C16[] pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query_ec16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15) && archetype.TryGetArray(out C16[] pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query_wec16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15) && archetype.TryGetArray(out C16[] pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add World in first position to access the world being queried
        /// Add Entity after world to access the current entity.
        /// Add (ref C component) to access the current entity's component, can add up to 16 components.
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query_wc16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12) && archetype.TryGetArray(out C13[] pool_c13) && archetype.TryGetArray(out C14[] pool_c14) && archetype.TryGetArray(out C15[] pool_c15) && archetype.TryGetArray(out C16[] pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(world, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
            }
            world.AllowStructuralChanges = true;
        }
    }

    namespace Delegates
    {
#pragma warning disable
        public delegate void query_c1<C1>(ref C1 c1);
        public delegate void query_ec1<C1>(Entity entity, ref C1 c1);
        public delegate void query_wec1<C1>(World world, Entity entity, ref C1 c1);
        public delegate void query_wc1<C1>(World world, ref C1 c1);
        public delegate void query_c2<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void query_ec2<C1, C2>(Entity entity, ref C1 c1, ref C2 c2);
        public delegate void query_wec2<C1, C2>(World world, Entity entity, ref C1 c1, ref C2 c2);
        public delegate void query_wc2<C1, C2>(World world, ref C1 c1, ref C2 c2);
        public delegate void query_c3<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ec3<C1, C2, C3>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_wec3<C1, C2, C3>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_wc3<C1, C2, C3>(World world, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_c4<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ec4<C1, C2, C3, C4>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_wec4<C1, C2, C3, C4>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_wc4<C1, C2, C3, C4>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_c5<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ec5<C1, C2, C3, C4, C5>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_wec5<C1, C2, C3, C4, C5>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_wc5<C1, C2, C3, C4, C5>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_c6<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ec6<C1, C2, C3, C4, C5, C6>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_wec6<C1, C2, C3, C4, C5, C6>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_wc6<C1, C2, C3, C4, C5, C6>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_c7<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ec7<C1, C2, C3, C4, C5, C6, C7>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_wec7<C1, C2, C3, C4, C5, C6, C7>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_wc7<C1, C2, C3, C4, C5, C6, C7>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_c8<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ec8<C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_wec8<C1, C2, C3, C4, C5, C6, C7, C8>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_wc8<C1, C2, C3, C4, C5, C6, C7, C8>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_c9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ec9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_wec9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_wc9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_c10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ec10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_wec10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_wc10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_c11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ec11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_wec11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_wc11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_c12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ec12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_wec12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_wc12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_c13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void query_ec13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void query_wec13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void query_wc13<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void query_c14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void query_ec14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void query_wec14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void query_wc14<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void query_c15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void query_ec15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void query_wec15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void query_wc15<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void query_c16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);
        public delegate void query_ec16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);
        public delegate void query_wec16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(World world, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);
        public delegate void query_wc16<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(World world, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);
#pragma warning restore
    }
}
