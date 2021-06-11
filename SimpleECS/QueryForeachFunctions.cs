namespace SimpleECS
{
    using Delegates;
    public partial class Query
    {
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
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
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1>(in query_w1c1<W1, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1>(in query_ew1c1<W1, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2>(in query_w1c2<W1, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2>(in query_ew1c2<W1, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3>(in query_w1c3<W1, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3>(in query_ew1c3<W1, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4>(in query_w1c4<W1, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4>(in query_ew1c4<W1, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5>(in query_w1c5<W1, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5>(in query_ew1c5<W1, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6>(in query_w1c6<W1, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6>(in query_ew1c6<W1, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7>(in query_w1c7<W1, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7>(in query_ew1c7<W1, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w1c8<W1, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew1c8<W1, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w1c9<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew1c9<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w1c10<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew1c10<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w1c11<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew1c11<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w1c12<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew1c12<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1>(in query_w2c1<W1, W2, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1>(in query_ew2c1<W1, W2, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2>(in query_w2c2<W1, W2, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2>(in query_ew2c2<W1, W2, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3>(in query_w2c3<W1, W2, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3>(in query_ew2c3<W1, W2, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4>(in query_w2c4<W1, W2, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4>(in query_ew2c4<W1, W2, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5>(in query_w2c5<W1, W2, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5>(in query_ew2c5<W1, W2, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6>(in query_w2c6<W1, W2, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6>(in query_ew2c6<W1, W2, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in query_w2c7<W1, W2, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in query_ew2c7<W1, W2, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w2c8<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew2c8<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w2c9<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew2c9<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w2c10<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew2c10<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w2c11<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew2c11<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w2c12<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew2c12<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1>(in query_w3c1<W1, W2, W3, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1>(in query_ew3c1<W1, W2, W3, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2>(in query_w3c2<W1, W2, W3, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2>(in query_ew3c2<W1, W2, W3, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3>(in query_w3c3<W1, W2, W3, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3>(in query_ew3c3<W1, W2, W3, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4>(in query_w3c4<W1, W2, W3, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4>(in query_ew3c4<W1, W2, W3, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5>(in query_w3c5<W1, W2, W3, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5>(in query_ew3c5<W1, W2, W3, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in query_w3c6<W1, W2, W3, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in query_ew3c6<W1, W2, W3, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in query_w3c7<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in query_ew3c7<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w3c8<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew3c8<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w3c9<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew3c9<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w3c10<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew3c10<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w3c11<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew3c11<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w3c12<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew3c12<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1>(in query_w4c1<W1, W2, W3, W4, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1>(in query_ew4c1<W1, W2, W3, W4, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2>(in query_w4c2<W1, W2, W3, W4, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2>(in query_ew4c2<W1, W2, W3, W4, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3>(in query_w4c3<W1, W2, W3, W4, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3>(in query_ew4c3<W1, W2, W3, W4, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4>(in query_w4c4<W1, W2, W3, W4, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4>(in query_ew4c4<W1, W2, W3, W4, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in query_w4c5<W1, W2, W3, W4, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in query_ew4c5<W1, W2, W3, W4, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in query_w4c6<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in query_ew4c6<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in query_w4c7<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in query_ew4c7<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w4c8<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew4c8<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w4c9<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew4c9<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w4c10<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew4c10<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w4c11<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew4c11<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w4c12<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew4c12<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1>(in query_w5c1<W1, W2, W3, W4, W5, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1>(in query_ew5c1<W1, W2, W3, W4, W5, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2>(in query_w5c2<W1, W2, W3, W4, W5, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2>(in query_ew5c2<W1, W2, W3, W4, W5, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3>(in query_w5c3<W1, W2, W3, W4, W5, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3>(in query_ew5c3<W1, W2, W3, W4, W5, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4>(in query_w5c4<W1, W2, W3, W4, W5, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4>(in query_ew5c4<W1, W2, W3, W4, W5, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5>(in query_w5c5<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5>(in query_ew5c5<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6>(in query_w5c6<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6>(in query_ew5c6<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7>(in query_w5c7<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7>(in query_ew5c7<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w5c8<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew5c8<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w5c9<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew5c9<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w5c10<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew5c10<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w5c11<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew5c11<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w5c12<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew5c12<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1>(in query_w6c1<W1, W2, W3, W4, W5, W6, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1>(in query_ew6c1<W1, W2, W3, W4, W5, W6, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2>(in query_w6c2<W1, W2, W3, W4, W5, W6, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2>(in query_ew6c2<W1, W2, W3, W4, W5, W6, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3>(in query_w6c3<W1, W2, W3, W4, W5, W6, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3>(in query_ew6c3<W1, W2, W3, W4, W5, W6, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4>(in query_w6c4<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4>(in query_ew6c4<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5>(in query_w6c5<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5>(in query_ew6c5<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6>(in query_w6c6<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6>(in query_ew6c6<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7>(in query_w6c7<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7>(in query_ew6c7<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w6c8<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew6c8<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w6c9<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew6c9<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w6c10<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew6c10<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w6c11<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew6c11<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w6c12<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew6c12<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1>(in query_w7c1<W1, W2, W3, W4, W5, W6, W7, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1>(in query_ew7c1<W1, W2, W3, W4, W5, W6, W7, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2>(in query_w7c2<W1, W2, W3, W4, W5, W6, W7, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2>(in query_ew7c2<W1, W2, W3, W4, W5, W6, W7, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3>(in query_w7c3<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3>(in query_ew7c3<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4>(in query_w7c4<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4>(in query_ew7c4<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5>(in query_w7c5<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5>(in query_ew7c5<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6>(in query_w7c6<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6>(in query_ew7c6<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7>(in query_w7c7<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7>(in query_ew7c7<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w7c8<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew7c8<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w7c9<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew7c9<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w7c10<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew7c10<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w7c11<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew7c11<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w7c12<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew7c12<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1>(in query_w8c1<W1, W2, W3, W4, W5, W6, W7, W8, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1>(in query_ew8c1<W1, W2, W3, W4, W5, W6, W7, W8, C1> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2>(in query_w8c2<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2>(in query_ew8c2<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3>(in query_w8c3<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3>(in query_ew8c3<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4>(in query_w8c4<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4>(in query_ew8c4<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5>(in query_w8c5<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5>(in query_ew8c5<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6>(in query_w8c6<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6>(in query_ew8c6<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7>(in query_w8c7<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7>(in query_ew8c7<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8>(in query_w8c8<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8>(in query_ew8c8<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_w8c9<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query_ew8c9<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_w8c10<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query_ew8c10<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_w8c11<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query_ew8c11<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_w8c12<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
        /// <summary>
        /// Iterates over entities that matches query.
        /// Add Entity in First position to access Entity.
        /// Add (in W world_data) to access world data, can add up to 8 world data.
        /// Add (ref C component) to access entity components, can add up to 12 components.
        /// </summary>
        public void Foreach<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query_ew8c12<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> query)
        {
            Update();
            if (archetype_count == 0) return;
            world.AllowStructuralChanges = false;
            ref var d1 = ref world.GetData<W1>();
            ref var d2 = ref world.GetData<W2>();
            ref var d3 = ref world.GetData<W3>();
            ref var d4 = ref world.GetData<W4>();
            ref var d5 = ref world.GetData<W5>();
            ref var d6 = ref world.GetData<W6>();
            ref var d7 = ref world.GetData<W7>();
            ref var d8 = ref world.GetData<W8>();

            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray(out C1[] pool_c1) && archetype.TryGetArray(out C2[] pool_c2) && archetype.TryGetArray(out C3[] pool_c3) && archetype.TryGetArray(out C4[] pool_c4) && archetype.TryGetArray(out C5[] pool_c5) && archetype.TryGetArray(out C6[] pool_c6) && archetype.TryGetArray(out C7[] pool_c7) && archetype.TryGetArray(out C8[] pool_c8) && archetype.TryGetArray(out C9[] pool_c9) && archetype.TryGetArray(out C10[] pool_c10) && archetype.TryGetArray(out C11[] pool_c11) && archetype.TryGetArray(out C12[] pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        query(archetype.entity_pool[e], d1, d2, d3, d4, d5, d6, d7, d8, ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
            }
            world.AllowStructuralChanges = true;
        }
    }

    namespace Delegates
    {
        public delegate void query_c1<C1>(ref C1 c1);
        public delegate void query_ec1<C1>(Entity entity, ref C1 c1);
        public delegate void query_c2<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void query_ec2<C1, C2>(Entity entity, ref C1 c1, ref C2 c2);
        public delegate void query_c3<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ec3<C1, C2, C3>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_c4<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ec4<C1, C2, C3, C4>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_c5<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ec5<C1, C2, C3, C4, C5>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_c6<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ec6<C1, C2, C3, C4, C5, C6>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_c7<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ec7<C1, C2, C3, C4, C5, C6, C7>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_c8<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ec8<C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_c9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ec9<C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_c10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ec10<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_c11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ec11<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_c12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ec12<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w1c1<W1, C1>(in W1 w1, ref C1 c1);
        public delegate void query_ew1c1<W1, C1>(Entity entity, in W1 w1, ref C1 c1);
        public delegate void query_w1c2<W1, C1, C2>(in W1 w1, ref C1 c1, ref C2 c2);
        public delegate void query_ew1c2<W1, C1, C2>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2);
        public delegate void query_w1c3<W1, C1, C2, C3>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew1c3<W1, C1, C2, C3>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w1c4<W1, C1, C2, C3, C4>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew1c4<W1, C1, C2, C3, C4>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w1c5<W1, C1, C2, C3, C4, C5>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew1c5<W1, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w1c6<W1, C1, C2, C3, C4, C5, C6>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew1c6<W1, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w1c7<W1, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew1c7<W1, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w1c8<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew1c8<W1, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w1c9<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew1c9<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w1c10<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew1c10<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w1c11<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew1c11<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w1c12<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew1c12<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w2c1<W1, W2, C1>(in W1 w1, in W2 w2, ref C1 c1);
        public delegate void query_ew2c1<W1, W2, C1>(Entity entity, in W1 w1, in W2 w2, ref C1 c1);
        public delegate void query_w2c2<W1, W2, C1, C2>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2);
        public delegate void query_ew2c2<W1, W2, C1, C2>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2);
        public delegate void query_w2c3<W1, W2, C1, C2, C3>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew2c3<W1, W2, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w2c4<W1, W2, C1, C2, C3, C4>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew2c4<W1, W2, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w2c5<W1, W2, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew2c5<W1, W2, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w2c6<W1, W2, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew2c6<W1, W2, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w2c7<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew2c7<W1, W2, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w2c8<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew2c8<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w2c9<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew2c9<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w2c10<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew2c10<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w2c11<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew2c11<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w2c12<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew2c12<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w3c1<W1, W2, W3, C1>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1);
        public delegate void query_ew3c1<W1, W2, W3, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1);
        public delegate void query_w3c2<W1, W2, W3, C1, C2>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2);
        public delegate void query_ew3c2<W1, W2, W3, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2);
        public delegate void query_w3c3<W1, W2, W3, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew3c3<W1, W2, W3, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w3c4<W1, W2, W3, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew3c4<W1, W2, W3, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w3c5<W1, W2, W3, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew3c5<W1, W2, W3, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w3c6<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew3c6<W1, W2, W3, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w3c7<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew3c7<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w3c8<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew3c8<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w3c9<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew3c9<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w3c10<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew3c10<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w3c11<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew3c11<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w3c12<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew3c12<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w4c1<W1, W2, W3, W4, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1);
        public delegate void query_ew4c1<W1, W2, W3, W4, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1);
        public delegate void query_w4c2<W1, W2, W3, W4, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2);
        public delegate void query_ew4c2<W1, W2, W3, W4, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2);
        public delegate void query_w4c3<W1, W2, W3, W4, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew4c3<W1, W2, W3, W4, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w4c4<W1, W2, W3, W4, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew4c4<W1, W2, W3, W4, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w4c5<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew4c5<W1, W2, W3, W4, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w4c6<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew4c6<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w4c7<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew4c7<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w4c8<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew4c8<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w4c9<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew4c9<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w4c10<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew4c10<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w4c11<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew4c11<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w4c12<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew4c12<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w5c1<W1, W2, W3, W4, W5, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1);
        public delegate void query_ew5c1<W1, W2, W3, W4, W5, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1);
        public delegate void query_w5c2<W1, W2, W3, W4, W5, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2);
        public delegate void query_ew5c2<W1, W2, W3, W4, W5, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2);
        public delegate void query_w5c3<W1, W2, W3, W4, W5, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew5c3<W1, W2, W3, W4, W5, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w5c4<W1, W2, W3, W4, W5, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew5c4<W1, W2, W3, W4, W5, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w5c5<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew5c5<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w5c6<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew5c6<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w5c7<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew5c7<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w5c8<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew5c8<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w5c9<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew5c9<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w5c10<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew5c10<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w5c11<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew5c11<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w5c12<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew5c12<W1, W2, W3, W4, W5, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w6c1<W1, W2, W3, W4, W5, W6, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1);
        public delegate void query_ew6c1<W1, W2, W3, W4, W5, W6, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1);
        public delegate void query_w6c2<W1, W2, W3, W4, W5, W6, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2);
        public delegate void query_ew6c2<W1, W2, W3, W4, W5, W6, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2);
        public delegate void query_w6c3<W1, W2, W3, W4, W5, W6, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew6c3<W1, W2, W3, W4, W5, W6, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w6c4<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew6c4<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w6c5<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew6c5<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w6c6<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew6c6<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w6c7<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew6c7<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w6c8<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew6c8<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w6c9<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew6c9<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w6c10<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew6c10<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w6c11<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew6c11<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w6c12<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew6c12<W1, W2, W3, W4, W5, W6, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w7c1<W1, W2, W3, W4, W5, W6, W7, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1);
        public delegate void query_ew7c1<W1, W2, W3, W4, W5, W6, W7, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1);
        public delegate void query_w7c2<W1, W2, W3, W4, W5, W6, W7, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2);
        public delegate void query_ew7c2<W1, W2, W3, W4, W5, W6, W7, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2);
        public delegate void query_w7c3<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew7c3<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w7c4<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew7c4<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w7c5<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew7c5<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w7c6<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew7c6<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w7c7<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew7c7<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w7c8<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew7c8<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w7c9<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew7c9<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w7c10<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew7c10<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w7c11<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew7c11<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w7c12<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew7c12<W1, W2, W3, W4, W5, W6, W7, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_w8c1<W1, W2, W3, W4, W5, W6, W7, W8, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1);
        public delegate void query_ew8c1<W1, W2, W3, W4, W5, W6, W7, W8, C1>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1);
        public delegate void query_w8c2<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2);
        public delegate void query_ew8c2<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2);
        public delegate void query_w8c3<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_ew8c3<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query_w8c4<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_ew8c4<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query_w8c5<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_ew8c5<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query_w8c6<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_ew8c6<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query_w8c7<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_ew8c7<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query_w8c8<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_ew8c8<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query_w8c9<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_ew8c9<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query_w8c10<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_ew8c10<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query_w8c11<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_ew8c11<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query_w8c12<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query_ew8c12<W1, W2, W3, W4, W5, W6, W7, W8, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, in W1 w1, in W2 w2, in W3 w3, in W4 w4, in W5 w5, in W6 w6, in W7 w7, in W8 w8, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
    }
}
