﻿using Genealogie.ASP.Securite;
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
        public IEnumerable<MessageDestination> messages { get
            {
                return new MessageDestinationServiceAPI().DonnerPourConversation(this.id);
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
        public IList<MessageDestination> messages { get; set; }
        public string sujet { get; set; }
        public string texte { get; set; }

        public ConversationLecture(Conversation e)
        {
            this.idConversation = e.id;
            this.emetteur = SessionUtilisateur.Utilisateur.login;
            this.messages = e.messages.ToList();
            this.sujet = e.sujet;
            this.texte = e.texte;
        }

    }

    
}