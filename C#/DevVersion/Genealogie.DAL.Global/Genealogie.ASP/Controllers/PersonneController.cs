using Genealogie.ASP.Models;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Controllers
{
    public class PersonneController : Controller
    {
        // GET: Personne
        [HttpGet]
        public ActionResult DonnerParArbre(int id)
        {
            IEnumerable<PersonneIndex> per = new PersonneServiceAPI().DonnerParArbre(id).Select(j => new PersonneIndex(j));
            ViewBag.Arbre = id;
            return View(per);
        }

        public ActionResult Details(int id)
        {
            PersonneIndex pi = new PersonneIndex(new PersonneServiceAPI().Donner(id));
            
            return View(pi);
        }

        public ActionResult Creer(int id)
        {
            PersonneCreation pc = new PersonneCreation();
            pc.idArbre = id;
            return View(pc);
        }
    }
}