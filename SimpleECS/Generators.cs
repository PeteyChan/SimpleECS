// ENTITY CREATE FUNCTION
namespace SimpleECS.Internal
{
    using System.IO;
    class Generator
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
                writer.WriteLine("namespace SimpleECS");
                writer.WriteLine("{");
                {
                    writer.WriteLine("using SimpleECS.Internal;");
                    writer.WriteLine("");
                    writer.WriteLine("public partial struct Entity");
                    writer.WriteLine("{");
                    {

                        writer.WriteLine("/// <summary>");
                        writer.WriteLine($"/// Creates an Entity with supplied Components, can add up to {count} components");
                        writer.WriteLine("/// </summary>");
                        writer.WriteLine("public static Entity Create() => Sig.archetype.CreateEntity();");

                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine("public static Entity Create<" + Pattern("C#", size) + ">(");
                            writer.WriteLine(Pattern("in C# c#", size) + ")");
                            writer.WriteLine("{");
                            writer.WriteLine($"ref var archetype = ref Sig<{Pattern("C#", size)}>.archetype;");
                            writer.WriteLine($"if (!archetype) archetype = World.GetArchetype(new TypeSignature({Pattern("typeof(C#)", size)}));");
                            writer.WriteLine($"return archetype.CreateEntity(){Pattern(".Set(c#)", size, false)};");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }

                        writer.WriteLine("class Sig { public static Archetype archetype = World.GetArchetype(new TypeSignature()); }");

                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"class Sig<{Pattern("C#", size)}>" + "{ public static Archetype archetype; }");
                        }
                    }
                    writer.WriteLine("}");
                }
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
                    writer.WriteLine("using Delegates;");
                    writer.WriteLine("");
                    writer.WriteLine("public partial class Query");
                    writer.WriteLine("{");
                    {
                        writer.WriteLine("/// <summary>");
                        writer.WriteLine($"/// Allows iteration of components in query, can add up to {count} components");
                        writer.WriteLine("/// </summary>");
                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                                writer.WriteLine("Update();");
                                writer.WriteLine("World.AllowStructuralChanges = false;");
                                writer.WriteLine("for (int i = archetype_count - 1; i >= 0; --i)"); // for some reason iterating backwards doubles the performance on my machine
                                    writer.WriteLine("{");                                          // I suspect because the compiler can ignore array bounds checks
                                    writer.WriteLine("var archetype = matching_archetypes[i];");    // since it only needs to make sure archetype_count -1 has to be within the bounds
                                    writer.WriteLine($"if (archetype.entity_count > 0 {Pattern("&& archetype.TryGetPool<C#>(out var pool_c#)", size, false)})");
                                    writer.WriteLine("for(int e = archetype.entity_count; e >= 0; -- e)");
                                    writer.WriteLine($"action({Pattern("ref pool_c#.Values[e]", size)});");
                                    writer.WriteLine("}");
                                writer.WriteLine("World.AllowStructuralChanges = true;");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }

                        writer.WriteLine("public void Foreach(in entity_query action)");
                        writer.WriteLine("{");
                            writer.WriteLine("Update();");
                            writer.WriteLine("World.AllowStructuralChanges = false;");
                            writer.WriteLine("for (int i = archetype_count - 1; i >= 0; --i)");
                            writer.WriteLine("{");
                                writer.WriteLine("var archetype = matching_archetypes[i];");
                                writer.WriteLine("for(int e = archetype.entity_count - 1; e >= 0; --e)");
                                writer.WriteLine("action(archetype.entity_pool.Values[e]);");
                            writer.WriteLine("}");
                            writer.WriteLine("World.AllowStructuralChanges = true;");
                        writer.WriteLine("}");
                        writer.WriteLine("");

                        for(int size = 1; size < count + 1; ++ size)
                        {
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in entity_query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                                writer.WriteLine("Update();");
                                writer.WriteLine("World.AllowStructuralChanges = false;");
                                writer.WriteLine("for (int i = archetype_count - 1; i >= 0; --i)");
                                    writer.WriteLine("{");
                                    writer.WriteLine("var archetype = matching_archetypes[i];");
                                    writer.WriteLine($"if (archetype.entity_count > 0 {Pattern("&& archetype.TryGetPool<C#>(out var pool_c#)", size, false)})");
                                    writer.WriteLine("for(int e = archetype.entity_count - 1; e >= 0; -- e)");
                                    writer.WriteLine($"action(archetype.entity_pool.Values[e], {Pattern("ref pool_c#.Values[e]", size)});");
                                    writer.WriteLine("}");
                                writer.WriteLine("World.AllowStructuralChanges = true;");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }
                    }
                    writer.WriteLine("}");

                    
                    writer.WriteLine("");
                    writer.WriteLine("public partial class Archetype");
                    writer.WriteLine("{");
                    {
                        writer.WriteLine("public void Foreach(in entity_query action)");
                        writer.WriteLine("{");
                        writer.WriteLine("if (entity_count > 0)");
                        {
                            writer.WriteLine("{");
                            writer.WriteLine("for (int i = entity_count - 1; i >= 0; --i)");
                            writer.WriteLine("action(entity_pool.Values[i]);");
                            writer.WriteLine("}");
                        }
                        writer.WriteLine("}");

                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                            writer.WriteLine("if (entity_count > 0" + Pattern("&& TryGetPool<C#>(out var pool_c#)", size, false) + ")");
                                writer.WriteLine("{");
                                writer.WriteLine("for (int i = entity_count - 1; i >= 0; --i)");
                                writer.WriteLine($"action({Pattern("ref pool_c#.Values[i]", size)});");
                                writer.WriteLine("}");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }
                        for (int size = 1; size < count; ++ size)
                        {
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in entity_query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                            writer.WriteLine("if (entity_count > 0" + Pattern("&& TryGetPool<C#>(out var pool_c#)", size, false) + ")");
                            {
                                writer.WriteLine("{");
                                writer.WriteLine("for (int i = entity_count - 1; i >= 0; --i)");
                                writer.WriteLine($"action(entity_pool.Values[i], {Pattern("ref pool_c#.Values[i]", size)});");
                                writer.WriteLine("}");
                            }
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }
                    }
                    writer.WriteLine("}");
                    
                    writer.WriteLine("namespace Delegates");
                    writer.WriteLine("{");
                    {
                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public delegate void query<{Pattern("C#", size)}>({Pattern("ref C# c#", size)});");
                        }
                        writer.WriteLine("");
                        writer.WriteLine($"public delegate void entity_query(Entity entity);");
                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public delegate void entity_query<{Pattern("C#", size)}>(Entity entity, {Pattern("ref C# c#", size)});");
                        }
                    }
                    writer.WriteLine("}");
                }
                writer.WriteLine("}");
            }
        }
    }
}