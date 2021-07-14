using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace IceCreamShop.WebMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Welcome To JJ-Scoops!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "JJ-Scoops Is Here To Help";

            return View();
        }
    }
}