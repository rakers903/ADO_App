using Application.Abstractions.Customers;
using Application.Extensions;
using Application.Models;
using Domain.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers
{
    public class DefaultGetAllCustomersUseCase : IGetAllCustomersUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public DefaultGetAllCustomersUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public List<CustomerResponse> Execute()
        {
            try
            {
                return _customerRepository
                        .GetAll()
                        .Select(entity => entity.ToResponse())
                        .ToList();
            }
            catch(Exception ex)
            {
                Console.WriteLine("IMPLEMENT LOGGING!!", ex);
                throw;
            }
        }
    }
}
