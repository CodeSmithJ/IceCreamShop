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

        public ActionResult Details(int id = 0)
        {
            var customer = CreateCustomerService().GetCustomerById(id);
            return View(customer);
        }

        public ActionResult Edit(int id = 0)
        {
            var customer = CreateCustomerService().GetCustomerById(id);
            return View(new CustomerEdit
            {
                CustomerId = customer.CustomerId,
                CustomerName = customer.CustomerName,
                Payment = customer.Payment
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CustomerEdit model)
        {
            if (id == 0)
            {
                return Content("<h1>Enter Customer ID In AddressBar To Confirm Edit... /Customer/Edit/ # <== </h1>");
            }

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

        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return Content("<h1>Enter Customer ID In AddressBar To Confirm Delete... /Customer/Delete/ # <== </h1>");
            }
            var service = CreateCustomerService();
            if (service.DeleteCustomer(id))
                TempData["SaveResult"] = "Your Customer Is Deleted";
            else
                TempData["SaveResult"] = "Your Customer WAS NOT Deleted";

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