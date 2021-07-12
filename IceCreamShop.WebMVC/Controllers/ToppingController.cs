using IceCreamShop.Models.Topping;
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
    public class ToppingController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            var service = CreateToppingService();
            var model = service.GetToppings();

            return View(model);
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

            var service = CreateToppingService();

            if (service.CreateTopping(model))
            {
                TempData["SaveResult"] = "Your Topping was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Topping could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var topping = CreateToppingService().GetToppingById(id);
            return View(topping);
        }

        public ActionResult Edit(int id)
        {
            var topping = CreateToppingService().GetToppingById(id);
            return View(new ToppingEdit
            {
                ToppingId = topping.ToppingId,
                ToppingName = topping.ToppingName,
                Price = topping.Price
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ToppingEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ToppingId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateToppingService().UpdateTopping(model))
            {
                TempData["SaveResult"] = "Topping Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Updating a topping");
            return View(model);
        }

        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return Content("<h1>ID missing </h1>");
            }
            var service = CreateToppingService();
            if (service.DeleteTopping(id))
                TempData["SaveResult"] = "Your Topping Is Deleted";
            else
                TempData["SaveResult"] = "Your Topping WAS NOT Deleted";

            return RedirectToAction("Index");
        }

        private ToppingService CreateToppingService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ToppingService();
            return service;
        }
    }
}