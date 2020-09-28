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
        public bool Lu { get { return this.dateLecture != null; } }
        public IEnumerable<MessageDestination> autresMessages
        {
            get{return new MessageDestinationServiceAPI().DonnerPourConversation(this.idConversation)
                    .Where(j => j.idDestinataire != this.idDestinataire);}
        }
        public Utilisateur destinataire { get { return new UtilisateurServiceAPI().Donner(this.idDestinataire); } }
        public Conversation conversation { get { return new ConversationServiceAPI().Donner(this.idConversation); } }
        public Utilisateur emetteur { get { return new UtilisateurServiceAPI().Donner(this.conversation.idEmetteur) ; } }

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
            this.emetteur = e.emetteur.login;
            this.autresDestinataires = e.autresMessages.Select(j=>new UtilisateurServiceAPI().Donner(j.idDestinataire).login).ToList()
                ;
            Conversation c = e.conversation;
            this.sujet = c.sujet;
            this.texte = c.texte;
        }
    }
}