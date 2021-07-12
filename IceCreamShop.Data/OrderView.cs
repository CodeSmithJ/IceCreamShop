using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public class OrderView
    {
        [Key]
        public int OrderViewId { get; set; }
        public int IceCreamOrderId { set; get; }
        public int CustomerId { set; get; }
        public string FlavorName { get; set; }
        public string ToppingName { get; set; }
        public double Price { get; set; }
        public double FlavorPrice { get; set; }
        public double ToppingPrice { get; set; }
        public string CustomerName { get; set; }
        public string Payment { get; set; }
    }
}
