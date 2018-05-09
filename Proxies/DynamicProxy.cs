using System;
using System.Reflection;
using AopExample.Proxies.Actions;

namespace AopExample.Proxies
{
    public class DynamicProxy<T> : DispatchProxy
    {
        private T _decorated;
        private IProxyActions _actions;

        public DynamicProxy() : base()
        {
        }

        public static T Create(T decorated, IProxyActions actions)
        {
            object proxy = DispatchProxy.Create<T, DynamicProxy<T>>();
            ((DynamicProxy<T>)proxy)._decorated = decorated;
            ((DynamicProxy<T>)proxy)._actions = actions;
            return (T)proxy;
        }

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            _actions.OnActionExecution(targetMethod, args);
            try
            {
                var result = targetMethod.Invoke(_decorated, args);
                _actions.OnActionExecuted(targetMethod, args);
                return result;
            }
            catch (Exception e)
            {
                _actions.OnError(targetMethod, args, e);
                throw;
            }
        }
    }
}
