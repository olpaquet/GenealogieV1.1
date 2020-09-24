using Genealogie.Modeles.API.ASP.Modeles;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Genealogie.ASP.Models
{
    public class Conversation : BConversation
    {
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
            date = e.date;
            sujet = e.sujet;
            texte = e.texte;
            date = e.date;

        }

    }
}