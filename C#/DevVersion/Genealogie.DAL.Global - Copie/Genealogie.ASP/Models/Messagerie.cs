using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Genealogie.ASP.Models
{
    public class MessageRecuIndex
    {
        public int idConversation { get; set; }
        public int idDestinataire { get; set; }
        public int idEmetteur { get; set; }
        public DateTime date { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }
        public string emetteur { get; set; }
        public string destinataire { get; set; }
        public bool lu { get; set; }

        public MessageRecuIndex() { }
        public MessageRecuIndex(VMessageRecu e)
        {
            this.date = e.date;
            this.idConversation = e.id;
            this.sujet = e.sujet;
            this.texte = e.texte;
            this.idEmetteur = e.idEmetteur;
            this.idDestinataire = e.idDestinataire;
            this.emetteur = new UtilisateurServiceAPI().Donner(idEmetteur).login;
            this.destinataire = new UtilisateurServiceAPI().Donner(idDestinataire).login;
            this.lu = e.dateLecture != null;

        }
    }

    public class MessageCreation
    {
        public int idEmetteur { get; set; }
        public IList<SelectListItem> SLIDestinataires { get; set; }
        public int idDestinataire { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }

        public MessageCreation() { }        
    }
}