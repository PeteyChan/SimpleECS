namespace SimpleECS
{
    public partial class Query
    {
        public delegate void c1_query<C1>(ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1>(in c1_query<C1> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c2_query<C1, C2>(ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2>(in c2_query<C1, C2> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c3_query<C1, C2, C3>(ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3>(in c3_query<C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c4_query<C1, C2, C3, C4>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in c4_query<C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c5_query<C1, C2, C3, C4, C5>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in c5_query<C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c6_query<C1, C2, C3, C4, C5, C6>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in c6_query<C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c7_query<C1, C2, C3, C4, C5, C6, C7>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in c7_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c8_query<C1, C2, C3, C4, C5, C6, C7, C8>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in c8_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c9_query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in c9_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c10_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in c10_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c11_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in c11_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void c12_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in c12_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec1_query<C1>(Entity entity, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1>(in ec1_query<C1> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec2_query<C1, C2>(Entity entity, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2>(in ec2_query<C1, C2> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec3_query<C1, C2, C3>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3>(in ec3_query<C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec4_query<C1, C2, C3, C4>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4>(in ec4_query<C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec5_query<C1, C2, C3, C4, C5>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5>(in ec5_query<C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec6_query<C1, C2, C3, C4, C5, C6>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6>(in ec6_query<C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec7_query<C1, C2, C3, C4, C5, C6, C7>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7>(in ec7_query<C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec8_query<C1, C2, C3, C4, C5, C6, C7, C8>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8>(in ec8_query<C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec9_query<C1, C2, C3, C4, C5, C6, C7, C8, C9>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in ec9_query<C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec10_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in ec10_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec11_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in ec11_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void ec12_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in ec12_query<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1>> Foreach<C1>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2>> Foreach<C1, C2>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3>> Foreach<C1, C2, C3>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;

                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4>> Foreach<C1, C2, C3, C4>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5>> Foreach<C1, C2, C3, C4, C5>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, C6>> Foreach<C1, C2, C3, C4, C5, C6>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7>>> Foreach<C1, C2, C3, C4, C5, C6, C7>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7, C8>>> Foreach<C1, C2, C3, C4, C5, C6, C7, C8>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e], c8[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7, C8, C9>>> Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e], c8[e], c9[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7, C8, C9, C10>>> Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e], c8[e], c9[e], c10[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7, C8, C9, C10, C11>>> Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e], c8[e], c9[e], c10[e], c11[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        /// <summary>
        /// iterates over the entities that match the query and returns a tuple of the entity and the components
        /// possible to use continue and break
        /// NOTE: it is only possible to modity a refernce type in the tuple, like a class. You can not modify a value type, like int, float, bool, etc.
        /// </summary>
        public IEnumerable<Tuple<Entity, C1, C2, C3, C4, C5, Tuple<C6, C7, C8, C9, C10, C11, C12>>> Foreach<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>()
        {
            if (Update(out var world_info))
            {
                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            yield return Tuple.Create(entities[e], c1[e], c2[e], c3[e], c4[e], c5[e], Tuple.Create(c6[e], c7[e], c8[e], c9[e], c10[e], c11[e], c12[e]));
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
    }
}