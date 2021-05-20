namespace SimpleECS
{
    using SimpleECS.Internal;
    public partial class Query
    {
        public void Foreach(in entity_query action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }
        public void Foreach<C1>(in query<C1> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1>(in entity_query<C1> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2>(in query<C1, C2> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2>(in entity_query<C1, C2> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3>(in query<C1, C2, C3> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3>(in entity_query<C1, C2, C3> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4>(in query<C1, C2, C3, C4> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4>(in entity_query<C1, C2, C3, C4> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5>(in query<C1, C2, C3, C4, C5> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5>(in entity_query<C1, C2, C3, C4, C5> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in query<C1, C2, C3, C4, C5, C6> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6>(in entity_query<C1, C2, C3, C4, C5, C6> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in entity_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            Refresh();
            World.AllowStructuralChanges = false;
            for (int i = archetype_count - 1; i >= 0; --i)
                matching_archetypes[i].Foreach(action);
            World.AllowStructuralChanges = true;
        }

    }
    namespace Internal
    {
        public delegate void entity_query(in Entity entity);
        public delegate void query<C1>(ref C1 c1);
        public delegate void entity_query<C1>(in Entity entity, ref C1 c1);
        public delegate void query<C1, C2>(ref C1 c1, ref C2 c2);
        public delegate void entity_query<C1, C2>(in Entity entity, ref C1 c1, ref C2 c2);
        public delegate void query<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void entity_query<C1, C2, C3>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        public delegate void query<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void entity_query<C1, C2, C3, C4>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        public delegate void query<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void entity_query<C1, C2, C3, C4, C5>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        public delegate void query<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        public delegate void query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        public delegate void entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);

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
            public void Foreach<C1>(in entity_query<C1> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i]);
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
            public void Foreach<C1, C2>(in entity_query<C1, C2> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i]);
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
            public void Foreach<C1, C2, C3>(in entity_query<C1, C2, C3> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i]);
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
            public void Foreach<C1, C2, C3, C4>(in entity_query<C1, C2, C3, C4> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5>(in entity_query<C1, C2, C3, C4, C5> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6>(in entity_query<C1, C2, C3, C4, C5, C6> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in entity_query<C1, C2, C3, C4, C5, C6, C7> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i]);
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
            public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in entity_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
            {
                if (entity_count > 0 && TryGetPool<C1>(out var pool_c1) && TryGetPool<C2>(out var pool_c2) && TryGetPool<C3>(out var pool_c3) && TryGetPool<C4>(out var pool_c4) && TryGetPool<C5>(out var pool_c5) && TryGetPool<C6>(out var pool_c6) && TryGetPool<C7>(out var pool_c7) && TryGetPool<C8>(out var pool_c8) && TryGetPool<C9>(out var pool_c9) && TryGetPool<C10>(out var pool_c10) && TryGetPool<C11>(out var pool_c11) && TryGetPool<C12>(out var pool_c12))
                {
                    for (int i = entity_count - 1; i >= 0; --i)
                        action(entity_pool.Values[i], ref pool_c1.Values[i], ref pool_c2.Values[i], ref pool_c3.Values[i], ref pool_c4.Values[i], ref pool_c5.Values[i], ref pool_c6.Values[i], ref pool_c7.Values[i], ref pool_c8.Values[i], ref pool_c9.Values[i], ref pool_c10.Values[i], ref pool_c11.Values[i], ref pool_c12.Values[i]);
                }
            }
        }
    }
}
