using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public record class CustomerResponse(
        Guid Id,
        string FirstName,
        string LastName
    );
}
