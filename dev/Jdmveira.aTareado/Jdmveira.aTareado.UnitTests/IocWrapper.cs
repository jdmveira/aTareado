namespace Jdmveira.aTareado.Test
{
    using GalaSoft.MvvmLight.Ioc;

    internal static class IocWrapper
    {
        public static void Register<TInterface, TClass> () 
            where TInterface: class
            where TClass: class
        {
            SimpleIoc.Default.Register<TInterface, TClass>();
        }

        public static void Reset ()
        {
            SimpleIoc.Default.Reset();
        }

        public static bool IsRegistered <T> () where T : class
        {
            return SimpleIoc.Default.IsRegistered<T>();
        }

        public static TService GetInstance<TService> () where TService: class
        {
            return SimpleIoc.Default.GetInstance<TService>();
        }
    }
}
