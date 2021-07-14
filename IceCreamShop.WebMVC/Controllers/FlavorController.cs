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
    [Authorize]
    public class FlavorController : Controller
    {
        // GET: Flavor
        public ActionResult Index()
        {
            var service = CreateFlavorService();
            var model = service.GetFlavor();

            return View(model);
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

            var service = CreateFlavorService();

            if (service.CreateFlavor(model))
            {
                TempData["SaveResult"] = "Your Flavor was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Flavor could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var flavor = CreateFlavorService().GetFlavorById(id);
            return View(flavor);
        }

        public ActionResult Edit(int id = 0)
        {
            var flavor = CreateFlavorService().GetFlavorById(id);
            return View(new FlavorEdit
            {
                FlavorId = flavor.FlavorId,
                FlavorName = flavor.FlavorName,
                Price = flavor.Price
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FlavorEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.FlavorId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateFlavorService().UpdateFlavor(model))
            {
                TempData["SaveResult"] = "Flavor Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Updating Flavor");
            return View(model);
        }

        public ActionResult Delete(int id = 0)
        {
            if (id == 0)
            {
                return Content("<h1>ID missing </h1>");
            }
            var service = CreateFlavorService();
            if (service.DeleteFlavor(id))
                TempData["SaveResult"] = "Your Flavor Is Deleted";
            else
                TempData["SaveResult"] = "Your Flavor WAS NOT Deleted";

            return RedirectToAction("Index");
        }

        private FlavorService CreateFlavorService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FlavorService(userId);
            return service;
        }
    }
}