namespace SimpleECS
{
    using SimpleECS.Internal;

    public partial struct Entity
    {
        /// <summary>
        /// Creates an Entity with supplied Components, can add up to 50 components
        /// </summary>
        public static Entity Create<C1>(
        C1 c1)
        => Sig<C1>.CreateEntity(
        c1);
        class Sig<C1>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1)));
                return archetype.CreateEntity().Set(c1);
            }
        }

        public static Entity Create<C1, C2>(
        C1 c1, C2 c2)
        => Sig<C1, C2>.CreateEntity(
        c1, c2);
        class Sig<C1, C2>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2)));
                return archetype.CreateEntity().Set(c1).Set(c2);
            }
        }

        public static Entity Create<C1, C2, C3>(
        C1 c1, C2 c2, C3 c3)
        => Sig<C1, C2, C3>.CreateEntity(
        c1, c2, c3);
        class Sig<C1, C2, C3>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3);
            }
        }

        public static Entity Create<C1, C2, C3, C4>(
        C1 c1, C2 c2, C3 c3, C4 c4)
        => Sig<C1, C2, C3, C4>.CreateEntity(
        c1, c2, c3, c4);
        class Sig<C1, C2, C3, C4>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
        => Sig<C1, C2, C3, C4, C5>.CreateEntity(
        c1, c2, c3, c4, c5);
        class Sig<C1, C2, C3, C4, C5>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6)
        => Sig<C1, C2, C3, C4, C5, C6>.CreateEntity(
        c1, c2, c3, c4, c5, c6);
        class Sig<C1, C2, C3, C4, C5, C6>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7)
        => Sig<C1, C2, C3, C4, C5, C6, C7>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7);
        class Sig<C1, C2, C3, C4, C5, C6, C7>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45), typeof(C46)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46, c47);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45), typeof(C46), typeof(C47)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46, c47, c48);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45), typeof(C46), typeof(C47), typeof(C48)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48, C49 c49)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46, c47, c48, c49);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48, C49 c49)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45), typeof(C46), typeof(C47), typeof(C48), typeof(C49)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49);
            }
        }

        public static Entity Create<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50>(
        C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48, C49 c49, C50 c50)
        => Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50>.CreateEntity(
        c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22, c23, c24, c25, c26, c27, c28, c29, c30, c31, c32, c33, c34, c35, c36, c37, c38, c39, c40, c41, c42, c43, c44, c45, c46, c47, c48, c49, c50);
        class Sig<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50>
        {
            static Archetype archetype;
            public static Entity CreateEntity(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32, C33 c33, C34 c34, C35 c35, C36 c36, C37 c37, C38 c38, C39 c39, C40 c40, C41 c41, C42 c42, C43 c43, C44 c44, C45 c45, C46 c46, C47 c47, C48 c48, C49 c49, C50 c50)
            {
                if (!archetype)
                    archetype = World.GetArchetype(new TypeSignature(typeof(C1), typeof(C2), typeof(C3), typeof(C4), typeof(C5), typeof(C6), typeof(C7), typeof(C8), typeof(C9), typeof(C10), typeof(C11), typeof(C12), typeof(C13), typeof(C14), typeof(C15), typeof(C16), typeof(C17), typeof(C18), typeof(C19), typeof(C20), typeof(C21), typeof(C22), typeof(C23), typeof(C24), typeof(C25), typeof(C26), typeof(C27), typeof(C28), typeof(C29), typeof(C30), typeof(C31), typeof(C32), typeof(C33), typeof(C34), typeof(C35), typeof(C36), typeof(C37), typeof(C38), typeof(C39), typeof(C40), typeof(C41), typeof(C42), typeof(C43), typeof(C44), typeof(C45), typeof(C46), typeof(C47), typeof(C48), typeof(C49), typeof(C50)));
                return archetype.CreateEntity().Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50);
            }
        }

    }
}
