using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public IEnumerable<MessageDestination> AutresMessages()
        {
            return new MessageDestinationServiceAPI().DonnerPourConversation(this.idConversation)
                    .Where(j => j.idDestinataire != this.idDestinataire);
        }
        public Utilisateur Destinataire() {  return new UtilisateurServiceAPI().Donner(this.idDestinataire); } 
        public Conversation Conversation() {  return new ConversationServiceAPI().Donner(this.idConversation); } 
        public Utilisateur Emetteur() { return new UtilisateurServiceAPI().Donner(this.Conversation().idEmetteur) ; } 

    }

    public class MessageDestinationLecture
    {
        public int idConversation { get; set; }
        public string emetteur { get; set; }
        public int idDestinataire { get; set; }
        [DisplayName("destinataire")]
        public string nomDestinataire { get; set; }
        public IList<string> autresDestinataires { get; set; }
        [DisplayName("lu")]
        public bool lu { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }

        public MessageDestinationLecture() { }
        public MessageDestinationLecture(MessageDestination e)
        {
            this.idConversation = e.idConversation;
            this.emetteur = e.Emetteur().login;
            this.autresDestinataires = e.AutresMessages().Select(j=>new UtilisateurServiceAPI().Donner(j.idDestinataire).login).ToList()
                ;
            this.nomDestinataire = new UtilisateurServiceAPI().Donner(e.idDestinataire).login;
            this.idDestinataire = e.idDestinataire;
            Conversation c = e.Conversation();
            this.sujet = c.sujet;
            this.texte = c.texte;
            this.lu = e.dateLecture != null;
        }
    }
}