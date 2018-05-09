using AopExample.Entities;
using AopExample.Proxies;
using AopExample.Proxies.Actions;

namespace AopExample.Repository
{
    public class RepositoryFactory<T>
    {
        public static IRepository<T> Create()
        {
            var decorated = new Repository<T>();
            var proxy = DynamicProxy<IRepository<T>>.Create(decorated, new LoggerProxyActions());
            return proxy;
        }
    }
}