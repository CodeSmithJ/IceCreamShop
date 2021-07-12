using IceCreamShop.Data;
using IceCreamShop.Models.IceCreamOrder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IceCreamShop.Services
{
    public class IceCreamOrderService
    {
        public bool CreateIceCreamOrder(IceCreamOrderCreate model)
        {
            var entity = new IceCreamOrder()
            {
                FlavorId = model.FlavorId,
                ToppingsId = model.ToppingId,
                CustomerId = model.CustomerId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IceCreamOrders.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<SelectList> GetFlavors()
        {

            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Flavors
                    .Select(
                        e =>
                        new SelectList
                        {
                            Value = e.FlavorId,
                            Text = e.FlavorName + "(" + e.Price + ")"

                        }); ;
                return query.ToArray();

            }

        }
        public IEnumerable<SelectList> GetToppings()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Toppings
                    .Select(
                        e =>
                        new SelectList
                        {
                            Value = e.ToppingId,
                            Text = e.ToppingName + "(" + e.Price + ")"
                           
                        });
                return query.ToArray();

            }
        }
        public IEnumerable<SelectList> GetToppings_v1()
        {
            List<SelectList> items = new List<SelectList>();

            SelectList item = new SelectList()
            {
                Text = "Hot Chocolate",
                Value = 1
            };

            items.Add(item);
            item = new SelectList()
            {
                Text = "Cherry",
                Value = 2
            };
            items.Add(item);
            return items;
        }
        public IEnumerable<IceCreamOrderListItem> GetIceCreamOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.IceCreamOrders.Select(e => new IceCreamOrderListItem()
                {
                    IceCreamOrderId = e.IceCreamOrderId,
                });
                return query.ToList();
            }
        }
        public IEnumerable<IceCreamOrderListItem> GetIceCreamOrders(int shopId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.IceCreamOrders.Select(e => new IceCreamOrderListItem()
                {
                    IceCreamOrderId = e.IceCreamOrderId,
                });
                return query.ToList();
            }
        }
        public IceCreamOrderDetails GetIceCreamOrderById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.IceCreamOrders.Single(e => e.IceCreamOrderId == id);

                return
                    new IceCreamOrderDetails()
                    {
                        IceCreamOrderId = entity.IceCreamOrderId,
                    };
            }
        }

        public bool UpdateIceCreamOrder(IceCreamOrderEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .IceCreamOrders
                        .Single(e => e.IceCreamOrderId == model.IceCreamOrderId);

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIceCreamOrder(int iceCreamOrderId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .IceCreamOrders
                        .Single(e => e.IceCreamOrderId == iceCreamOrderId);

                ctx.IceCreamOrders.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
