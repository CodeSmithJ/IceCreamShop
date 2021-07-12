using IceCreamShop.Data;
using IceCreamShop.Models;

using IceCreamShop.Models.Shop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    public class ShopService
    {
        private readonly Guid _userId;
        public ShopService(Guid userId)
        {
            _userId = userId;
        }

        public ShopDetails GetShopById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shops
                    .Single(e => e.ShopId == id);
                return new ShopDetails
                {
                    ShopId = entity.ShopId,
                    ShopName = entity.ShopName,

                    CreatedUtc = entity.CreatedUtc,
                    ModifiedUtc=entity.ModifiedUtc,
                    TotalPrice =entity.TotalPrice
                };
            }
        }

        public bool CreateShop(ShopCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newShop = new Shop()
                {
                    OwnerId = _userId,
                    ShopName = model.ShopName,
                    CreatedUtc = DateTime.Now
            };
                ctx.Shops.Add(newShop);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ShopListItem> GetShops()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Shops.Select(s => new ShopListItem
                {
                    ShopId = s.ShopId,
                    ShopName = s.ShopName,
                    CreatedUtc = s.CreatedUtc
                });
                return query.ToArray();
            }
        }
        public IEnumerable<IceCreamShop.Models.OrderView.OrderView> GetOrders()
        {
            var shop = 1;
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.OrderViews.Select(s => new IceCreamShop.Models.OrderView.OrderView
                {
                    IceCreamOrderId = s.IceCreamOrderId,
                    CustomerId = s.CustomerId,
                    FlavorName = s.FlavorName,
                    FlavorPrice = s.FlavorPrice,
                    ToppingName = s.ToppingName,
                    ToppingPrice = s.ToppingPrice,
                    Price = s.Price,
                    CustomerName = s.CustomerName,
                    Payment = s.Payment
                });
                return query.ToArray();
            }
        }
        public bool UpdateShop(ShopEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var shop = ctx.Shops.Single(m => m.ShopId == model.ShopId);

                shop.ShopId = model.ShopId;
                shop.ShopName = model.ShopName;
                shop.ModifiedUtc = DateTime.Now;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShop(int id)
        {
            try
            {
                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                        .Shops
                        .Single(e => e.ShopId == id);
                    ctx.Shops.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }
            }catch (Exception e)
            {
                return false;
            }
        }
    }
}
