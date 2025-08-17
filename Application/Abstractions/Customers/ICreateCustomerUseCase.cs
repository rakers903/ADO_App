using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Abstractions.Customers
{
    public interface ICreateCustomerUseCase
    {
        public void Execute(string firstName, string lastName);
    }
}
