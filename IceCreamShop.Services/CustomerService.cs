using IceCreamShop.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IceCreamShop.Services
{
    public class CustomerService
    {
        private readonly Guid _userId;
        public CustomerService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateCustomer(CustomerCreate model)
        {
            var entity =
                new Customer()
                {
                    CustomerGuid = _userId,
                    CustomerName = model.CustomerName,
                    Payment = model.Payment,
                    IceCreamOrderId = model.IceCreamOrderId
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Customers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CustomerList> GetCustomer()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Customers
                    .Select(
                        e =>
                        new CustomerList
                        {
                            CustomerId = e.CustomerId,
                            CustomerName = e.CustomerName,
                            Payment = e.Payment,
                        }
                    );
                return query.ToArray();
            }
        }
        public CustomerDetails GetCustomerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Customers
                    .Single(e => e.CustomerId == id);

                return new CustomerDetails()
                {
                    CustomerId = entity.CustomerId,
                    CustomerName = entity.CustomerName,
                    Payment = entity.Payment,


                };
            }
        }

        public bool UpdateCustomer(CustomerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerTag == _userId);

                entity.CustomerName = model.CustomerName,
                entity.Payment = model.Payment;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteCustomer(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Customers
                    .Single(e => e.CustomerId == id);
                ctx.Customers.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
