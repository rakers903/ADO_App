using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.ViewModels.Abstractions
{
    public interface IApplicationViewModel
    {
        public void SaveCustomer(string firstName, string lastName);
        public List<CustomerResponse> GetAll();
    }
}
