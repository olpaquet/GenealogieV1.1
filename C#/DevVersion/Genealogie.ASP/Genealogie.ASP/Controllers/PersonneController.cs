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
            Arbre a = new ArbreServiceAPI().Donner(id);
            ViewBag.ProprietaireArbre = a.Createur().login;
            ViewBag.NomArbre = a.nom;
            return View(per);
        }
        /*
        [HttpGet]
        [FiltreExiste]*/
        public ActionResult Detailxs(int id)
        {
            PersonneIndex pi = new PersonneIndex(new PersonneServiceAPI().Donner(id));
            return View(pi);
        }

        [HttpGet]
        [FiltreExiste]
        
        public ActionResult Details(int id)
        {
            PersonneIndex pi = new PersonneIndex(new PersonneServiceAPI().Donner(id));
            
            return View(pi);
        }
        [HttpGet]
        /*[FxiltreProprietaireArbre]*/
        public ActionResult Creer(int id)
        {
            PersonneCreation pc = new PersonneCreation();
            
            pc.idArbre = id;
            return View(pc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [FxiltreProprietaireArbre]
        public ActionResult Creer(PersonneCreation c)
        {
            if (ModelState.IsValid)
            {
                Personne p = c.VersPersonne();

                /* contrôle arbre */

                var x = SessionUtilisateur.arbres;
                if (SessionUtilisateur.arbres
                    .Where(j=>j.id==p.idArbre)
                    .Count()==1)
                {
                    int i = new PersonneServiceAPI().Creer(p);
                    if (i > 0) return RedirectToAction("DonnerPourArbre", new { id = c.idArbre });

                }
                
                
            }
            return View(c);
        }

        [HttpGet]
        [FiltreExiste]
        /*[FxiltreProprietaireArbre]*/
        public ActionResult Modifier(int id)
        {
            PersonneModification pm = new PersonneModification(new PersonneServiceAPI().Donner(id));
            return View(pm);
        }

        [HttpPost]
        [FiltreExiste]
        /*[FiltreProprietaireArbre("personne")]*/
        [ValidateAntiForgeryToken]
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

        [HttpGet]
        [FiltreProprietaireArbre("personne")]
        public ActionResult AjouterEnfant(int id)
        {
            /* préparer la liste des enfants impossibles */
            Personne p = new PersonneServiceAPI().Donner(id);

            IList<SelectListItem> enfants = new PersonneServiceAPI().DonnerParenteesDirectesPossibles(id)
                .Where(u=>((p.homme && u.idPere==null) || (!p.homme && u.idMere==null)) && u.id != p.id)
                .Select(j => new SelectListItem { Selected = false, Value = j.id.ToString(), Text = j.VersAffichage() })
                .ToList();
                ;
            PersonneAjouterEnfant pae = new PersonneAjouterEnfant();
            pae.Parent = new PersonneServiceAPI().Donner(id).VersAffichage();
            pae.enfants = enfants;
            pae.idArbre = p.idArbre;
            pae.id = p.id;

            return View(pae);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [FiltreProprietaireArbre("personne")]
        public ActionResult AjouterEnfant(int id, PersonneAjouterEnfant pae)
        {
            pae.idArbre = new PersonneServiceAPI().Donner(id).idArbre;

            if (ModelState.IsValid)
            {
                if (new PersonneServiceAPI().AjouterEnfant(new ParentEnfant { idEnfant = pae.machin, idParent = id })) 
                    return RedirectToAction("DonnerPourArbre", new { id = pae.idArbre });
            }
            return View(pae);

            
        }

        [HttpGet]        
        [Route("Personne/SupprimerEnfant/{id:int}/{idenfant:int}")]
        [FiltreProprietaireArbre("personne")]
        [FiltreEnfantSupprimable]
        public ActionResult SupprimerEnfant(int id, int idenfant)
        {
            new PersonneServiceAPI().SupprimerEnfant(new ParentEnfant { idEnfant = idenfant, idParent = id }) ;
            return RedirectToAction("DonnerPourArbre", new { id = new PersonneServiceAPI().Donner(idenfant).idArbre});
        }

        [HttpGet]        
        [FiltreProprietaireArbre("personne")]
        public ActionResult SupprimerMere(int id)
        {

            new PersonneServiceAPI().SupprimerMere(id);
            return RedirectToAction("DonnerPourArbre", new { id = new PersonneServiceAPI().Donner(id).idArbre });
        }

        [HttpGet]
        [FiltreProprietaireArbre("personne")]
        public ActionResult SupprimerPere(int id)
        {

            new PersonneServiceAPI().SupprimerPere(id);
            return RedirectToAction("DonnerPourArbre", new { id = new PersonneServiceAPI().Donner(id).idArbre });
        }

        [HttpGet]        
        public ActionResult AjouterParent(int id)
        {
            FormAjouterParent fap = new FormAjouterParent();
            Personne p = new PersonneServiceAPI().Donner(id);
            fap.idArbre = p.idArbre;
            IEnumerable<Personne> liste =  new PersonneServiceAPI().DonnerParenteesDirectesPossibles(id);

            if (p.idPere != null) liste = liste.Where(j => !j.homme);
            if (p.idMere != null) liste = liste.Where(j => j.homme);

            fap.parents = liste.Select(j => new SelectListItem { Selected = false, Value=j.id.ToString(), Text=$"{j.VersAffichage()} ({j.homme.VersSexe()})" }).ToList();

            return View(fap);
        }

        [HttpPost]
        [FiltreProprietaireArbre("personne")]
        public ActionResult AjouterParent(int id, FormAjouterParent fap)
        {
            Personne p = new PersonneServiceAPI().Donner(id);
            fap.idArbre = p.idArbre;

            IEnumerable<Personne> liste = new PersonneServiceAPI().DonnerParenteesDirectesPossibles(id);

            if (p.idPere != null) liste = liste.Where(j => !j.homme);
            if (p.idMere != null) liste = liste.Where(j => j.homme);

            if (liste.Where(j => j.id == fap.idParent).SingleOrDefault() == null) return View(fap);

            if (ModelState.IsValid)
            {
                bool b = new PersonneServiceAPI().AjouterParent(new ParentEnfant { idParent=fap.idParent,  idEnfant = id });
                if (b) return RedirectToAction("DonnerPourArbre", new { id = p.idArbre });
            }
            return View(fap);
        }

        [HttpGet]
        [FiltreProprietaireArbre("personne")]
        public ActionResult Supprimer(int id)
        {
            Personne p = new PersonneServiceAPI().Donner(id);
            new PersonneServiceAPI().Supprimer(id);
            return RedirectToAction("DonnerPourArbre", new { id = p.idArbre });
        }
    }
    
}