using Domain.ValueTypes.Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            Id = Guid.NewGuid();
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
        }
        public Customer(Guid id, string firstName, string lastName)
        {
            Id = id;
            FirstName = new Name(firstName);
            LastName = new Name(lastName);
        }
        public Guid Id { get; init; }
        public Name FirstName { get; init; }
        public Name LastName { get; init; }
    }
}
