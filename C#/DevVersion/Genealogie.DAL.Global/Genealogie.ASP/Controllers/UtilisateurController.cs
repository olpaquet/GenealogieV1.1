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
    
    public class UtilisateurController : Controller
    {
        // GET: Utilisateur
        [AdminAut]
        [HttpGet]
        public ActionResult Index()
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            IEnumerable<UtilisateurIndex> ieui = usa.Donner().Select(j => new UtilisateurIndex(j));
            return View(ieui);
        }
        [AdminAut]
        [HttpGet]
        public ActionResult Details(int id)
        {            
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            Utilisateur u = usa.Donner(id);            
            UtilisateurDetails ud = new UtilisateurDetails(u);
            ud.SLIRoles = usa.DonnerSLIRoles(id).ToList();

            return View(ud);
        }
        [AdminAut]
        [HttpGet]
        public ActionResult Creer()
        {            
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            UtilisateurCreation u = new UtilisateurCreation();
            u.SLIRoles = usa.DonnerSLIRoles((int?)null).ToList();
            return View(u);
        }
        [AdminAut]
        [HttpPost]
        public ActionResult Creer(UtilisateurCreation u)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                Utilisateur ch = u.VersUtilisateur();
                var x = u.SLIRoles;
                ch.lRoles = (u.SLIRoles==null)?null:u.SLIRoles.Where(j => j.Selected).Select(k => Int32.Parse(k.Value)).VersListePypee();
                int b = usa.Creer(ch);
                if (b >= 1) return RedirectToAction("Index");
            }
            return View(u);
        }

        [AdminAut]
        [HttpGet]
        public ActionResult Modifier(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            Utilisateur u = usa.Donner(id);
            UtilisateurModification um = u.VersUtilisateurModification();
            um.SLIRoles = usa.DonnerSLIRoles(id).ToList();
            return View(um);
        }

        [AdminAut]
        [HttpPost]
        public ActionResult Modifier(int id, UtilisateurModification um)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                UtilisateurModification vum = usa.Donner(id).VersUtilisateurModification();
                um.login = vum.login;
                Utilisateur u = um.VersUtilisateur();
                u.lRoles = um.SLIRoles.Where(j => j.Selected).Select(l => Int32.Parse(l.Value)).VersListePypee();
                if (usa.Modifier(id, u)) return RedirectToAction("Index");
            }
            return View(um);
        }

        [AnonymeAut]
        [HttpGet]
        public ActionResult Connexion()
        {
            return View(new UtilisateurConnexion());
            
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public ActionResult Connexion(UtilisateurConnexion uc)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                Utilisateur u = usa.DonnerUtilisateur(uc);
                
                if (u!=null)
                {
                    SessionUtilisateur.AssignerUtilisateur(u);
                    return RedirectToAction("Index","Home");
                }
            }
            return View(uc);
        }

        [ConnecteAut]
        [HttpGet]
        public ActionResult Deconnexion()
        {
            SessionUtilisateur.AssignerUtilisateur(null);
            return RedirectToAction("Index", "Home");
        }

        [AdminAut]
        [HttpGet]
        public ActionResult Supprimer(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            UtilisateurDetails u = usa.Donner(id).VersUtilisateurDetails();
            return View(u);
        }

        [AdminAut]
        [HttpPost]
        public ActionResult Supprimer(int id, UtilisateurDetails u)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                if ((usa.Supprimer(id))) return RedirectToAction("Index"); 
            }
            return View(u);
            

        }

        [AdminAut]
        [HttpGet]
        public ActionResult Desactiver(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            usa.Desactiver(id);
            return RedirectToAction("Index");
        }

        [AdminAut]
        [HttpGet]
        public ActionResult Activer(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            usa.Activer(id);
            return RedirectToAction("Index");
        }

        [AnonymeAut]
        [HttpGet]
        public ActionResult Enregistrer()
        {
            UtilisateurEnregistrement ur = new UtilisateurEnregistrement();
            return View(ur);
        }

        [AnonymeAut]
        [HttpPost]
        public ActionResult Enregistrer(UtilisateurEnregistrement uc)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            int i = usa.Creer(uc.VersUtilisateur());
            if (i > 0)
            {
                SessionUtilisateur.AssignerUtilisateur(new UtilisateurServiceAPI().Donner(i));
                return RedirectToAction("Index", "Home");
            }
            return View(uc);

        }
        
    }
}