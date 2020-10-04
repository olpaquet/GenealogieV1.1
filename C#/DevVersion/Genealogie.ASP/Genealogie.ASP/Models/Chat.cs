using Genealogie.ASP.Securite;
using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Chat : BChat
    {
    }

    public class ChatIndex
    {
        public int id { get; set; }
        public string message { get; set; }

        public string emetteur { get; set; }
        public DateTime date { get; set; }

        public DateTime? aPartirDe { get; set; }

        public ChatIndex(Chat e, DateTime? fAPartriDe)
        {
            this.id = e.id;
            this.date = e.date;
            this.emetteur = SessionUtilisateur.nomAffichage;
            this.aPartirDe = fAPartriDe;
            this.message = e.message;
        }
    }
}