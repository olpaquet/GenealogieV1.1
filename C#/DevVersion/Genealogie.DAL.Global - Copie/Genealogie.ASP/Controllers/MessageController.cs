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
    public class MessageController : Controller
    {
        // GET: Message
        [HttpGet]
        [ConnecteAut]
        public ActionResult DonnerMessagesRecus()
        {
            IEnumerable<MessageRecuIndex> mri = new VMessageRecuServiceAPI()
                .DonnerPourDestinataire(SessionUtilisateur.Utilisateur.id)
                .Select(j => new MessageRecuIndex(j))
                .OrderByDescending(k => k.date)
                .ThenByDescending(jj => jj.idConversation)
                ;
            return View(mri);
        }
        [HttpGet]
        [ConnecteAut]
        public ActionResult DonnerMessagesEnvoyes()
        {
            /*ConversationController cc = new ConversationController();
            return cc.Donner();*/

            IEnumerable<ConversationIndex> ci = new ConversationServiceAPI()
                .DonnerParEmetteur(SessionUtilisateur.Utilisateur.id)
                .Select(j => new ConversationIndex(j))
                .OrderByDescending(k=>k.date)
                .ThenByDescending(jj=>jj.id);
            return View(ci);
        }

        [HttpGet]
        [ConnecteAut]
        public ActionResult EnvoyerMessage()
        {
            MessageCreation mc = new MessageCreation();
            mc.idEmetteur = SessionUtilisateur.Utilisateur.id;
            mc.SLIDestinataires = new UtilisateurServiceAPI().Donner().Where(j => j.actif && j.id != mc.idEmetteur)
                .Select(sl => new SelectListItem {Selected=false, Value=sl.id.ToString(), 
                    Text=sl.login })
                .ToList()
                ;
            return View(mc);
        }

        [HttpPost]
        [ConnecteAut]
        public ActionResult EnvoyerMessage(MessageCreation md)
        {
            md.idEmetteur = SessionUtilisateur.Utilisateur.id;
            Conversation e = md.VersConversation();
            if (ModelState.IsValid)
            {
                int idConversation = new ConversationServiceAPI().Creer(e);
                int idDestinataire = md.idDestinataire;
                new MessageDestinationServiceAPI().Creer(idConversation, idDestinataire, new MessageDestination());
            }
            return RedirectToAction("DonnerMessagesEnvoyes");
        }

    }
}