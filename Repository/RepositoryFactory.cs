using AopExample.Entities;
using AopExample.Proxies;

namespace AopExample.Repository
{
    public class RepositoryFactory<T>
    {
        public static IRepository<T> Create()
        {
            var decorated = new Repository<T>();
            var proxy = DynamicProxy<IRepository<T>>.Create(decorated);
            return proxy;
        }
    }
}