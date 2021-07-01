using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Shop
{
    public class ShopDetails
    {
        [Key]
        public int ShopId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string IceCreamOrderId { get; set; }
        [Required]
        public double TotalPrice { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
    }
}
