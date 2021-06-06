namespace SimpleECS
{
    using Delegates;

    internal sealed class OnSet<T>
    {
        static OnSet() // needed for static struct constructors to behave properly
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }

        public static ComponentCallback<T> Callback;
    }

    internal sealed class OnRemove<T>
    {
        static OnRemove()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }
        public static ComponentCallback<T> Callback;
    }

    namespace Delegates
    {
        /// <summary>
        /// Delegate used for Component Events
        /// </summary>
        /// <param name="entity">Entity calling the event</param>
        /// <param name="component">Component used in the event</param>
        public delegate void ComponentCallback<T>(Entity entity, ref T component);
    }
}