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
                Created = DateTimeOffset.Now,
                IceCreamOrderId = model.IceCreamOrderId
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.IceCreamOrder.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IceCreamOrderListItem> GetIceCreamOrders()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.IceCreamOrders.Select(e => new IceCreamOrderListItem()
                {
                    IceCreamOrderId = e.IceCreamOrderId,
                    Created = e.Created,
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
                        Created = entity.Created,
                        Edited = entity.Edited,

                        Customer = entity.Customer.Select(e => new Customer()
                        {
                            IceCreamOrderId = entity.IceCreamOrderId,
                            CustomerTag = e.CustomerTag,
                            CustomerId = e.CustomerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            PaymentType = e.PaymentType,
                        }).ToList(),


                        Topping = entity.Topping.Select(e => new Topping()
                        {
                            IceCreamOrderId = entity.IceCreamOrderId,
                            ToppingId = e.ToppingId,
                            ToppingName = e.ToppingName,
                            Price = e.Price,

                        }).ToList(),

                        Flavor = entity.Flavor.Select(e => new Flavor()
                        {
                            IceCreamOrderId = entity.IceCreamOrderId,
                            FlavorName = e.FlavorName,
                            FlavorId = e.FlavorId,
                            Price = e.Price
                        }).ToList()
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

                entity.Edited = DateTimeOffset.Now;

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
