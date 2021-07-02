using IceCreamShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Toppings
{
    public class ToppingsCreate
    {
        public int ToppingsId { get; set; }
        public ICToppings ICToppings { get; set; }
        public string ToppingsName { get; set; }
        public double Price { get; set; }
    }
}
