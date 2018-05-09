using System;
using AopExample.Entities;
using AopExample.Repository;

namespace AopExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var customerRepository = RepositoryFactory<Customer>.Create();
            var customer = new Customer
            {
                Id = 1,
                Name = "Customer 1",
                Address = "Address 1"
            };
            customerRepository.Add(customer);
            customerRepository.Update(customer);
            customerRepository.Delete(customer);
        }
    }
}
