using IceCreamShop.Models.Flavor;
using IceCreamShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    public class FlavorController : Controller
    {
        // GET: Flavor
        public ActionResult Index()
        {
            return View(CreateFlavorService().GetFlavors());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Flavor";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FlavorCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateFlavorService().CreateFlavor(model))
            {
                TempData["SaveResult"] = "Flavor Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Adding Flavor");
            return View(model);
        }

        private FlavorService CreateFlavorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FlavorService(userId);
            return service;
        }
    }
}