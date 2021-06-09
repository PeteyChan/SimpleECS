namespace SimpleECS
{
  public partial class World
  {
      #pragma warning disable
      public Entity CreateEntity<C1>(in C1 c1)
      {
          signature.Clear();
          signature.Add<C1>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1);
      }

      public Entity CreateEntity<C1, C2>(in C1 c1, in C2 c2)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2);
      }

      public Entity CreateEntity<C1, C2, C3>(in C1 c1, in C2 c2, in C3 c3)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3);
      }

      public Entity CreateEntity<C1, C2, C3, C4>(in C1 c1, in C2 c2, in C3 c3, in C4 c4)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C60>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59, in C60 c60)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>().Add<C60>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59).Set(c60);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C60, C61>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59, in C60 c60, in C61 c61)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>().Add<C60>().Add<C61>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59).Set(c60).Set(c61);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C60, C61, C62>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59, in C60 c60, in C61 c61, in C62 c62)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>().Add<C60>().Add<C61>().Add<C62>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59).Set(c60).Set(c61).Set(c62);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C60, C61, C62, C63>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59, in C60 c60, in C61 c61, in C62 c62, in C63 c63)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>().Add<C60>().Add<C61>().Add<C62>().Add<C63>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59).Set(c60).Set(c61).Set(c62).Set(c63);
      }

      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32, C33, C34, C35, C36, C37, C38, C39, C40, C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52, C53, C54, C55, C56, C57, C58, C59, C60, C61, C62, C63, C64>(in C1 c1, in C2 c2, in C3 c3, in C4 c4, in C5 c5, in C6 c6, in C7 c7, in C8 c8, in C9 c9, in C10 c10, in C11 c11, in C12 c12, in C13 c13, in C14 c14, in C15 c15, in C16 c16, in C17 c17, in C18 c18, in C19 c19, in C20 c20, in C21 c21, in C22 c22, in C23 c23, in C24 c24, in C25 c25, in C26 c26, in C27 c27, in C28 c28, in C29 c29, in C30 c30, in C31 c31, in C32 c32, in C33 c33, in C34 c34, in C35 c35, in C36 c36, in C37 c37, in C38 c38, in C39 c39, in C40 c40, in C41 c41, in C42 c42, in C43 c43, in C44 c44, in C45 c45, in C46 c46, in C47 c47, in C48 c48, in C49 c49, in C50 c50, in C51 c51, in C52 c52, in C53 c53, in C54 c54, in C55 c55, in C56 c56, in C57 c57, in C58 c58, in C59 c59, in C60 c60, in C61 c61, in C62 c62, in C63 c63, in C64 c64)
      {
          signature.Clear();
          signature.Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>().Add<C33>().Add<C34>().Add<C35>().Add<C36>().Add<C37>().Add<C38>().Add<C39>().Add<C40>().Add<C41>().Add<C42>().Add<C43>().Add<C44>().Add<C45>().Add<C46>().Add<C47>().Add<C48>().Add<C49>().Add<C50>().Add<C51>().Add<C52>().Add<C53>().Add<C54>().Add<C55>().Add<C56>().Add<C57>().Add<C58>().Add<C59>().Add<C60>().Add<C61>().Add<C62>().Add<C63>().Add<C64>();
          return CreateEntityWithArchetype(GetArchetype(signature)).Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32).Set(c33).Set(c34).Set(c35).Set(c36).Set(c37).Set(c38).Set(c39).Set(c40).Set(c41).Set(c42).Set(c43).Set(c44).Set(c45).Set(c46).Set(c47).Set(c48).Set(c49).Set(c50).Set(c51).Set(c52).Set(c53).Set(c54).Set(c55).Set(c56).Set(c57).Set(c58).Set(c59).Set(c60).Set(c61).Set(c62).Set(c63).Set(c64);
      }

  }
}
