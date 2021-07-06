using IceCreamShop.Data;
using IceCreamShop.Models.Topping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    public class ToppingService
    {
        public bool CreateTopping(ToppingCreate create)
        {
            var entity =
                new Topping()
                {
                    ToppingName = create.ToppingName,
                    Price = create.Price,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Toppings.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ToppingListItem> GetToppings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Toppings
                    .Select(
                        e =>
                        new ToppingListItem
                        {
                            ToppingId = e.ToppingId,
                            ToppingName = e.ToppingName,
                            Price = e.Price
                        });
                return query.ToArray();

            }
        }

        public ToppingDetails GetToppingById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Toppings
                    .Single(e => e.ToppingId == id);
                return
                    new ToppingDetails
                    {
                        ToppingId = entity.ToppingId,
                        ToppingName = entity.ToppingName,
                        Price = entity.Price
                    };
            }
        }

        public bool UpdateTopping(ToppingEdit edit)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Toppings
                    .Single(e => e.ToppingId == edit.ToppingId);
                entity.ToppingName = edit.ToppingName;
                entity.Price = edit.Price;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTopping(int toppingId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Toppings
                    .Single(e => e.ToppingId == toppingId);
                ctx.Toppings.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
