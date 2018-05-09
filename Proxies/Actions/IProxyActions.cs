using System;
using System.Reflection;

namespace AopExample.Proxies.Actions
{
    public interface IProxyActions
    {
        void OnActionExecution(MethodInfo targetMethod, object[] args);
        void OnActionExecuted(MethodInfo targetMethod, object[] args);
        void OnError(MethodInfo targetMethod, object[] args, Exception e);
    }
}
