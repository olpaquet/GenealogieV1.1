using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Nouvelle");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Qui sommes-nous?.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Pour nous contacter...";

            return View();
        }
    }
}