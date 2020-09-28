using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;

namespace Genealogie.ASP.Models
{
    public class MessageDestination: BMessageDestination
    {
    }

    public class MessageDestinationLecture
    {
        public int idConversation { get; set; }
        public string emetteur { get; set; }
        public string idDestinataire { get; set; }
        public IList<string> autresDestinataires { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }

        public MessageDestinationLecture() { }
        public MessageDestinationLecture(MessageDestination e)
        {
            this.idConversation = e.idConversation;
            this.emetteur = new UtilisateurServiceAPI()
                .Donner(new ConversationServiceAPI().Donner(this.idConversation).idEmetteur).login;
            this.autresDestinataires = new MessageDestinationServiceAPI()
                .DonnerPourConversation(this.idConversation)
                .Where(j=>j.idDestinataire!=SessionUtilisateur.Utilisateur.id)
                .Select(k=>new UtilisateurServiceAPI().Donner(k.idDestinataire).login)
                .ToList()
                ;
            Conversation c = new ConversationServiceAPI().Donner(this.idConversation);
            this.sujet = c.sujet;
            this.texte = c.texte;
        }
    }
}