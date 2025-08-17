using Application.Abstractions.Customers;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Customers
{
    public class DefaultCreateCustomerUseCase : ICreateCustomerUseCase
    {
        private readonly ICustomerRepository _customerRepository;
        public DefaultCreateCustomerUseCase(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public void Execute(string firstName, string lastName)
        {
            Console.WriteLine($"Executing Create Customer Use Case: {firstName}, {lastName}");            
            try
            {
                Customer customer = new Customer(firstName, lastName);
                _customerRepository.Save(customer);
            }
            catch(Exception ex)
            {
                Console.WriteLine("IMPLEMENT LOGGING!!!", ex);
            }
        }
    }
}
