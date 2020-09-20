using Genealogie.ASP.Conversion;
using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    [ConnecteAut]
    public class ArbreController : Controller
    {
        // GET: Arbre
        [HttpGet]
        public ActionResult Index()
        {
            ArbreServiceAPI rs = new ArbreServiceAPI();
            IEnumerable<ArbreIndex> ri = rs.DonnerParUtilisateur(SessionUtilisateur.Utilisateur.id).Select(m => new ArbreIndex(m));
            return View(ri);
        }

        [HttpGet]
        /*proprietaire*/        
        public ActionResult Details(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            Arbre r = rsa.Donner(id);
            ArbreDetails rd = new ArbreDetails(r);
            return View(rd);
        }

        [HttpGet]
        /*proprietaire*/
        public ActionResult Creer()
        {
            ArbreCreation r = new ArbreCreation();
            return View(r);
        }

        [HttpPost]
        /*proprietaire*/
        public ActionResult Creer(ArbreCreation e)
        {
            if (ModelState.IsValid)
            {
                ArbreServiceAPI rsa = new ArbreServiceAPI();
                Arbre a = e.VersArbre();
                /* init */
                a.idCreateur = SessionUtilisateur.Utilisateur.id;
                a.idBlocage = null;
                a.idBloqueur = null;                
                /****/
                int i = rsa.Creer(a);
                if (i > 0) return RedirectToAction("Index");
            }
            return View(e);

        }

        [HttpGet]
        /*proprietaire*/        
        public ActionResult Modifier(int id)
        {
            ArbreServiceAPI rs = new ArbreServiceAPI();
            ArbreModification r = new ArbreModification(rs.Donner(id));
            return View(r);
        }

        [HttpPost]
        /*proprietaire*/
        
        public ActionResult Modifier(int id, ArbreModification rm)
        {
            if (ModelState.IsValid)
            {
                ArbreServiceAPI rsa = new ArbreServiceAPI();
                Arbre a = rsa.Donner(id);

                Arbre r = rm.VersArbre();
                r.id = a.id;
                r.idBloqueur = a.idBloqueur;
                r.idBlocage = a.idBlocage;
                r.idCreateur = a.idCreateur;

                bool b = rsa.Modifier(id, r);
                if (b) return RedirectToAction("Index");
            }

            return View(rm);
        }

        [HttpGet]
        /*proprietaire*/
        public ActionResult Supprimer(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            ArbreDetails r = new ArbreDetails(rsa.Donner(id));
            return View(r);
        }

        [HttpPost]
        /*proprietaire*/
        public ActionResult Supprimer(int id, ArbreDetails r)
        {
            if (ModelState.IsValid)
            {
                ArbreServiceAPI rsa = new ArbreServiceAPI();
                bool b = rsa.Supprimer(id);
                if (b) return RedirectToAction("Index");
            }
            return View(r);
        }

        [HttpGet]
        /*proprietaire*/
        /*pas bloqué*/
        public ActionResult Activer(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            bool b = rsa.Activer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        /*proprietaire*/
        /*pas bloqué*/
        public ActionResult Desactiver(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            bool b = rsa.Desactiver(id);
            return RedirectToAction("Index");
        }
    }
}