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
            var service = CreateShopService();
            var model = service.GetShops();

            return View(model);
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

            var service = CreateShopService();

            if (service.CreateShop(model))
            {
                TempData["SaveResult"] = "Your Shop was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Shop could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var shop = CreateShopService().GetShopDetailsById(id);
            return View(shop);
        }

        public ActionResult Edit(int id)
        {
            var shop = CreateShopService().GetShopDetailsById(id);
            return View(new ShopEdit
            {
                ShopId = shop.ShopId,
                ShopName = shop.ShopName
            });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ShopEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ShopId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateShopService().UpdateShop(model))
            {
                TempData["SaveResult"] = "Shop Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Updating a shop");
            return View(model);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var service = CreateShopService();
            service.DeleteShop(id);
            TempData["SaveResult"] = "Your Shop Is Deleted";

            return RedirectToAction("Index");
        }

        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            return service;
        }
    }
}