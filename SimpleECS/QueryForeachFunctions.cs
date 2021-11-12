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
        public delegate void w1c1_query<W1, C1>(in W1 w1, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1>(in w1c1_query<W1, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c1_query<W1, W2, C1>(in W1 w1, in W2 w2, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1>(in w2c1_query<W1, W2, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c1_query<W1, W2, W3, C1>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1>(in w3c1_query<W1, W2, W3, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c1_query<W1, W2, W3, W4, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1>(in w4c1_query<W1, W2, W3, W4, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c2_query<W1, C1, C2>(in W1 w1, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2>(in w1c2_query<W1, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c2_query<W1, W2, C1, C2>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2>(in w2c2_query<W1, W2, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c2_query<W1, W2, W3, C1, C2>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2>(in w3c2_query<W1, W2, W3, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c2_query<W1, W2, W3, W4, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2>(in w4c2_query<W1, W2, W3, W4, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c3_query<W1, C1, C2, C3>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3>(in w1c3_query<W1, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c3_query<W1, W2, C1, C2, C3>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3>(in w2c3_query<W1, W2, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c3_query<W1, W2, W3, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3>(in w3c3_query<W1, W2, W3, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c3_query<W1, W2, W3, W4, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3>(in w4c3_query<W1, W2, W3, W4, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c4_query<W1, C1, C2, C3, C4>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4>(in w1c4_query<W1, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c4_query<W1, W2, C1, C2, C3, C4>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4>(in w2c4_query<W1, W2, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c4_query<W1, W2, W3, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4>(in w3c4_query<W1, W2, W3, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c4_query<W1, W2, W3, W4, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4>(in w4c4_query<W1, W2, W3, W4, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c5_query<W1, C1, C2, C3, C4, C5>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5>(in w1c5_query<W1, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c5_query<W1, W2, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5>(in w2c5_query<W1, W2, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c5_query<W1, W2, W3, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5>(in w3c5_query<W1, W2, W3, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c5_query<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in w4c5_query<W1, W2, W3, W4, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c6_query<W1, C1, C2, C3, C4, C5, C6>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6>(in w1c6_query<W1, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c6_query<W1, W2, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6>(in w2c6_query<W1, W2, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c6_query<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in w3c6_query<W1, W2, W3, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c6_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in w4c6_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c7_query<W1, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7>(in w1c7_query<W1, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c7_query<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in w2c7_query<W1, W2, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c7_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in w3c7_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c7_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in w4c7_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c8_query<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in w1c8_query<W1, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c8_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in w2c8_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c8_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in w3c8_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c8_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in w4c8_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c9_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w1c9_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c9_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w2c9_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c9_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w3c9_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c9_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w4c9_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c10_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w1c10_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c10_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w2c10_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c10_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w3c10_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c10_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w4c10_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c11_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w1c11_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c11_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w2c11_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c11_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w3c11_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c11_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w4c11_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1c12_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w1c12_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2c12_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w2c12_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3c12_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w3c12_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4c12_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w4c12_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec1_query<W1, C1>(in W1 w1, Entity entity, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1>(in w1ec1_query<W1, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec1_query<W1, W2, C1>(in W1 w1, in W2 w2, Entity entity, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1>(in w2ec1_query<W1, W2, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec1_query<W1, W2, W3, C1>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1>(in w3ec1_query<W1, W2, W3, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec1_query<W1, W2, W3, W4, C1>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1>(in w4ec1_query<W1, W2, W3, W4, C1> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec2_query<W1, C1, C2>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2>(in w1ec2_query<W1, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec2_query<W1, W2, C1, C2>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2>(in w2ec2_query<W1, W2, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec2_query<W1, W2, W3, C1, C2>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2>(in w3ec2_query<W1, W2, W3, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec2_query<W1, W2, W3, W4, C1, C2>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2>(in w4ec2_query<W1, W2, W3, W4, C1, C2> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec3_query<W1, C1, C2, C3>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3>(in w1ec3_query<W1, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec3_query<W1, W2, C1, C2, C3>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3>(in w2ec3_query<W1, W2, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec3_query<W1, W2, W3, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3>(in w3ec3_query<W1, W2, W3, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec3_query<W1, W2, W3, W4, C1, C2, C3>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3>(in w4ec3_query<W1, W2, W3, W4, C1, C2, C3> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec4_query<W1, C1, C2, C3, C4>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4>(in w1ec4_query<W1, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec4_query<W1, W2, C1, C2, C3, C4>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4>(in w2ec4_query<W1, W2, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec4_query<W1, W2, W3, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4>(in w3ec4_query<W1, W2, W3, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec4_query<W1, W2, W3, W4, C1, C2, C3, C4>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4>(in w4ec4_query<W1, W2, W3, W4, C1, C2, C3, C4> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec5_query<W1, C1, C2, C3, C4, C5>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5>(in w1ec5_query<W1, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec5_query<W1, W2, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5>(in w2ec5_query<W1, W2, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec5_query<W1, W2, W3, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5>(in w3ec5_query<W1, W2, W3, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec5_query<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5>(in w4ec5_query<W1, W2, W3, W4, C1, C2, C3, C4, C5> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec6_query<W1, C1, C2, C3, C4, C5, C6>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6>(in w1ec6_query<W1, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec6_query<W1, W2, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6>(in w2ec6_query<W1, W2, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec6_query<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6>(in w3ec6_query<W1, W2, W3, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec6_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6>(in w4ec6_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec7_query<W1, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7>(in w1ec7_query<W1, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec7_query<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7>(in w2ec7_query<W1, W2, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec7_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7>(in w3ec7_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec7_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7>(in w4ec7_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec8_query<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8>(in w1ec8_query<W1, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec8_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8>(in w2ec8_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec8_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8>(in w3ec8_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec8_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8>(in w4ec8_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec9_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w1ec9_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec9_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w2ec9_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec9_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w3ec9_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec9_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9>(in w4ec9_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec10_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w1ec10_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec10_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w2ec10_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec10_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w3ec10_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec10_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in w4ec10_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec11_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w1ec11_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec11_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w2ec11_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec11_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w3ec11_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec11_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in w4ec11_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w1ec12_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w1ec12_query<W1, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w2ec12_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w2ec12_query<W1, W2, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w3ec12_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w3ec12_query<W1, W2, W3, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
        public delegate void w4ec12_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in W1 w1, in W2 w2, in W3 w3, in W4 w4, Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8, ref C9 c9, ref C10 c10, ref C11 c11, ref C12 c12);
        /// <summary>
        /// performs the action on all entities that match the query.
        /// query must be in the form of '(in world_data', entity, ref components)'.
        /// query can add up to 4 world data and 12 components
        /// </summary>
        public void Foreach<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in w4ec12_query<W1, W2, W3, W4, C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12> action)
        {
            if (Update(out var world_info))
            {
                ref W1 w1 = ref world.GetData<W1>();
                ref W2 w2 = ref world.GetData<W2>();
                ref W3 w3 = ref world.GetData<W3>();
                ref W4 w4 = ref world.GetData<W4>();

                world_info.StructureEvents.EnqueueEvents++;
                for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)
                {
                    var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;
                    int count = archetype.entity_count;
                    var entities = archetype.entities;
                    if (count > 0 && archetype.TryGetArray(out C1[] c1) && archetype.TryGetArray(out C2[] c2) && archetype.TryGetArray(out C3[] c3) && archetype.TryGetArray(out C4[] c4) && archetype.TryGetArray(out C5[] c5) && archetype.TryGetArray(out C6[] c6) && archetype.TryGetArray(out C7[] c7) && archetype.TryGetArray(out C8[] c8) && archetype.TryGetArray(out C9[] c9) && archetype.TryGetArray(out C10[] c10) && archetype.TryGetArray(out C11[] c11) && archetype.TryGetArray(out C12[] c12))
                    {
                        for (int e = 0; e < count; ++e)
                            action(in w1, in w2, in w3, in w4, entities[e], ref c1[e], ref c2[e], ref c3[e], ref c4[e], ref c5[e], ref c6[e], ref c7[e], ref c8[e], ref c9[e], ref c10[e], ref c11[e], ref c12[e]);
                    }
                }
                world_info.StructureEvents.EnqueueEvents--;
            }
        }
    }
}