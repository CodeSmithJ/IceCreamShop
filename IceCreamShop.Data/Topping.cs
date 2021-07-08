using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public enum ICTopping { Caramel, HotFudge, WhippedCream, Cherry }
    public class Topping
    {
        public int ToppingId { get; set; }
        public string ToppingName { get; set; }
        public double Price { get; set; }
        public ICTopping ICTopping { get; set; }
    }
}
