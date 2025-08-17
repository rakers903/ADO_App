using Application.Abstractions.Customers;
using Application.Models;
using ConsoleUI.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels.Application
{
    public class DefaultApplicationViewModel(
        ICreateCustomerUseCase createCustomerUseCase,
        IGetAllCustomersUseCase getAllCustomersUseCase
    ) : IApplicationViewModel
    {
        private readonly ICreateCustomerUseCase _createCustomerUseCase = createCustomerUseCase;
        private readonly IGetAllCustomersUseCase _getAllCustomersUseCase = getAllCustomersUseCase;

        public void SaveCustomer(string firstName, string lastName)
        {
            _createCustomerUseCase.Execute(firstName, lastName);
        }
        public List<CustomerResponse> GetAll()
        {
            try
            {
                return _getAllCustomersUseCase.Execute();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("IMPLEMENT LOGGIN!!!", ex);
                throw;
            }
        }
    }
}
