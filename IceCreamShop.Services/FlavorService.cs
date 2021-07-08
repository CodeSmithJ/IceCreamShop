using IceCreamShop.Data;
using IceCreamShop.Models.Flavor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    public class FlavorService
    {
        public bool CreateFlavor(FlavorCreate create)
        {
            var entity =
                new Flavor()
                {
                    FlavorName = create.FlavorName,
                    Price = create.Price,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Flavors.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FlavorListItem> GetFlavor()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Flavors
                    .Select(
                        e =>
                        new FlavorListItem
                        {
                            FlavorId = e.FlavorId,
                            FlavorName = e.FlavorName,
                            Price = e.Price
                        });
                return query.ToArray();

            }
        }

        public FlavorDetails GetFlavorById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Flavors
                    .Single(e => e.FlavorId == id);
                return
                    new FlavorDetails
                    {
                        FlavorId = entity.FlavorId,
                        FlavorName = entity.FlavorName,
                        Price = entity.Price
                    };
            }
        }

        public bool UpdateFlavor(FlavorEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Flavors
                    .Single(e => e.FlavorId == edit.FlavorId);
                entity.FlavorName = edit.FlavorName;
                entity.Price = edit.Price;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFlavor(int flavorId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Flavors
                    .Single(e => e.FlavorId == flavorId);
                ctx.Flavors.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
