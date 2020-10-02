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
    public class RechercheController : Controller
    {
        // GET: Recherche



        [HttpGet]
        [ConnecteAut]
        public ActionResult Index(FormRecherche frr)
        {
   
            Recherche rec = null;
            if (frr == null) rec = new Recherche();
            else rec = new Recherche { nom = frr.nom, prenom=frr.prenom, homme=frr.homme, idCreateurExclu=SessionUtilisateur.Utilisateur.id };
            FormRecherche fr = new FormRecherche(rec);
            return View(fr);
        }

        

        [HttpPost]
        public ActionResult Rechercher(Recherche rec)
        {
            FormRecherche fc = new FormRecherche(rec);            

            return PartialView(rec);
        }
    }
}