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
    public class NouvelleController : Controller
    {
        // GET: Nouvelle
        [HttpGet]
        public ActionResult Index()
        {
            NouvelleServiceAPI rs = new NouvelleServiceAPI();
            IEnumerable<NouvelleIndex> ri = rs.Donner().Select(j => new NouvelleIndex(j)).OrderByDescending(k=>k.id);
            return View(ri);
        }

        [HttpGet]
        [FiltreExiste]
        public ActionResult Details(int id)
        {
            NouvelleServiceAPI rsa = new NouvelleServiceAPI();
            Nouvelle r = rsa.Donner(id);
            NouvelleDetails rd = new NouvelleDetails(r);
            return View(rd);
        }

        [HttpGet]
        [AutorisationRole(EnumRole.ADMINNOUVELLE)]
        public ActionResult Creer()
        {
            NouvelleCreation r = new NouvelleCreation();
            r.idCreateur = SessionUtilisateur.Utilisateur.id;
            r.dateCreation = DateTime.Now;
            return View(r);
        }

        [HttpPost]
        [AutorisationRole(EnumRole.ADMINNOUVELLE)]
        public ActionResult Creer(NouvelleCreation e)
        {
            if (ModelState.IsValid)
            {
                NouvelleServiceAPI rsa = new NouvelleServiceAPI();
                e.idCreateur = SessionUtilisateur.Utilisateur.id;
                e.dateCreation = DateTime.Now;
                int i = rsa.Creer(e.VersNouvelle());
                if (i > 0) return RedirectToAction("Index");
            }
            return View(e);

        }        

        [HttpGet]
        [AutorisationRole(EnumRole.ADMINNOUVELLE)]
        [FiltreExiste]
        public ActionResult Activer(int id)
        {
            NouvelleServiceAPI rsa = new NouvelleServiceAPI();
            bool b = rsa.Activer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AutorisationRole(EnumRole.ADMINNOUVELLE)]
        [FiltreExiste]
        public ActionResult Desactiver(int id)
        {
            NouvelleServiceAPI rsa = new NouvelleServiceAPI();
            bool b = rsa.Desactiver(id);
            return RedirectToAction("Index");
        }
    }
}