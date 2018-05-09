using System;
using System.Reflection;

namespace AopExample.Proxies.Actions
{
    public class LoggerProxyActions : IProxyActions
    {
        public void OnActionExecuted(MethodInfo targetMethod, object[] args)
        {
            Log($"In Dynamic Proxy - After executing '{targetMethod.Name}' ");
        }

        public void OnActionExecution(MethodInfo targetMethod, object[] args)
        {
            Log($"In Dynamic Proxy - Before executing '{targetMethod.Name}'");
        }

        public void OnError(MethodInfo targetMethod, object[] args, Exception e)
        {
            Log($"In Dynamic Proxy- Exception {e} executing '{targetMethod.Name}'");
        }

        private static void Log(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }
    }
}