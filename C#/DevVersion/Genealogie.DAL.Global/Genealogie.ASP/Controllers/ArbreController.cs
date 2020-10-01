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
    public class ArbreController : Controller
    {

        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        public ActionResult ListerTout()
        {
            ArbreServiceAPI asa = new ArbreServiceAPI();
            IEnumerable<ArbreIndex> ai = asa.Donner().Select(j => { ArbreIndex a = new ArbreIndex(j);
                a.proprietaire = new UtilisateurServiceAPI().Donner(j.idCreateur).login;
                a.blocage = j.idBlocage == null ? "xxx" : new BlocageServiceAPI().Donner((int)j.idBlocage).nom;
                return a;
            });
            
            return View(ai);
        }
        // GET: Arbre
        [HttpGet]
        public ActionResult Index()
        {
            ArbreServiceAPI rs = new ArbreServiceAPI();
            IEnumerable<ArbreIndex> ri = rs.DonnerParUtilisateur(SessionUtilisateur.Utilisateur.id).Select(m => new ArbreIndex(m));
            return View(ri);
        }

        [HttpGet]
        [FiltreProprietaireArbre("arbre")]
        public ActionResult Details(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            Arbre r = rsa.Donner(id);
            ArbreDetails rd = new ArbreDetails(r);
            return View(rd);
        }

        [HttpGet]
        public ActionResult Creer()
        {
            ArbreCreation r = new ArbreCreation();
            r.idCreateur = SessionUtilisateur.Utilisateur.id;
            return View(r);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Creer(ArbreCreation e)
        {
            if (ModelState.IsValid)
            {
                ArbreServiceAPI rsa = new ArbreServiceAPI();
                Arbre a = e.VersArbre();
                /* init */
                a.idCreateur = SessionUtilisateur.Utilisateur.id;                
                
                /****/
                int i = rsa.Creer(a);
                if (i > 0)
                {
                    SessionUtilisateur.arbres.Add(new ArbreServiceAPI().Donner(i));
                    return RedirectToAction("Index");
                }
            }
            return View(e);

        }

        [HttpGet]
        [FiltreProprietaireArbre("arbre")]
        public ActionResult Modifier(int id)
        {
            ArbreServiceAPI rs = new ArbreServiceAPI();
            ArbreModification r = new ArbreModification(rs.Donner(id));
            
            return View(r);
        }

        [HttpPost]
        [FiltreProprietaireArbre("arbre")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(int id, ArbreModification rm)
        {
            if (ModelState.IsValid)
            {
                ArbreServiceAPI rsa = new ArbreServiceAPI();
                Arbre a = rsa.Donner(id);
                
                Arbre r = rm.VersArbre();
                r.id = a.id;                

                bool b = rsa.Modifier(id, r);
                if (b) return RedirectToAction("Index");
            }

            return View(rm);
        }

        [HttpGet]
        [FiltreProprietaireArbre("arbre")]
        public ActionResult Supprimer(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            ArbreDetails r = new ArbreDetails(rsa.Donner(id));
            return View(r);
        }

        [HttpPost]
        [FiltreProprietaireArbre("arbre")]
        [ValidateAntiForgeryToken]
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
        [FiltreProprietaireArbre("arbre")]
        /*pas bloqué*/
        public ActionResult Activer(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            bool b = rsa.Activer(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [FiltreProprietaireArbre("arbre")]
        /*pas bloqué*/
        public ActionResult Desactiver(int id)
        {
            ArbreServiceAPI rsa = new ArbreServiceAPI();
            bool b = rsa.Desactiver(id);
            return RedirectToAction("Index");
        }       
        
        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        public ActionResult Bloquer(int id)
        {
            FormBlocageArbre ba = new FormBlocageArbre();
            /*ba.blocages = new BlocageServiceAPI().Donner(new ObjetDonnerListe { ienum = null, options=null })
                .Select(j => new SelectListItem {Selected=false, Text=j.nom, Value=j.id.ToString() })
                .ToList();*/
            /*IEnumerable<string> d = new BlocageServiceAPI().Donner(new ObjetDonnerListe { ienum = null, options = null }).Select(j => j.nom);
            ba.blocages = new SelectList(d, d.FirstOrDefault());*/
            ba.blocages = new BlocageServiceAPI().Donner(new ObjetDonnerListe { ienum = null, options = null });
            ba.id = id;
            
            return View(ba);
        }
        [HttpPost]
        [AutorisationRole(EnumRole.ADMIN)]
        public ActionResult Bloquer(int id, FormBlocageArbre e)
        {
            if (ModelState.IsValid)
            {
                BlocageArbre ba = new BlocageArbre();
                ba.id = id;
                ba.idBloqueur = SessionUtilisateur.Utilisateur.id;

                /*object oo = e.blocages.SelectedValue;
                oo = e.blocageChoisi;


                ba.idBlocage = (int)new BlocageServiceAPI().DonnerParNom((string)oo);*/
                ba.idBlocage = e.idBlocage;
                
                bool b = new ArbreServiceAPI().Bloquer(ba);
                if (b) return RedirectToAction("ListerTout");
            }
            return View(e);
        }

        [HttpGet]
        [AutorisationRole(EnumRole.ADMIN)]
        public ActionResult Debloquer(int id)
        {
            new ArbreServiceAPI().Debloquer(id);
            return RedirectToAction("ListerTout");
        }
    }
}