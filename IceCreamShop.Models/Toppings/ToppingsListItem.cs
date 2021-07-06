using IceCreamShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Toppings
{
    public class ToppingsListItem
    {
        public int ToppingId { get; set; }
        public ICToppings ICToppings { get; set; }
        public string ToppingName { get; set; }
        public double Price { get; set; }
    }
}
