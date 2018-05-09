using System;
using System.Reflection;

namespace AopExample.Proxies
{
    public class DynamicProxy<T> : DispatchProxy
    {
        private T _decorated;
        public DynamicProxy() : base()
        {
        }

        private void Log(string msg, object arg = null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg, arg);
            Console.ResetColor();
        }

        public static T Create(T decorated)
        {
            object proxy = DispatchProxy.Create<T, DynamicProxy<T>>();
            ((DynamicProxy<T>)proxy)._decorated = decorated;
            return (T)proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {

            Log("In Dynamic Proxy - Before executing '{0}'", targetMethod.Name);
            try
            {
                var result = targetMethod.Invoke(_decorated, args);
                Log("In Dynamic Proxy - After executing '{0}' ", targetMethod.Name);
                return result;
            }
            catch (Exception e)
            {
                Log(string.Format("In Dynamic Proxy- Exception {0} executing '{1}'", e), targetMethod.Name);
                throw;
            }
        }
    }
}