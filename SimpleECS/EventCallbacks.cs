namespace SimpleECS
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    [AttributeUsage(AttributeTargets.Method)]
    class OnSetCallback : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    class OnRemoveCallback : Attribute { }

    internal class EntityCallbacks
    {
        internal static List<MethodInfo> on_set = new List<MethodInfo>();
        internal static List<MethodInfo> on_remove = new List<MethodInfo>();
        static EntityCallbacks()
        {
            foreach (var type in Assembly.GetExecutingAssembly().GetTypes())    // if using multiple assemblies this may break
            {                                                                   // but adds like a second if searching through all assemblies
                if (type.IsGenericType) continue;
                foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
                {
                    var p = method.GetParameters();
                    if (p.Length != 2) continue;
                    if (method.IsGenericMethod) continue;

                    if (p[0].ParameterType != typeof(Entity)) continue;
                    if (!p[1].ParameterType.IsByRef || p[1].IsOut) continue;

                    if (method.GetCustomAttribute<OnSetCallback>() != null)
                    {
                        if (!method.IsStatic) throw new Exception($"{method.DeclaringType}.{method.Name} is marked as {nameof(OnSetCallback)} but is not static");
                        on_set.Add(method);
                    }
                    if (method.GetCustomAttribute<OnRemoveCallback>() != null)
                    {
                        if (!method.IsStatic) throw new Exception($"{method.DeclaringType}.{method.Name} is marked as {nameof(OnRemoveCallback)} but is not static");
                        on_remove.Add(method);
                    }
                }
            }

        }
    }

    internal class EntityCallbacks<Component> : EntityCallbacks
    {
        public static Delegates.entity_query<Component> OnSet;
        public static Delegates.entity_query<Component> OnRemove;

        static EntityCallbacks()
        {
            foreach (var method in on_set)
            {
                if (method.GetParameters()[1].ParameterType.GetElementType() == typeof(Component))
                    OnSet += (Delegates.entity_query<Component>)Delegate.CreateDelegate(typeof(Delegates.entity_query<Component>), null, method);

            }

            foreach (var method in on_remove)
            {
                if (method.GetParameters()[1].ParameterType.GetElementType() == typeof(Component))
                    OnRemove += (Delegates.entity_query<Component>)Delegate.CreateDelegate(typeof(Delegates.entity_query<Component>), null, method);
            }
        }
    }
}