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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e]);
            }
            World.AllowStructuralChanges = true;
        }
        
        #pragma warning disable
        public void Foreach<C1, C2>(in query<C1, C2> action)
        {
            Update();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
            {
                var archetype = matching_archetypes[i];
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14) && archetype.TryGetArray<C15>(out var pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14) && archetype.TryGetArray<C15>(out var pool_c15) && archetype.TryGetArray<C16>(out var pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
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
                    action(archetype.entity_pool[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14) && archetype.TryGetArray<C15>(out var pool_c15))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e]);
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
                if (archetype.entity_count > 0 && archetype.TryGetArray<C1>(out var pool_c1) && archetype.TryGetArray<C2>(out var pool_c2) && archetype.TryGetArray<C3>(out var pool_c3) && archetype.TryGetArray<C4>(out var pool_c4) && archetype.TryGetArray<C5>(out var pool_c5) && archetype.TryGetArray<C6>(out var pool_c6) && archetype.TryGetArray<C7>(out var pool_c7) && archetype.TryGetArray<C8>(out var pool_c8) && archetype.TryGetArray<C9>(out var pool_c9) && archetype.TryGetArray<C10>(out var pool_c10) && archetype.TryGetArray<C11>(out var pool_c11) && archetype.TryGetArray<C12>(out var pool_c12) && archetype.TryGetArray<C13>(out var pool_c13) && archetype.TryGetArray<C14>(out var pool_c14) && archetype.TryGetArray<C15>(out var pool_c15) && archetype.TryGetArray<C16>(out var pool_c16))
                    for (int e = archetype.entity_count - 1; e >= 0; --e)
                        action(archetype.entity_pool[e], ref pool_c1[e], ref pool_c2[e], ref pool_c3[e], ref pool_c4[e], ref pool_c5[e], ref pool_c6[e], ref pool_c7[e], ref pool_c8[e], ref pool_c9[e], ref pool_c10[e], ref pool_c11[e], ref pool_c12[e], ref pool_c13[e], ref pool_c14[e], ref pool_c15[e], ref pool_c16[e]);
            }
            World.AllowStructuralChanges = true;
        }

    }

    public partial class Archetype
    {
        public void Foreach(in entity_query action)
        {
            if (entity_count > 0)
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i]);
        }
        public void Foreach<C1>(in query<C1> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i]);
        }

        public void Foreach<C1, C2>(in query<C1, C2> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i]);
        }

        public void Foreach<C1, C2, C3>(in query<C1, C2, C3> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i]);
        }

        public void Foreach<C1, C2, C3, C4>(in query<C1, C2, C3, C4> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5>(in query<C1, C2, C3, C4, C5> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in query<C1, C2, C3, C4, C5, C6> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13) && TryGetArray<C14>(out var pool_c14))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i], ref pool_c14[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13) && TryGetArray<C14>(out var pool_c14) && TryGetArray<C15>(out var pool_c15))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i], ref pool_c14[i], ref pool_c15[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13) && TryGetArray<C14>(out var pool_c14) && TryGetArray<C15>(out var pool_c15) && TryGetArray<C16>(out var pool_c16))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i], ref pool_c14[i], ref pool_c15[i], ref pool_c16[i]);
        }

        public void Foreach<C1>(in entity_query<C1> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i]);
        }

        public void Foreach<C1, C2>(in entity_query<C1, C2> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i]);
        }

        public void Foreach<C1, C2, C3>(in entity_query<C1, C2, C3> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i]);
        }

        public void Foreach<C1, C2, C3, C4>(in entity_query<C1, C2, C3, C4> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5>(in entity_query<C1, C2, C3, C4, C5> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in entity_query<C1, C2, C3, C4, C5, C6> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in entity_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13) && TryGetArray<C14>(out var pool_c14))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i], ref pool_c14[i]);
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15> action)
        {
            if (entity_count > 0 && TryGetArray<C1>(out var pool_c1) && TryGetArray<C2>(out var pool_c2) && TryGetArray<C3>(out var pool_c3) && TryGetArray<C4>(out var pool_c4) && TryGetArray<C5>(out var pool_c5) && TryGetArray<C6>(out var pool_c6) && TryGetArray<C7>(out var pool_c7) && TryGetArray<C8>(out var pool_c8) && TryGetArray<C9>(out var pool_c9) && TryGetArray<C10>(out var pool_c10) && TryGetArray<C11>(out var pool_c11) && TryGetArray<C12>(out var pool_c12) && TryGetArray<C13>(out var pool_c13) && TryGetArray<C14>(out var pool_c14) && TryGetArray<C15>(out var pool_c15))
                for (int i = entity_count - 1; i >= 0; --i)
                    action(entity_pool[i], ref pool_c1[i], ref pool_c2[i], ref pool_c3[i], ref pool_c4[i], ref pool_c5[i], ref pool_c6[i], ref pool_c7[i], ref pool_c8[i], ref pool_c9[i], ref pool_c10[i], ref pool_c11[i], ref pool_c12[i], ref pool_c13[i], ref pool_c14[i], ref pool_c15[i]);
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
