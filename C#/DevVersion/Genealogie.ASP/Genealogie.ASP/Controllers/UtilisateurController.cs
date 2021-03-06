﻿using Genealogie.ASP.Conversion;
using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Genealogie.ASP.Validation;
using Services;
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
        [AutorisationRole(EnumRole.ADMIN)]
        [HttpGet]
        public ActionResult Index()
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            IEnumerable<UtilisateurIndex> ieui = usa.Donner().Select(j => new UtilisateurIndex(j));
            return View(ieui);
        }
        [AutorisationRole(EnumRole.ADMIN)]
        [HttpGet]
        [FiltreExiste]
        public ActionResult Details(int id)
        {            
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            Utilisateur u = usa.Donner(id);            
            UtilisateurDetails ud = new UtilisateurDetails(u);
            ud.SLIRoles = usa.DonnerSLIRoles(id).ToList();

            return View(ud);
        }
        [AutorisationRole(EnumRole.ADMIN)]
        [HttpGet]
        public ActionResult Creer()
        {            
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            UtilisateurCreation u = new UtilisateurCreation();
            u.SLIRoles = usa.DonnerSLIRoles((int?)null).ToList();            
            return View(u);
        }
        [AutorisationRole(EnumRole.ADMIN)]
        [HttpPost]
        public ActionResult Creer(UtilisateurCreation u)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                Utilisateur ch = u.VersUtilisateur();
                IList<int> x = u.SLIRoles.Select(j => int.Parse(j.Value)).Where(k=>new UtilisateurServiceAPI().DonnerSLIRoles(null).Select(m=>int.Parse(m.Value)).Contains(k))
                    .ToList();

                ch.lRoles = u.SLIRoles.Where(j => j.Selected).Select(k => int.Parse(k.Value))
                    .Where(m=>x.Contains(m))
                    .VersListePypee();
                    
                
                int b = usa.Creer(ch);
                if (b >= 1) return RedirectToAction("Index");
            }
            return View(u);
        }
                
        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        [FiltreExiste]
        public ActionResult Modifier(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            Utilisateur u = usa.Donner(id);
            UtilisateurModification um = u.VersUtilisateurModification();
            um.SLIRoles = usa.DonnerSLIRoles(id).ToList();
            return View(um);
        }
                
        [HttpPost]
        [AutorisationRole(EnumRole.ADMIN)]
        /*[Route("Utilisateur/Modifier/{id:ExisteX}")]*/
        [FiltreExiste]
        public ActionResult Modifier(int id, UtilisateurModification um)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                UtilisateurModification vum = usa.Donner(id).VersUtilisateurModification();
                um.login = vum.login;
                Utilisateur u = um.VersUtilisateur();
                IList<int> x = um.SLIRoles.Select(j => int.Parse(j.Value)).Where(k => new UtilisateurServiceAPI().DonnerSLIRoles(null).Select(m => int.Parse(m.Value)).Contains(k))
                    .ToList();

                u.lRoles = um.SLIRoles.Where(j => j.Selected).Select(k => int.Parse(k.Value))
                    .Where(m => x.Contains(m))
                    .VersListePypee();


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
        [AnonymeAut]
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

        [AutorisationRole(EnumRole.ADMIN)]
        [HttpGet]
        [Route("Utilisateur/Modifier/{id:ExisteX}")]
        public ActionResult Supprimer(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            UtilisateurDetails u = usa.Donner(id).VersUtilisateurDetails();
            return View(u);
        }

        [AutorisationRole(EnumRole.ADMIN)]
        [HttpPost]
        [FiltreExiste]
        public ActionResult Supprimer(int id, UtilisateurDetails u)
        {
            if (ModelState.IsValid)
            {
                UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
                if ((usa.Supprimer(id))) return RedirectToAction("Index"); 
            }
            return View("Error");
            

        }
                
        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        [FiltreExiste]
        public ActionResult Desactiver(int id)
        {
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            usa.Desactiver(id);
            return RedirectToAction("Index");
        }
                
        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        [FiltreExiste]
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

        [ConnecteAut]
        [HttpGet]
        public ActionResult ChangerMotDePasse()
        {
            NouveauMotDePasse nmdp = new NouveauMotDePasse { login = SessionUtilisateur.Utilisateur.login };
            return View(nmdp);
        }

        
        [ConnecteAut]
        [HttpPost]
        public ActionResult ChangerMotDePasse(NouveauMotDePasse e)
        {
            if (ModelState.IsValid)
            {
                e.login = SessionUtilisateur.Utilisateur.login;
                if (new UtilisateurServiceAPI().ChangerMotDePasse(e)) return RedirectToAction("Index", "Home");
            }
            return View(e);
        }
        
    }
}