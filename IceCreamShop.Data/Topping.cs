using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public enum ICToppings { Caramel, Fudge, WhippedCream, Cherry }
    public class Topping
    {
        public int ToppingsId { get; set; }
        public string ToppingsName { get; set; }
        public double Price { get; set; }
        public ICToppings ICToppings { get; set; }
    }
}
