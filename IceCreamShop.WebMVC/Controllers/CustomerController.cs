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
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            return View(CreateCustomerService().GetCustomer());
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

            if (CreateCustomerService().CreateCustomer(model))
            {
                TempData["SaveResult"] = "Customer Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Adding Customer");
            return View(model);
        }

        private CustomerService CreateCustomerService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CustomerService(userId);
            return service;
        }
    }
}