using IceCreamShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Topping
{
    public class ToppingCreate
    {
        public int ToppingId { get; set; }
        public ICTopping ICToppings { get; set; }
        public string ToppingName { get; set; }
        public double Price { get; set; }
    }
}
