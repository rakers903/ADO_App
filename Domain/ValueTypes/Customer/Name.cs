using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueTypes.Customer
{
    public class Name
    {
        private readonly string _value;
        public Name(string value)
        {
            if(string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Name cannot be null or whitespace");
            }
            _value = value.ToLower();
        }
        public string Value {
            get => _value;
        }
    }
}
