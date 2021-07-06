using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.IceCreamOrder
{
    public class IceCreamOrderCreate
    {
        public int IceCreamOrderId { get; set; }
        public int FlavorId { get; set; }
        public int ToppingId { get; set; }
        public int CustomerId { get; set; }
    }
}
