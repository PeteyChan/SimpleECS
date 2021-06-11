namespace SimpleECS
{
    using System.IO;
    internal class Generator
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
        /// Generates the create entity functions to file located at path.
        /// Count is the amount of functions to generate
        /// </summary>
        public static void EntityCreateFunctions(string file_path, int count)
        {
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                writer.WriteLine($"namespace {nameof(SimpleECS)}");
                writer.WriteLine("{");
                writer.WriteLine("  public partial class World");
                writer.WriteLine("  {");
                for (int i = 1; i <= count; ++i)
                {
                    writer.WriteLine($"      public Entity CreateEntity<{Pattern("C#", i)}>({Pattern("in C# c#", i)})");
                    writer.WriteLine("      {");
                    writer.WriteLine("          signature.Clear();");
                    writer.WriteLine($"          signature{Pattern(".Add<C#>()", i, false)};");
                    writer.WriteLine($"          return CreateEntityWithArchetype(GetArchetype(signature)){Pattern(".Set(c#)", i, false)};");
                    writer.WriteLine("      }");
                    writer.WriteLine("");
                }
                writer.WriteLine("  }");
                writer.WriteLine("}");
            }
        }

        /// <summary>
        /// Generates foreach functions for queries and archetypes
        /// </summary>
        public static void ForeachFunctions(string file_path, int count)
        {
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                writer.WriteLine("namespace SimpleECS");
                writer.WriteLine("{");
                {

                    writer.WriteLine("  using Delegates;");
                    writer.WriteLine("");
                    writer.WriteLine("  public partial class Query");
                    writer.WriteLine("  {");
                    {
                        for (int size = 1; size <= count; ++size)
                        {
                            writer.WriteLine("      /// <summary>");
                            writer.WriteLine($"     /// Allows iteration of components in query, can add up to {count} components");
                            writer.WriteLine("      /// </summary>");
                            writer.WriteLine($"     public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("      {");
                            writer.WriteLine("          Update();");
                            writer.WriteLine("          world.AllowStructuralChanges = false;");
                            writer.WriteLine("          for (int i = archetype_count - 1; i >= 0; --i)");   // for some reason iterating backwards doubles the performance on my machine
                            writer.WriteLine("          {");                                                // I suspect because the compiler can ignore array bounds checks
                            writer.WriteLine("              var archetype = matching_archetypes[i];");      // since it only needs to make sure archetype_count -1 has to be within the bounds
                            writer.WriteLine($"             if (archetype.entity_count > 0 {Pattern("&& archetype.TryGetArray<C#>(out var pool_c#)", size, false)})");
                            writer.WriteLine("                  for(int e = archetype.entity_count - 1; e >= 0; -- e)");
                            writer.WriteLine($"                     action({Pattern("ref pool_c#[e]", size)});");
                            writer.WriteLine("          }");
                            writer.WriteLine("          world.AllowStructuralChanges = true;");
                            writer.WriteLine("      }");
                            writer.WriteLine("");
                        }

                        for (int size = 1; size <= count; ++size)
                        {
                            writer.WriteLine("      /// <summary>");
                            writer.WriteLine($"     /// Allows iteration of components in query, can add up to {count} components");
                            writer.WriteLine("      /// </summary>");
                            writer.WriteLine($"     public void Foreach<{Pattern("C#", size)}>(in entity_query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("      {");
                            writer.WriteLine("          Update();");
                            writer.WriteLine("          world.AllowStructuralChanges = false;");
                            writer.WriteLine("          for (int i = archetype_count - 1; i >= 0; --i)");
                            writer.WriteLine("          {");
                            writer.WriteLine("              var archetype = matching_archetypes[i];");
                            writer.WriteLine($"             if (archetype.entity_count > 0 {Pattern("&& archetype.TryGetArray<C#>(out var pool_c#)", size, false)})");
                            writer.WriteLine("                  for(int e = archetype.entity_count - 1; e >= 0; -- e)");
                            writer.WriteLine($"                     action(archetype.entity_pool[e], {Pattern("ref pool_c#[e]", size)});");
                            writer.WriteLine("          }");
                            writer.WriteLine("          world.AllowStructuralChanges = true;");
                            writer.WriteLine("      }");
                            writer.WriteLine("");
                        }
                        writer.WriteLine("}");
                        writer.WriteLine("");

                        writer.WriteLine("public partial class World");
                        writer.WriteLine("{");
                        {
                            writer.WriteLine("  public partial class Archetype");
                            writer.WriteLine("  {");
                            {
                                for (int size = 1; size <= count; ++size)
                                {
                                    writer.WriteLine("      /// <summary>");
                                    writer.WriteLine($"     /// Allows iteration of components in archetype, can add up to {count} components");
                                    writer.WriteLine("      /// </summary>");
                                    writer.WriteLine($"     public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                                    writer.WriteLine("      {");
                                    writer.WriteLine("          if (entity_count > 0" + Pattern("&& TryGetArray<C#>(out var pool_c#)", size, false) + ")");
                                    writer.WriteLine("              for (int i = entity_count - 1; i >= 0; --i)");
                                    writer.WriteLine($"                 action({Pattern("ref pool_c#[i]", size)});");
                                    writer.WriteLine("      }");
                                    writer.WriteLine("");
                                }

                                for (int size = 1; size <= count; ++size)
                                {
                                    writer.WriteLine("      /// <summary>");
                                    writer.WriteLine($"     /// Allows iteration of components in archetype, can add up to {count} components");
                                    writer.WriteLine("      /// </summary>");
                                    writer.WriteLine($"     public void Foreach<{Pattern("C#", size)}>(in {nameof(Delegates.query_e)}<{Pattern("C#", size)}> action)");
                                    writer.WriteLine("      {");
                                    writer.WriteLine("          if (entity_count > 0" + Pattern("&& TryGetArray<C#>(out var pool_c#)", size, false) + ")");
                                    writer.WriteLine("          for (int i = entity_count - 1; i >= 0; --i)");
                                    writer.WriteLine($"             action(entity_pool[i], {Pattern("ref pool_c#[i]", size)});");
                                    writer.WriteLine("      }");
                                    writer.WriteLine("");
                                }
                            }
                            writer.WriteLine("}");
                        }
                        writer.WriteLine("}");

                        writer.WriteLine("  namespace Delegates");
                        writer.WriteLine("  {");
                        {
                            for (int size = 1; size < count + 1; ++size)
                            {
                                writer.WriteLine($"     public delegate void query<{Pattern("C#", size)}>({Pattern("ref C# c#", size)});");
                            }

                            for (int size = 1; size < count + 1; ++size)
                            {
                                writer.WriteLine($"     public delegate void {nameof(Delegates.query_e)}<{Pattern("C#", size)}>(Entity entity, {Pattern("ref C# c#", size)});");
                            }
                        }
                        writer.WriteLine("}");
                    }
                    writer.WriteLine("}");
                }
            }
        }

        public static void GenerateQueryFunctions(int data, int comp, string file_path)
        {
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                writer.WriteLine("    namespace SimpleECS");
                writer.WriteLine("{");
                writer.WriteLine("    using Delegates;");
                writer.WriteLine("    public partial class Query");
                writer.WriteLine("    {");



                for (int c = 1; c <= comp; ++c)
                {
                    string c_val = Pattern("C#", c);
                    WriteDocumentation(writer);
                    writer.WriteLine($"        public void Foreach<{c_val}>(in query_c{c}<{c_val}> query)");
                    writer.WriteLine("        {");
                    writer.WriteLine("            Update();");
                    writer.WriteLine("            if (archetype_count == 0) return;");
                    writer.WriteLine("            world.AllowStructuralChanges = false;");
                    writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                    writer.WriteLine("            {");
                    writer.WriteLine("                var archetype = matching_archetypes[i];");
                    var archs = Pattern("&& archetype.TryGetArray(out C#[] pool_c#)", c, false);
                    writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                    writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                    writer.WriteLine($"                        query({Pattern("ref pool_c#[e]", c)});");
                    writer.WriteLine("            }");
                    writer.WriteLine("            world.AllowStructuralChanges = true;");
                    writer.WriteLine("        }");

                    // entity
                    WriteDocumentation(writer);
                    writer.WriteLine($"        public void Foreach<{c_val}>(in query_ec{c}<{c_val}> query)");
                    writer.WriteLine("        {");
                    writer.WriteLine("            Update();");
                    writer.WriteLine("            if (archetype_count == 0) return;");
                    writer.WriteLine("            world.AllowStructuralChanges = false;");
                    writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                    writer.WriteLine("            {");
                    writer.WriteLine("                var archetype = matching_archetypes[i];");
                    writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                    writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                    writer.WriteLine($"                        query(archetype.entity_pool[e], {Pattern("ref pool_c#[e]", c)});");
                    writer.WriteLine("            }");
                    writer.WriteLine("            world.AllowStructuralChanges = true;");
                    writer.WriteLine("        }");
                }

                for (int w = 1; w <= data; ++w)
                    for (int c = 1; c <= comp; ++c)
                    {
                        string w_val = Pattern("W#", w);
                        string c_val = Pattern("C#", c);

                        WriteDocumentation(writer);
                        writer.WriteLine($"        public void Foreach<{w_val}, {c_val}>(in query_w{w}c{c}<{w_val}, {c_val}> query)");
                        writer.WriteLine("        {");
                        writer.WriteLine("            Update();");
                        writer.WriteLine("            if (archetype_count == 0) return;");
                        writer.WriteLine("            world.AllowStructuralChanges = false;");
                        writer.WriteLine(Pattern("            var d# = world.GetData<W#>(); \n", w, false));
                        writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                        writer.WriteLine("            {");
                        writer.WriteLine("                var archetype = matching_archetypes[i];");
                        var archs = Pattern("&& archetype.TryGetArray(out C#[] pool_c#)", c, false);
                        writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                        writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                        writer.WriteLine($"                        query({Pattern("d#", w)}, {Pattern("ref pool_c#[e]", c)});");
                        writer.WriteLine("            }");
                        writer.WriteLine("            world.AllowStructuralChanges = true;");
                        writer.WriteLine("        }");

                        // entity
                        WriteDocumentation(writer);
                        writer.WriteLine($"        public void Foreach<{w_val}, {c_val}>(in query_ew{w}c{c}<{w_val}, {c_val}> query)");
                        writer.WriteLine("        {");
                        writer.WriteLine("            Update();");
                        writer.WriteLine("            if (archetype_count == 0) return;");
                        writer.WriteLine("            world.AllowStructuralChanges = false;");
                        writer.WriteLine(Pattern("            var d# = world.GetData<W#>(); \n", w, false));
                        writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                        writer.WriteLine("            {");
                        writer.WriteLine("                var archetype = matching_archetypes[i];");
                        writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                        writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                        writer.WriteLine($"                        query(archetype.entity_pool[e], {Pattern("d#", w)}, {Pattern("ref pool_c#[e]", c)});");
                        writer.WriteLine("            }");
                        writer.WriteLine("            world.AllowStructuralChanges = true;");
                        writer.WriteLine("        }");
                    }
                writer.WriteLine("    }");
                writer.WriteLine("");
                writer.WriteLine("    namespace Delegates");
                writer.WriteLine("    {");

                for (int c = 1; c <= comp; ++c)
                {
                    writer.WriteLine($"        public delegate void query_c{c}<{Pattern("C#", c)}>({Pattern("ref C# c#", c)});");
                    writer.WriteLine($"        public delegate void query_ec{c}<{Pattern("C#", c)}>(Entity entity, {Pattern("ref C# c#", c)});");
                }

                for (int w = 1; w <= data; ++w)
                    for (int c = 1; c <= comp; ++c)
                    {
                        writer.WriteLine($"        public delegate void query_w{w}c{c}<{Pattern("W#", w)}, {Pattern("C#", c)}>({Pattern("in W# w#", w)}, {Pattern("ref C# c#", c)});");
                        writer.WriteLine($"        public delegate void query_ew{w}c{c}<{Pattern("W#", w)}, {Pattern("C#", c)}>(Entity entity, {Pattern("in W# w#", w)}, {Pattern("ref C# c#", c)});");
                    }
                writer.WriteLine("    }");
                writer.WriteLine("}");
            }

            void WriteDocumentation(StreamWriter writer)
            {
                writer.WriteLine("/// <summary>");
                writer.WriteLine("/// Iterates over entities that matches query.");
                writer.WriteLine("/// Add Entity in First position to access Entity.");
                writer.WriteLine($"/// Add (in W world_data) to access world data, can add up to {data} world data.");
                writer.WriteLine($"/// Add (ref C component) to access entity components, can add up to {comp} components.");
                writer.WriteLine("/// </summary>");
            }
        }
    }
}