using Domain.Abstractions.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly Dictionary<Guid, Customer> data = new();

        public List<Customer> GetAll()
        {
            return data.Values.ToList();
        }

        public void Save(Customer customer)
        {
            data.Add(customer.Id, customer);
        }
    }
}
