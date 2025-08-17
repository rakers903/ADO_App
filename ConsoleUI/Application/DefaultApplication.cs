using Application.Models;
using ConsoleUI.ViewModels.Abstractions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Application
{
    public class DefaultApplication: IApplication
    {
        private readonly IApplicationViewModel _applicationViewModel;
        public DefaultApplication(IApplicationViewModel applicationViewModel)
        {
            _applicationViewModel = applicationViewModel;
        }
        public void Start()
        {
            Console.WriteLine("***** Application *****");
            Console.WriteLine("Creating customer");
            bool shouldRun = true;
            while(shouldRun)
            {
                List<CustomerResponse> customers = _applicationViewModel.GetAll();
                Console.WriteLine("*** Customer List ***");
                Console.WriteLine("______________________");
                customers.ForEach(c =>
                {
                    Console.WriteLine($"Id: {c.Id}, First Name: {c.FirstName}, Last Name: {c.LastName}");
                });
                Console.WriteLine("______________________");

                try
                {
                    Console.WriteLine("Please enter the customers first name");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Please enter the customers last name");
                    string lastName = Console.ReadLine();
                    if (firstName != null && lastName != null)
                    {
                        _applicationViewModel.SaveCustomer(firstName, lastName);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("IMPLEMENT LOGGING!", ex);
                }
                Console.WriteLine("Do you want to continue?");
                string answer = Console.ReadLine();
                if(answer?.ToLower() == "y")
                {
                    shouldRun = true;
                }
                else
                {
                    shouldRun = false;
                }
            }
        }
    }
}
