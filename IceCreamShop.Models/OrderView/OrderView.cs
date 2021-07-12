using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.OrderView
{
    public class OrderView
    {
        public int IceCreamOrderId { set; get; }
        public int CustomerId { set; get; }
        public string FlavorName { get; set; }
        public string ToppingName { get; set; }
        public double Price { get; set; }
        public double FlavorPrice { get; set; }
        public double ToppingPrice { get; set; }
        public string CustomerName { get; set; }
        public string Payment { get; set; }

        public string PriceC2 ()
        {
                return Price.ToString("C2") ;
        }
        public string FlavorPriceC2()
        {
            return FlavorPrice.ToString("C2");
        }
        public string ToppingPriceC2()
        {
            return ToppingPrice.ToString("C2");
        }
    }
}
