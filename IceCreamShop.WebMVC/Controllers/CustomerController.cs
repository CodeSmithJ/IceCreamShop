using IceCreamShop.Models.Customer;
using IceCreamShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var service = CreateCustomerService();
            var model = service.GetCustomer();

            return View(model);
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Customer";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCustomerService();

            if (service.CreateCustomer(model))
            {
                TempData["SaveResult"] = "Your Customer was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Customer could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var customer = CreateCustomerService().GetCustomerById(id);
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = CreateCustomerService().GetCustomerById(id);
            return View(new CustomerEdit
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Payment = customer.Payment
            });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CustomerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateCustomerService().UpdateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Updating Customer");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateCustomerService();
            service.DeleteCustomer(id);
            TempData["SaveResult"] = "Your Customer Is Deleted";

            return RedirectToAction("Index");
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}