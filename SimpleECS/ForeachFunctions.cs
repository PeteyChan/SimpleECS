namespace SimpleECS
{
    using Delegates;

    public partial class Query
    {
        /// <summary>
        /// Allows iteration of components in query, can add up to 16 components
        /// </summary>
        public void Foreach<C1>(in query<C1> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2>(in query<C1, C2> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3>(in query<C1, C2, C3> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4>(in query<C1, C2, C3, C4> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5>(in query<C1, C2, C3, C4, C5> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in query<C1, C2, C3, C4, C5, C6> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14) && archetype.TryGetPool<C15>(out var pool_c15))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e], ref pool_c15.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14) && archetype.TryGetPool<C15>(out var pool_c15) && archetype.TryGetPool<C16>(out var pool_c16))
                    for (int e = archetype.entity_count; e >= 0; --e)
                        action(ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e], ref pool_c15.Values[e], ref pool_c16.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach(in entity_query action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                for (int e = archetype.entity_count - 1; e >= 0; --e)
                    action(archetype.entity_pool.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1>(in entity_query<C1> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2>(in entity_query<C1, C2> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3>(in entity_query<C1, C2, C3> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4>(in entity_query<C1, C2, C3, C4> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5>(in entity_query<C1, C2, C3, C4, C5> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in entity_query<C1, C2, C3, C4, C5, C6> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in entity_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14) && archetype.TryGetPool<C15>(out var pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e], ref pool_c15.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetPool<C1>(out var pool_c1) && archetype.TryGetPool<C2>(out var pool_c2) && archetype.TryGetPool<C3>(out var pool_c3) && archetype.TryGetPool<C4>(out var pool_c4) && archetype.TryGetPool<C5>(out var pool_c5) && archetype.TryGetPool<C6>(out var pool_c6) && archetype.TryGetPool<C7>(out var pool_c7) && archetype.TryGetPool<C8>(out var pool_c8) && archetype.TryGetPool<C9>(out var pool_c9) && archetype.TryGetPool<C10>(out var pool_c10) && archetype.TryGetPool<C11>(out var pool_c11) && archetype.TryGetPool<C12>(out var pool_c12) && archetype.TryGetPool<C13>(out var pool_c13) && archetype.TryGetPool<C14>(out var pool_c14) && archetype.TryGetPool<C15>(out var pool_c15) && archetype.TryGetPool<C16>(out var pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool.Values[e], ref pool_c1.Values[e], ref pool_c2.Values[e], ref pool_c3.Values[e], ref pool_c4.Values[e], ref pool_c5.Values[e], ref pool_c6.Values[e], ref pool_c7.Values[e], ref pool_c8.Values[e], ref pool_c9.Values[e], ref pool_c10.Values[e], ref pool_c11.Values[e], ref pool_c12.Values[e], ref pool_c13.Values[e], ref pool_c14.Values[e], ref pool_c15.Values[e], ref pool_c16.Values[e]);
            }
            World.AllowStructuralChanges = true;
        }

    }

    public partial class Archetype
    {
        public void Foreach(in entity_query action)
        {
            if (entity_count > 0)
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i]);
            }
        }
        public void Foreach<C1>(in query<C1> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i]);
            }
        }

        public void Foreach<C1, C2>(in query<C1, C2> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3>(in query<C1, C2, C3> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4>(in query<C1, C2, C3, C4> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5>(in query<C1, C2, C3, C4, C5> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in query<C1, C2, C3, C4, C5, C6> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13) && TryGetPool<C14>(out var pool_c14))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i], ref pool_c14.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13) && TryGetPool<C14>(out var pool_c14) && TryGetPool<C15>(out var pool_c15))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i], ref pool_c14.Values[i], ref pool_c15.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13) && TryGetPool<C14>(out var pool_c14) && TryGetPool<C15>(out var pool_c15) && TryGetPool<C16>(out var pool_c16))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i], ref pool_c14.Values[i], ref pool_c15.Values[i], ref pool_c16.Values[i]);
            }
        }

        public void Foreach<C1>(in entity_query<C1> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i]);
            }
        }

        public void Foreach<C1, C2>(in entity_query<C1, C2> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3>(in entity_query<C1, C2, C3> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4>(in entity_query<C1, C2, C3, C4> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5>(in entity_query<C1, C2, C3, C4, C5> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in entity_query<C1, C2, C3, C4, C5, C6> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in entity_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13) && TryGetPool<C14>(out var pool_c14))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i], ref pool_c14.Values[i]);
            }
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12) && TryGetPool<C13>(out var pool_c13) && TryGetPool<C14>(out var pool_c14) && TryGetPool<C15>(out var pool_c15))
            {
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i], ref pool_c13.Values[i], ref pool_c14.Values[i], ref pool_c15.Values[i]);
            }
        }

    }
    namespace Delegates
    {
        public delegate void query<C1>(ref C1 c1);
        public delegate void query<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void query<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);

        public delegate void entity_query(Entity entity);
        public delegate void entity_query<C1>(Entity entity, ref C1 c1);
        public delegate void entity_query<C1, C2>(Entity entity, ref C1 c1, ref C2 c2);
        public delegate void entity_query<C1, C2, C3>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void entity_query<C1, C2, C3, C4>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void entity_query<C1, C2, C3, C4, C5>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12, ref C13 c13, ref C14 c14, ref C15 c15, ref C16 c16);
    }
}
