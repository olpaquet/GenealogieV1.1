using Genealogie.ASP.Conversion;
using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;

using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    [AutorisationRole(EnumRole.ADMIN)]
    public class ThemeController : Controller
    {
        // GET: Theme
        [HttpGet]
        public ActionResult Index()
        {
            ThemeServiceAPI rs = new ThemeServiceAPI();
            IEnumerable<ThemeIndex> ri = rs.Donner().Select(j => new ThemeIndex(j));
            return View(ri);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            ThemeServiceAPI rsa = new ThemeServiceAPI();
            Theme r = rsa.Donner(id);
            ThemeDetails rd = new ThemeDetails(r);
            return View(rd);
        }

        [HttpGet]
        public ActionResult Creer()
        {
            ThemeCreation r = new ThemeCreation();
            return View(r);
        }

        [HttpPost]
        public ActionResult Creer(ThemeCreation e)
        {
            if (ModelState.IsValid)
            {
                ThemeServiceAPI rsa = new ThemeServiceAPI();
                int i = rsa.Creer(e.VersTheme());
                if (i > 0) return RedirectToAction("Index");
            }
            return View(e);

        }

        [HttpGet]
        public ActionResult Modifier(int id)
        {
            ThemeServiceAPI rs = new ThemeServiceAPI();
            ThemeModification r = new ThemeModification(rs.Donner(id));
            return View(r);
        }

        [HttpPost]
        public ActionResult Modifier(int id, ThemeModification rm)
        {
            if (ModelState.IsValid)
            {
                ThemeServiceAPI rsa = new ThemeServiceAPI();
                Theme r = rm.VersTheme();
                bool b = rsa.Modifier(id, r);
                if (b) return RedirectToAction("Index");
            }

            return View(rm);
        }

        [HttpGet]
        public ActionResult Supprimer(int id)
        {
            ThemeServiceAPI rsa = new ThemeServiceAPI();
            ThemeDetails r = new ThemeDetails(rsa.Donner(id));
            return View(r);
        }

        [HttpPost]
        public ActionResult Supprimer(int id, ThemeDetails r)
        {
            if (ModelState.IsValid)
            {
                ThemeServiceAPI rsa = new ThemeServiceAPI();
                bool b = rsa.Supprimer(id);
                if (b) return RedirectToAction("Index");
            }
            return View(r);
        }

        [HttpGet]
        public ActionResult Activer(int id)
        {
            ThemeServiceAPI rsa = new ThemeServiceAPI();
            bool b = rsa.Activer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Desactiver(int id)
        {
            ThemeServiceAPI rsa = new ThemeServiceAPI();
            bool b = rsa.Desactiver(id);
            return RedirectToAction("Index");
        }
    }
}
