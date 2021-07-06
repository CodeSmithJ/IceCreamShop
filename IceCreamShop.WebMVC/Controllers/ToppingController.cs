using IceCreamShop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    public class ToppingController : Controller
    {
        // GET: Topping
        public ActionResult Index()
        {
            return View(CreateToppingService().GetToppings());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Topping";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ToppingCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateToppingService().CreateTopping(model))
            {
                TempData["SaveResult"] = "Topping Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Topping Create Error");
            return View(model);
        }

        private ToppingService CreateToppingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToppingService(userId);
            return service;
        }
    }
}
}