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
                    .Single(e => e.ShopId == id/* && e.OwnerId == _userId*/);
                return new ShopDetails
                {
                    ShopId = entity.ShopId,
                    ShopName = entity.ShopName
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
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShop(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Shops
                    .Single(e => e.ShopId == id && e.OwnerId == _userId);
                ctx.Shops.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
