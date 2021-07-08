using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Shop
{
    public class ShopEdit
    {
        [Key]
        public int ShopId { get; set; }
        public Guid OwnerId { get; set; }
        public string IceCreamOrderId { get; set; }
        public double TotalPrice { get; set; }
        public string ShopName { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
