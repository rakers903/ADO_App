using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Extensions
{
    public static class CustomerExtensions
    {
        public static CustomerResponse ToResponse(this Customer c)
        {
            return new CustomerResponse(c.Id, c.FirstName.Value, c.LastName.Value);
        }
    }
}
