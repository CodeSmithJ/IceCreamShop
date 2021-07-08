using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Data
{
    public class IceCreamOrder
    {
        [Key]
        public int IceCreamOrderId { get; set; }
        public int FlavorId { get; set; }
        [ForeignKey("FlavorId")]
        public virtual Flavor Flavor { get; set; }
        public int ToppingsId { get; set; }
        [ForeignKey("ToppingId")]
        public virtual Topping Topping { get; set; }

        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}
