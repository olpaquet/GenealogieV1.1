using Genealogie.ASP.Securite;
using Genealogie.ASP.Services.API;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Models
{
    public class Conversation : BConversation
    {
        public IList<MessageLu> mess { 
            get {

                IList<MessageLu> vmr =
                    new MessageDestinationServiceAPI().DonnerPourConversation(this.id)
                    .Select(k=> new MessageLu(k))
                    .ToList();
                
                return vmr;
            } }
    }

    public class ConversationIndex
    {
        public int id { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }
        [DisplayName("date d'envoi")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }

        public ConversationIndex() { }
        public ConversationIndex(Conversation e)
        {
            id = e.id;
            date = e.date;
            sujet = e.sujet;
            texte = e.texte;
            date = e.date;
        }

        

    }
    public class ConversationLecture
    {
        public int idConversation { get; set; }
        public string emetteur { get; set; }
        public IList<MessageLu> destinataires { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }

        public ConversationLecture(Conversation e)
        {
            this.idConversation = e.id;
            this.emetteur = SessionUtilisateur.Utilisateur.login;
            this.destinataires = new MessageDestinationServiceAPI().DonnerPourConversation(SessionUtilisateur.Utilisateur.id)
                .Select(j => new MessageLu(j))
                .ToList();
            this.sujet = e.sujet;
            this.texte = e.texte;
        }

    }

    public class MessageLu
    {
        public string destinataire { get; set; }
        public bool Lu { get; set; }
        public MessageLu() { }
        public MessageLu(MessageDestination e) 
        {
            VMessageRecu vmr = new VMessageRecuServiceAPI().DonnerConversationComplete(e.idConversation).Where(j => j.idDestinataire == e.idDestinataire).SingleOrDefault();
            this.destinataire = new UtilisateurServiceAPI().Donner(vmr.idDestinataire).login;
            this.Lu = new MessageDestinationServiceAPI().EstLu(e.idConversation, vmr.idDestinataire);

            
                
        }
    }
}