using IceCreamShop.Models.IceCreamOrder;
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
    public class IceCreamOrderController : Controller
    {
        // GET: IceCreamOrder
        public ActionResult Index()
        {
            var orders = CreateShopService().GetOrders();
            ViewBag.Orders = orders;
            return View();
        }
        private ShopService CreateShopService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ShopService(userId);
            return service;
        }

        public ActionResult Create(int id =0)
        {
            if (id==0)
            {
                return Content("ID missing");
            }
            ViewBag.Title = "New Order";
            var service = CreateIceCreamOrderService();
            ViewBag.flavors = service.GetFlavors();
            ViewBag.toppings = service.GetToppings();
            IceCreamOrderCreate order = new IceCreamOrderCreate();
            order.CustomerId = id;
            var model = order;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IceCreamOrderCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIceCreamOrderService();

            if (service.CreateIceCreamOrder(model))
            {
                TempData["SaveResult"] = "Your Order was Created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Order could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var order = CreateIceCreamOrderService().GetIceCreamOrderById(id);
            return View(order);
        }

        public ActionResult Edit(int id)
        {
            var order = CreateIceCreamOrderService().GetIceCreamOrderById(id);
            return View(new IceCreamOrderEdit
            {
            });
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IceCreamOrderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IceCreamOrderId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return RedirectToAction("Index");
            }

            if (CreateIceCreamOrderService().UpdateIceCreamOrder(model))
            {
                TempData["SaveResult"] = "Order Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error Updating Order");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var service = CreateIceCreamOrderService();
            service.DeleteIceCreamOrder(id);
            TempData["SaveResult"] = "Your Order Is Deleted";

            return RedirectToAction("Index");
        }

        private IceCreamOrderService CreateIceCreamOrderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IceCreamOrderService();
            return service;
        }
    }
}