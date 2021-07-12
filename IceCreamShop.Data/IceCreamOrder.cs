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

        [ForeignKey(nameof(Flavor))]
        public int FlavorId { get; set; }
        public virtual Flavor Flavor { get; set; }

        [ForeignKey(nameof(Topping))]
        public int ToppingsId { get; set; }
        public virtual Topping Topping { get; set; }

        [ForeignKey(nameof(Customer))]
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
