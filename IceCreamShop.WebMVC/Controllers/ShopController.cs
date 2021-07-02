using IceCreamShop.Models;
using IceCreamShop.Models.Shop;
using IceCreamShop.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            return View(CreateShopService().GetShops());
        }

        public ActionResult Create()
        {
            ViewBag.Title = "New Shop";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ShopCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            if (CreateShopService().CreateShop(model))
            {
                TempData["SaveResult"] = "Shop Established";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error making a shop");
            return View(model);
        }

        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            return service;
        }
    }
}