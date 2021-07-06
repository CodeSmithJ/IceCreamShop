using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public Guid CustomerGuid { get; set; }
        public string CustomerName { get; set; }
        public string Payment { get; set; }
    }
}
