using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltaBanca_API_Test.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string Names { get; set; }
        public string Surnames { get; set; }
        public DateTime Birthday { get; set; }
        public string CUIT { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
    }
}
