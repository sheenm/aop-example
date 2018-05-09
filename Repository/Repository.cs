using System;
using System.Collections.Generic;

namespace AopExample.Repository
{
    public class Repository<T> : IRepository<T>
    {
        public void Add(T entity)
        {
            Console.WriteLine("Adding {0}", entity);
        }
        public void Delete(T entity)
        {
            Console.WriteLine("Deleting {0}", entity);
        }
        public void Update(T entity)
        {
            Console.WriteLine("Updating {0}", entity);
        }
        public IEnumerable<T> GetAll()
        {
            Console.WriteLine("Getting entities");
            return new List<T>();
        }
        public T GetById(int id)
        {
            Console.WriteLine("Getting entity {0}", id);
            return default(T);
        }
    }
}