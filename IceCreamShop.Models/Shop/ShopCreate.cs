using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Models.Shop
{
    public class ShopCreate
    {
        [MaxLength(25)]
        public string ShopName { get; set; }
    }
}
