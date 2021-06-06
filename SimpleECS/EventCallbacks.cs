namespace SimpleECS
{
    using Delegates;

    namespace Delegates
    {
        public delegate void ComponentCallback<T>(Entity entity, ref T component);
    }

    internal class OnSet<T>
    {
        static OnSet() // needed for static struct constructors to behave properly
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }

        public static ComponentCallback<T> Callback;
    }

    internal class OnRemove<T>
    {
        static OnRemove()
        {
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(T).TypeHandle);
        }
        public static ComponentCallback<T> Callback;
    }
}