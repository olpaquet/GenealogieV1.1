using Genealogie.ASP.Models;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static Genealogie.ASP.Models.ConversationIndex;

namespace Genealogie.ASP.Controllers
{
    public class ConversationController : Controller
    {
        /*[HttpGet]
        [ConnecteAut]
        public ActionResult Donner()
        {
            IEnumerable<ConversationIndex> ci = new ConversationServiceAPI().DonnerParEmetteur(SessionUtilisateur.Utilisateur.id).Select(j => new ConversationIndex(j));
            return View(ci);
        }*/

        [HttpGet] 
        [FiltreAuteurConversation]
        public ActionResult Detruire(int id)
        {
            new ConversationServiceAPI().Detruire(id);
            return RedirectToAction("Donner");
        }

        [HttpGet]
        [FiltreAuteurConversation]
        public ActionResult Lire(int id)
        {
            Conversation c = new ConversationServiceAPI().Donner(id);
            ConversationLecture cl = new ConversationLecture(c);
            return View(cl);
        }

        
    }
}