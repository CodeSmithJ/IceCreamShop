using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    public class IceCreamOrderController : Controller
    {
        // GET: IceCreamOrder
        public ActionResult Index()
        {
            return View();
        }
    }
}