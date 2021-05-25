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
        internal static List<MethodInfo> SetCallbacks = new List<MethodInfo>();
        internal static List<MethodInfo> RemoveCallbacks = new List<MethodInfo>();
        
        static EntityCallbacks()
        {
            List<MethodInfo> methods = new List<MethodInfo>();
            foreach (var assembly in System.AppDomain.CurrentDomain.GetAssemblies())
                foreach (var type in assembly.GetTypes())
                {
                    if (type.IsGenericType) continue;
                    foreach (var method in type.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic))
                    {
                        var p = method.GetParameters();
                        if (p.Length != 2) continue;
                        if (p[0].ParameterType != typeof(Entity)) continue;
                        if (!p[1].ParameterType.IsByRef || p[1].IsOut) continue;

                        if (method.GetCustomAttributes<OnSetCallback>() != null)
                            SetCallbacks.Add(method);
                        if (method.GetCustomAttributes<OnRemoveCallback>() != null)
                            RemoveCallbacks.Add(method);
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
            foreach (var method in SetCallbacks)
            {
                if (method.GetParameters()[1].ParameterType.GetElementType() == typeof(Component))
                    OnSet += (Delegates.entity_query<Component>)Delegate.CreateDelegate(typeof(Delegates.entity_query<Component>), null, method);
                
            }

            foreach (var method in RemoveCallbacks)
            {
                if (method.GetParameters()[1].ParameterType.GetElementType() == typeof(Component))
                    OnRemove += (Delegates.entity_query<Component>)Delegate.CreateDelegate(typeof(Delegates.entity_query<Component>), null, method);
            }
        }
    }
}