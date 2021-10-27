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
                    /*
                    writer.WriteLine($"      public Entity CreateEntity<{Pattern("C#", i)}>({Pattern("in C# c#", i)})");
                    writer.WriteLine("      {");
                    writer.WriteLine("          signature.Clear();");
                    writer.WriteLine($"          signature{Pattern(".Add<C#>()", i, false)};");
                    writer.WriteLine($"          return CreateEntityWithArchetype(GetArchetype(signature)){Pattern(".Set(c#)", i, false)};");
                    writer.WriteLine("      }");
                    writer.WriteLine("");
*/
                    writer.WriteLine($"     class Sig<{Pattern("C#", i)}>");
                    writer.WriteLine("      {");
                    writer.WriteLine($"          public static readonly TypeSignature signature = new TypeSignature(){Pattern(".Add<C#>()", i, false)};");
                    writer.WriteLine("      }");
                    writer.WriteLine("");
                    writer.WriteLine("      ///<summary>");
                    writer.WriteLine($"      ///creates a new entity, can add up to {count} components");
                    writer.WriteLine("      ///</summary>");
                    writer.WriteLine($"      public Entity CreateEntity<{Pattern("C#", i)}>({Pattern("in C# c#", i)}) =>");
                    writer.WriteLine($"          CreateEntityWithArchetype(GetArchetype(Sig<{Pattern("C#", i)}>.signature)){Pattern(".Set(c#)", i, false)};");
                    writer.WriteLine("");
                }
                writer.WriteLine("  }");
                writer.WriteLine("}");
            }
        }

        /// <summary>
        /// Generates foreach functions for archetypes
        /// </summary>
        public static void ForeachFunctionsArchetypes(string file_path, int count)
        {
            using (StreamWriter writer = new StreamWriter(file_path))
            {
                writer.WriteLine("namespace SimpleECS");
                writer.WriteLine("{");
                {

                    writer.WriteLine("  using Delegates;");
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
                }
            }
        }

        public static void GenerateQueryFunctions(int comp, string file_path)
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
                    // components only
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

                    // entities and components
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

                    // world, entities and components
                    WriteDocumentation(writer);
                    writer.WriteLine($"        public void Foreach<{c_val}>(in query_wec{c}<{c_val}> query)");
                    writer.WriteLine("        {");
                    writer.WriteLine("            Update();");
                    writer.WriteLine("            if (archetype_count == 0) return;");
                    writer.WriteLine("            world.AllowStructuralChanges = false;");
                    writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                    writer.WriteLine("            {");
                    writer.WriteLine("                var archetype = matching_archetypes[i];");
                    writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                    writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                    writer.WriteLine($"                        query(world, archetype.entity_pool[e], {Pattern("ref pool_c#[e]", c)});");
                    writer.WriteLine("            }");
                    writer.WriteLine("            world.AllowStructuralChanges = true;");
                    writer.WriteLine("        }");

                    // world and components
                    WriteDocumentation(writer);
                    writer.WriteLine($"        public void Foreach<{c_val}>(in query_wc{c}<{c_val}> query)");
                    writer.WriteLine("        {");
                    writer.WriteLine("            Update();");
                    writer.WriteLine("            if (archetype_count == 0) return;");
                    writer.WriteLine("            world.AllowStructuralChanges = false;");
                    writer.WriteLine("            for (int i = archetype_count - 1; i >= 0; --i)");
                    writer.WriteLine("            {");
                    writer.WriteLine("                var archetype = matching_archetypes[i];");
                    writer.WriteLine($"                if (archetype.entity_count > 0 {archs})");
                    writer.WriteLine("                    for (int e = archetype.entity_count - 1; e >= 0; --e)");
                    writer.WriteLine($"                        query(world, {Pattern("ref pool_c#[e]", c)});");
                    writer.WriteLine("            }");
                    writer.WriteLine("            world.AllowStructuralChanges = true;");
                    writer.WriteLine("        }");
                }

                writer.WriteLine("    }");
                writer.WriteLine("");
                writer.WriteLine("    namespace Delegates");
                writer.WriteLine("    {");
                writer.WriteLine("#pragma warning disable 1587");

                for (int c = 1; c <= comp; ++c)
                {
                    writer.WriteLine($"        public delegate void query_c{c}<{Pattern("C#", c)}>({Pattern("ref C# c#", c)});");
                    writer.WriteLine($"        public delegate void query_ec{c}<{Pattern("C#", c)}>(Entity entity, {Pattern("ref C# c#", c)});");
                    writer.WriteLine($"        public delegate void query_wec{c}<{Pattern("C#", c)}>(World world, Entity entity, {Pattern("ref C# c#", c)});");
                    writer.WriteLine($"        public delegate void query_wc{c}<{Pattern("C#", c)}>(World world, {Pattern("ref C# c#", c)});");
                }

                writer.WriteLine("#pragma warning restore 1587");
                writer.WriteLine("    }");
                writer.WriteLine("}");
            }

            void WriteDocumentation(StreamWriter writer)
            {
                writer.WriteLine("/// <summary>");
                writer.WriteLine("/// Iterates over entities that matches query.");
                writer.WriteLine("/// Add World in first position to access the world being queried");
                writer.WriteLine("/// Add Entity after world to access the current entity.");
                writer.WriteLine($"/// Add (ref C component) to access the current entity's component, can add up to {comp} components.");
                writer.WriteLine("/// </summary>");
            }
        }
    }
}