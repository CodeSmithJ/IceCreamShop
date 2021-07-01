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
            return View();
        }
    }
}