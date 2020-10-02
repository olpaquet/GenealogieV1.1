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
    public class MessageDestinationController : Controller
    {
        [HttpGet]
        [ConnecteAut]
        public ActionResult Lire(int id) /*id = identifiant conversation*/
        {

            MessageDestinationLecture mdl = new MessageDestinationLecture(new MessageDestinationServiceAPI()
                .DonnerPourConversation(id)
                .Where(j=>j.idDestinataire==SessionUtilisateur.Utilisateur.id)
                .SingleOrDefault());
            return View(mdl);
        }
        [HttpPost]
        [ConnecteAut]
        public ActionResult Lire(int id, MessageDestinationLecture e)
        {
            e.idDestinataire = SessionUtilisateur.Utilisateur.id;
            new MessageDestinationServiceAPI().Lire(id, SessionUtilisateur.Utilisateur.id);
            return RedirectToAction("DonnerMessagesRecus", "Message");
        }

        [HttpGet]
        [ConnecteAut]
        public ActionResult Detruire(int id)
        {
            new MessageDestinationServiceAPI().Detruire(id, SessionUtilisateur.Utilisateur.id);
            return RedirectToAction("DonnerMessagesRecus", "Message");
        }
    }
}