namespace SimpleECS.Internal
{
    using System.IO;

    /// <summary>
    /// Generates the entity create and query foreach functions
    /// Use to increase the default limits
    /// </summary>
    public static class CodeGenerator
    {
        static string Pattern(string value, int count, bool comma_sep = true)
        {
            string result = "";
            for (int i = 1; i < count; ++i)
            {
                result += value.Replace("#", i.ToString());
                if (comma_sep) result += ", ";
            }
            result += value.Replace("#", (count).ToString());
            return result;
        }

        /// <summary>
        /// Generates all world.CreateEntity functions
        /// </summary>
        /// <param name="count">Maximum number of components that can be used in CreateEntity Functions</param>
        /// <param name="output_path">Path to EntityCreateFunctions.cs</param>
        public static void CreateEntityFunctions(int count, string output_path)
        {
            using (StreamWriter writer = new StreamWriter(output_path))
            {
                writer.WriteLine($"namespace {nameof(SimpleECS)}");
                writer.WriteLine("{");
                writer.WriteLine("  using Internal;");
                writer.WriteLine("  public partial struct World");
                writer.WriteLine("  {");

                for (int i = 1; i < count + 1; ++i)
                {
                    writer.WriteLine($"      public Entity CreateEntity<{Pattern("C#", i)}>({Pattern("C# c#", i)})");
                    writer.WriteLine("      {");
                    writer.WriteLine("          if (this.TryGetWorldInfo(out var data))");
                    writer.WriteLine("          {");
                    writer.WriteLine($"              data.buffer_signature.Clear(){Pattern(".Add<C#>()", i, false)};");
                    writer.WriteLine("              var archetype = data.GetArchetypeData(data.buffer_signature);");
                    writer.WriteLine("              return data.StructureEvents.CreateEntity(archetype)");
                    writer.WriteLine($"                  {Pattern(".Set(c#)", i, false)};");
                    writer.WriteLine("          }");
                    writer.WriteLine("          return default;");
                    writer.WriteLine("      }");
                }
                writer.WriteLine("  }");
                writer.WriteLine("}");
            }
        }

        /// <summary>
        /// Generates all query.Foreach functions
        /// </summary>
        /// <param name="world_data_count">Maximum number of world data that can be used in queries</param>
        /// <param name="component_count">Maximum number of components that can be used in queries</param>
        /// <param name="output_path">Path to QueryForeachFunctions.cs</param>
        public static void CreateQueryFunctions(int world_data_count, int component_count, string output_path)
        {
            using (StreamWriter writer = new StreamWriter(output_path))
            {
                writer.WriteLine($"namespace {nameof(SimpleECS)}");
                writer.WriteLine("{");
                writer.WriteLine("  public partial class Query");
                writer.WriteLine("  {");

                for (int c = 1; c < component_count + 1; ++c) // components
                {
                    string c_val = Pattern("C#", c);
                    var arch_get = Pattern("&& archetype.TryGetArray(out C#[] c#)", c, false);

                    writer.WriteLine($"       public delegate void c{c}_query<{c_val}>({Pattern("ref C# c#", c)});");
                    WriteDocumentation();
                    writer.WriteLine($"       public void Foreach<{c_val}>(in c{c}_query<{c_val}> action)");
                    writer.WriteLine("       {");
                    writer.WriteLine("           if (Update(out var world_info))");
                    writer.WriteLine("           {");
                    writer.WriteLine("               world_info.StructureEvents.EnqueueEvents++;");
                    writer.WriteLine("               for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)");
                    writer.WriteLine("               {");
                    writer.WriteLine("                   var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;");
                    writer.WriteLine("                   int count = archetype.entity_count;");
                    writer.WriteLine($"                   if (count > 0 {arch_get})");
                    writer.WriteLine("                   {");
                    writer.WriteLine("                       for (int e = 0; e < count; ++e)");
                    writer.WriteLine($"                       action({Pattern("ref c#[e]", c)});");
                    writer.WriteLine("                   }");
                    writer.WriteLine("               }");
                    writer.WriteLine("               world_info.StructureEvents.EnqueueEvents--;");
                    writer.WriteLine("           }");
                    writer.WriteLine("       }");
                }

                for (int c = 1; c < component_count + 1; ++c) // entity and components
                {
                    string c_val = Pattern("C#", c);
                    var arch_get = Pattern("&& archetype.TryGetArray(out C#[] c#)", c, false);

                    writer.WriteLine($"       public delegate void ec{c}_query<{c_val}>(Entity entity, {Pattern("ref C# c#", c)});");
                    WriteDocumentation();
                    writer.WriteLine($"       public void Foreach<{c_val}>(in ec{c}_query<{c_val}> action)");
                    writer.WriteLine("       {");
                    writer.WriteLine("           if (Update(out var world_info))");
                    writer.WriteLine("           {");
                    writer.WriteLine("               world_info.StructureEvents.EnqueueEvents++;");
                    writer.WriteLine("               for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)");
                    writer.WriteLine("               {");
                    writer.WriteLine("                   var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;");
                    writer.WriteLine("                   int count = archetype.entity_count;");
                    writer.WriteLine("                   var entities = archetype.entities;");
                    writer.WriteLine($"                   if (count > 0 {arch_get})");
                    writer.WriteLine("                   {");
                    writer.WriteLine("                       for (int e = 0; e < count; ++e)");
                    writer.WriteLine($"                       action(entities[e], {Pattern("ref c#[e]", c)});");
                    writer.WriteLine("                   }");
                    writer.WriteLine("               }");
                    writer.WriteLine("               world_info.StructureEvents.EnqueueEvents--;");
                    writer.WriteLine("           }");
                    writer.WriteLine("       }");
                }

                for (int c = 1; c < component_count + 1; ++c) // world data and components
                    for (int w = 1; w < world_data_count + 1; ++w)
                    {
                        string c_val = Pattern("C#", c);
                        string w_val = Pattern("W#", w);
                        var arch_get = Pattern("&& archetype.TryGetArray(out C#[] c#)", c, false);

                        writer.WriteLine($"       public delegate void w{w}c{c}_query<{w_val},{c_val}>({Pattern("in W# w#", w)}, {Pattern("ref C# c#", c)});");
                        WriteDocumentation();
                        writer.WriteLine($"       public void Foreach<{w_val},{c_val}>(in w{w}c{c}_query<{w_val},{c_val}> action)");
                        writer.WriteLine("       {");
                        writer.WriteLine("           if (Update(out var world_info))");
                        writer.WriteLine("           {");
                        writer.WriteLine($"{Pattern("               ref W# w# = ref world.GetData<W#>();\n", w, false)}");
                        writer.WriteLine("               world_info.StructureEvents.EnqueueEvents++;");
                        writer.WriteLine("               for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)");
                        writer.WriteLine("               {");
                        writer.WriteLine("                   var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;");
                        writer.WriteLine("                   int count = archetype.entity_count;");
                        writer.WriteLine($"                   if (count > 0 {arch_get})");
                        writer.WriteLine("                   {");
                        writer.WriteLine("                       for (int e = 0; e < count; ++e)");
                        writer.WriteLine($"                       action({Pattern("in w#", w)}, {Pattern("ref c#[e]", c)});");
                        writer.WriteLine("                   }");
                        writer.WriteLine("               }");
                        writer.WriteLine("               world_info.StructureEvents.EnqueueEvents--;");
                        writer.WriteLine("           }");
                        writer.WriteLine("       }");
                    }

                for (int c = 1; c < component_count + 1; ++c) // world data, entity and components
                    for (int w = 1; w < world_data_count + 1; ++w)
                    {
                        string c_val = Pattern("C#", c);
                        string w_val = Pattern("W#", w);
                        var arch_get = Pattern("&& archetype.TryGetArray(out C#[] c#)", c, false);

                        writer.WriteLine($"       public delegate void w{w}ec{c}_query<{w_val},{c_val}>({Pattern("in W# w#", w)}, Entity entity, {Pattern("ref C# c#", c)});");
                        WriteDocumentation();
                        writer.WriteLine($"       public void Foreach<{w_val},{c_val}>(in w{w}ec{c}_query<{w_val},{c_val}> action)");
                        writer.WriteLine("       {");
                        writer.WriteLine("           if (Update(out var world_info))");
                        writer.WriteLine("           {");
                        writer.WriteLine($"{Pattern("               ref W# w# = ref world.GetData<W#>();\n", w, false)}");
                        writer.WriteLine("               world_info.StructureEvents.EnqueueEvents++;");
                        writer.WriteLine("               for (int archetype_index = 0; archetype_index < archetype_count; ++archetype_index)");
                        writer.WriteLine("               {");
                        writer.WriteLine("                   var archetype = world_info.archetypes[matching_archetypes[archetype_index]].data;");
                        writer.WriteLine("                   int count = archetype.entity_count;");
                        writer.WriteLine("                   var entities = archetype.entities;");
                        writer.WriteLine($"                   if (count > 0 {arch_get})");
                        writer.WriteLine("                   {");
                        writer.WriteLine("                       for (int e = 0; e < count; ++e)");
                        writer.WriteLine($"                       action({Pattern("in w#", w)}, entities[e], {Pattern("ref c#[e]", c)});");
                        writer.WriteLine("                   }");
                        writer.WriteLine("               }");
                        writer.WriteLine("               world_info.StructureEvents.EnqueueEvents--;");
                        writer.WriteLine("           }");
                        writer.WriteLine("       }");
                    }

                writer.WriteLine("  }");
                writer.WriteLine("}");

                void WriteDocumentation()
                {
                    writer.WriteLine("        /// <summary>");
                    writer.WriteLine("        /// performs the action on all entities that match the query.");
                    writer.WriteLine("        /// query must be in the form of '(in world_data', entity, ref components)'.");
                    writer.WriteLine($"        /// query can add up to {world_data_count} world data and {component_count} components");
                    writer.WriteLine("        /// </summary>");
                }
            }
        }
    }
}