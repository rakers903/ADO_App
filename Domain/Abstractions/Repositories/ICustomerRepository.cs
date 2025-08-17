using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Abstractions.Repositories
{
    public interface ICustomerRepository
    {
        public void Save(Customer customer);
        public List<Customer> GetAll();
    }
}
