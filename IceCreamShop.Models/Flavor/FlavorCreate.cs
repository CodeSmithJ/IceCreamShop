using IceCreamShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Flavor
{
    public class FlavorCreate
    {
        public int FlavorId { get; set; }
        public ICFlavor ICFlavor { get; set; }
        public double Price { get; set; }
        public string FlavorName { get; set; }
    }
}
