using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.IceCreamOrder
{
    public class IceCreamOrderListItem
    {
        public int IceCreamOrderId { get; set; }
        public int FlavorId { get; set; }
        public int ToppingsId { get; set; }
        public int CustomerId { get; set; }
    }
}
