using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public class IceCreamOrder
    {
        public int IceCreamOrderId { get; set; }
        public int FlavorId { get; set; }
        public int ToppingsId { get; set; }
        public int CustomerId { get; set; }
    }
}
