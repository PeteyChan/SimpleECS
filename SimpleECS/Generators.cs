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

                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine("public static Entity Create<" + Pattern("C#", size) + ">(");
                            writer.WriteLine(Pattern("C# c#", size) + ")");
                            writer.WriteLine("=> Sig<" + Pattern("C#", size) + ">.CreateEntity(");
                            writer.WriteLine(Pattern("c#", size) + ");");
                            writer.WriteLine("class Sig<" + Pattern("C#", size) + ">");
                            writer.WriteLine("{");
                            writer.WriteLine("static Archetype archetype;");
                            writer.WriteLine("public static Entity CreateEntity(" + Pattern("C# c#", size) + ")");
                            writer.WriteLine("{");
                            writer.WriteLine("if (!archetype)");
                            writer.WriteLine("archetype = World.GetArchetype(new TypeSignature(" + Pattern("typeof(C#)", size) + "));");
                            writer.WriteLine("return archetype.CreateEntity()" + Pattern(".Set(c#)", size, false) + ";");
                            writer.WriteLine("}");
                            writer.WriteLine("}");
                            writer.WriteLine("");
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
                    writer.WriteLine("using SimpleECS.Internal;");
                    writer.WriteLine("");
                    writer.WriteLine("public partial class Query");
                    writer.WriteLine("{");
                    {
                        writer.WriteLine("public void Foreach(in entity_query action)");
                        writer.WriteLine("{");
                        writer.WriteLine("Refresh();");
                        writer.WriteLine("World.AllowStructuralChanges = false;");
                        writer.WriteLine("for(int i = archetype_count - 1; i >= 0; --i)");
                        writer.WriteLine("matching_archetypes[i].Foreach(action);");
                        writer.WriteLine("World.AllowStructuralChanges = true;");
                        writer.WriteLine("}");

                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                            writer.WriteLine("Refresh();");
                            writer.WriteLine("World.AllowStructuralChanges = false;");
                            writer.WriteLine("for(int i = archetype_count - 1; i >= 0; --i)");
                            writer.WriteLine("matching_archetypes[i].Foreach(action);");
                            writer.WriteLine("World.AllowStructuralChanges = true;");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                            writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in entity_query<{Pattern("C#", size)}> action)");
                            writer.WriteLine("{");
                            writer.WriteLine("Refresh();");
                            writer.WriteLine("World.AllowStructuralChanges = false;");
                            writer.WriteLine("for(int i = archetype_count - 1; i >= 0; --i)");
                            writer.WriteLine("matching_archetypes[i].Foreach(action);");
                            writer.WriteLine("World.AllowStructuralChanges = true;");
                            writer.WriteLine("}");
                            writer.WriteLine("");
                        }
                    }
                    writer.WriteLine("}");

                    writer.WriteLine("namespace Internal");
                    writer.WriteLine("{");
                    {
                        writer.WriteLine($"public delegate void entity_query(in Entity entity);");
                        for (int size = 1; size < count + 1; ++size)
                        {
                            writer.WriteLine($"public delegate void query<{Pattern("C#", size)}>({Pattern("ref C# c#", size)});");
                            writer.WriteLine($"public delegate void entity_query<{Pattern("C#", size)}>(in Entity entity, {Pattern("ref C# c#", size)});");
                        }

                        writer.WriteLine("");
                        writer.WriteLine("public partial class Archetype");
                        writer.WriteLine("{");
                        {
                            writer.WriteLine("public void Foreach(in entity_query action)");
                            writer.WriteLine("{");
                            writer.WriteLine("if (entity_count > 0)");
                            {
                                writer.WriteLine("{");
                                writer.WriteLine("for(int i = entity_count - 1; i >= 0; --i)");
                                writer.WriteLine("action(entity_pool.Values[i]);");
                                writer.WriteLine("}");
                            }
                            writer.WriteLine("}");

                            for (int size = 1; size < count + 1; ++size)
                            {
                                writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in query<{Pattern("C#", size)}> action)");
                                writer.WriteLine("{");
                                writer.WriteLine("if (entity_count > 0" + Pattern("&& TryGetPool<C#>(out var pool_c#)", size, false)+")");
                                {
                                    writer.WriteLine("{");
                                    writer.WriteLine("for(int i = entity_count - 1; i >= 0; --i)");
                                    writer.WriteLine($"action({Pattern("ref pool_c#.Values[i]", size)});");
                                    writer.WriteLine("}");
                                }
                                writer.WriteLine("}");

                                writer.WriteLine($"public void Foreach<{Pattern("C#", size)}>(in entity_query<{Pattern("C#", size)}> action)");
                                writer.WriteLine("{");
                                writer.WriteLine("if (entity_count > 0" + Pattern("&& TryGetPool<C#>(out var pool_c#)", size, false)+")");
                                {
                                    writer.WriteLine("{");
                                    writer.WriteLine("for(int i = entity_count - 1; i >= 0; --i)");
                                    writer.WriteLine($"action(entity_pool.Values[i], {Pattern("ref pool_c#.Values[i]", size)});");
                                    writer.WriteLine("}");
                                }
                                writer.WriteLine("}");
                            }
                        }
                        writer.WriteLine("}");
                    }
                    writer.WriteLine("}");
                }
                writer.WriteLine("}");
            }
        }
    }
}