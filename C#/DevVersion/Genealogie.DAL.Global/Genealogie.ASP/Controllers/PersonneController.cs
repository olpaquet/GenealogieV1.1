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
    public class PersonneController : Controller
    {
        // GET: Personne
        [HttpGet]
        [FiltreExiste("arbre")]
        [FiltreProprietaireArbre("arbre")]
        public ActionResult DonnerPourArbre(int id)
        {
            IEnumerable<PersonneIndex> per = new PersonneServiceAPI().DonnerPourArbre(id).Select(j => new PersonneIndex(j));
            ViewBag.Arbre = id;
            return View(per);
        }

        [HttpGet]
        [FiltreExiste]
        [FiltreProprietaireArbre("personne")]
        public ActionResult Details(int id)
        {
            PersonneIndex pi = new PersonneIndex(new PersonneServiceAPI().Donner(id));
            
            return View(pi);
        }
        [HttpGet]
        [FiltreProprietaireArbre("personne")]
        public ActionResult Creer(int id)
        {
            PersonneCreation pc = new PersonneCreation();
            
            pc.idArbre = id;
            return View(pc);
        }
        [HttpPost]
        public ActionResult Creer(PersonneCreation c)
        {
            if (ModelState.IsValid)
            {
                Personne p = c.VersPersonne();
                int i = new PersonneServiceAPI().Creer(p);
                if (i > 0) return RedirectToAction("DonnerPourArbre", new { id = c.idArbre });
            }
            return View(c);
        }

        [HttpGet]
        [FiltreExiste]
        [FiltreProprietaireArbre("personne")]
        public ActionResult Modifier(int id)
        {
            PersonneModification pm = new PersonneModification(new PersonneServiceAPI().Donner(id));
            return View(pm);
        }

        [HttpPost]
        [FiltreExiste]
        [FiltreProprietaireArbre("personne")]
        public ActionResult Modifier(int id, PersonneModification pm)
        {
            if (ModelState.IsValid)
            {
                Personne po = new PersonneServiceAPI().Donner(id);
                Personne p = pm.VersPersonne();
                p.dateAjout = po.dateAjout;
                p.idArbre = po.idArbre;
                p.idMere = po.idMere;
                p.idPere = po.idPere;
                p.id = id;
                p.dateAjout = po.dateAjout;

                if (new PersonneServiceAPI().Modifier(id,p)) return RedirectToAction("DonnerPourArbre", new {id=po.idArbre });
            }
            return View(pm);
        }

    }
}