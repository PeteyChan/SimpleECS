namespace SimpleECS
{
  using Internal;
  public partial struct World
  {
      public Entity CreateEntity<C1>(C1 c1)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2>(C1 c1, C2 c2)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3>(C1 c1, C2 c2, C3 c3)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4>(C1 c1, C2 c2, C3 c3, C4 c4)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31);
          }
          return default;
      }
      public Entity CreateEntity<C1, C2, C3, C4, C5, C6, C7, C8, C9, C10, C11, C12, C13, C14, C15, C16, C17, C18, C19, C20, C21, C22, C23, C24, C25, C26, C27, C28, C29, C30, C31, C32>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, C6 c6, C7 c7, C8 c8, C9 c9, C10 c10, C11 c11, C12 c12, C13 c13, C14 c14, C15 c15, C16 c16, C17 c17, C18 c18, C19 c19, C20 c20, C21 c21, C22 c22, C23 c23, C24 c24, C25 c25, C26 c26, C27 c27, C28 c28, C29 c29, C30 c30, C31 c31, C32 c32)
      {
          if (this.TryGetWorldInfo(out var data))
          {
              data.buffer_signature.Clear().Add<C1>().Add<C2>().Add<C3>().Add<C4>().Add<C5>().Add<C6>().Add<C7>().Add<C8>().Add<C9>().Add<C10>().Add<C11>().Add<C12>().Add<C13>().Add<C14>().Add<C15>().Add<C16>().Add<C17>().Add<C18>().Add<C19>().Add<C20>().Add<C21>().Add<C22>().Add<C23>().Add<C24>().Add<C25>().Add<C26>().Add<C27>().Add<C28>().Add<C29>().Add<C30>().Add<C31>().Add<C32>();
              var archetype = data.GetArchetypeData(data.buffer_signature);
              return data.StructureEvents.CreateEntity(archetype)
                  .Set(c1).Set(c2).Set(c3).Set(c4).Set(c5).Set(c6).Set(c7).Set(c8).Set(c9).Set(c10).Set(c11).Set(c12).Set(c13).Set(c14).Set(c15).Set(c16).Set(c17).Set(c18).Set(c19).Set(c20).Set(c21).Set(c22).Set(c23).Set(c24).Set(c25).Set(c26).Set(c27).Set(c28).Set(c29).Set(c30).Set(c31).Set(c32);
          }
          return default;
      }
  }
}
