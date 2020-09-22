using Genealogie.ASP.Conversion;
using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    [AutorisationRole(EnumRole.ADMIN)]
    public class AbonnementController : Controller
    {
        // GET: Abonnement
        [HttpGet]
        public ActionResult Index()
        {
            AbonnementServiceAPI rs = new AbonnementServiceAPI();
            IEnumerable<AbonnementIndex> ri = rs.Donner().Select(j => new AbonnementIndex(j));
            return View(ri);
        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Details(int id)
        {
            AbonnementServiceAPI rsa = new AbonnementServiceAPI();
            /*!!??!!! pourquoi a est-il vide? à cause de decimal?)*/
            Abonnement a = rsa.Donner(id);
            AbonnementDetails ad = new AbonnementDetails(a);
            return View(ad);
        }

        [HttpGet]
        public ActionResult Creer()
        {
            AbonnementCreation r = new AbonnementCreation();
            return View(r);
        }

        [HttpPost]
        public ActionResult Creer(AbonnementCreation e)
        {
            if (ModelState.IsValid)
            {
                AbonnementServiceAPI rsa = new AbonnementServiceAPI();
                int i = rsa.Creer(e.VersAbonnement());
                if (i > 0) return RedirectToAction("Index");
            }
            return View(e);

        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Modifier(int id)
        {
            AbonnementServiceAPI rs = new AbonnementServiceAPI();
            var test = rs.Donner(id);
            AbonnementModification r = new AbonnementModification(rs.Donner(id));
            return View(r);
        }

        [HttpPost]
        [FiltreExiste]
        public ActionResult Modifier(int id, AbonnementModification rm)
        {
            if (ModelState.IsValid)
            {
                AbonnementServiceAPI rsa = new AbonnementServiceAPI();
                Abonnement r = rm.VersAbonnement();
                bool b = rsa.Modifier(id, r);
                if (b) return RedirectToAction("Index");
            }

            return View(rm);
        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Supprimer(int id)
        {
            AbonnementServiceAPI rsa = new AbonnementServiceAPI();
            AbonnementDetails r = new AbonnementDetails(rsa.Donner(id));
            return View(r);
        }

        [HttpPost]
        [FiltreExiste]
        public ActionResult Supprimer(int id, AbonnementDetails r)
        {
            if (ModelState.IsValid)
            {
                AbonnementServiceAPI rsa = new AbonnementServiceAPI();
                bool b = rsa.Supprimer(id);
                if (b) return RedirectToAction("Index");
            }
            return View(r);
        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Activer(int id)
        {
            AbonnementServiceAPI rsa = new AbonnementServiceAPI();
            bool b = rsa.Activer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Desactiver(int id)
        {
            AbonnementServiceAPI rsa = new AbonnementServiceAPI();
            bool b = rsa.Desactiver(id);
            return RedirectToAction("Index");
        }
    }
}