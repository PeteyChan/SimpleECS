namespace SimpleECS
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    /// <summary>
    /// Put the attribute on a static method in a non Generic class to recieve callbacks whenever an entity sets a component.
    /// The method signature needs to be in the form of (Entity entity, ref C component) where C is the component type that 
    /// you wish to get callbacks from
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnSetCallback : Attribute { }

    /// <summary>
    /// Put the attribute on a static method in a non Generic class to recieve callbacks whenever an entity removes a component.
    /// The method signature needs to be in the form of (Entity entity, ref C component) where C is the component type that 
    /// you wish to get callbacks from
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class OnRemoveCallback : Attribute { }

    internal class EntityCallbacks
    {
        internal static List<MethodInfo> on_set = new List<MethodInfo>();
        internal static List<MethodInfo> on_remove = new List<MethodInfo>();
        static EntityCallbacks()
        {
            foreach (var assem in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                var name = assem.FullName.ToLower();
                if (name.StartsWith("system")) continue;        // quick hack to make searching assemblies fast by not searching through default ones
                if (name.StartsWith("netstandard")) continue;   // without this it can take 2 or more seconds to go through all the assemblies
                if (name.StartsWith("mscorlib")) continue;      // this does have the unfortunate side effect that your own assemblies
                if (name.StartsWith("unity")) continue;         // can't start with any of these values if you want to use the callback events
                if (name.StartsWith("godot")) continue;         // maybe manually subscribing is better?

                foreach (var type in assem.GetTypes())
                {
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