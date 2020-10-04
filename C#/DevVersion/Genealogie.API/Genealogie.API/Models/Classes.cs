using Genealogie.Modeles.API.ASP.Modeles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.API.Models
{
    public class Chat : BChat { }
    public class Utilisateur : BUtilisateur{}
    public class UtilisateurRole : BUtilisateurRole { }
    public class Role : BRole { }
    public class Blocage : BBlocage { }
    public class Theme : BTheme { }
    public class Nouvelle : BNouvelle { }
    public class Abonnement : BAbonnement { }
    public class Arbre : BArbre { }
    public class Personne : BPersonne { }
    public class MessageDestination : BMessageDestination { }
    public class Conversation : BConversation { }
    public class VMessageRecu : BVMesageRecu { }

    public class NouveauMotDePasse
    {
        public int id { get; set; }
        public string login { get; set; }
        public string ancienMotDePasse { get; set; }
        public string motDePasse { get; set; }
        public string motDePasseConfirmation { get; set; }
    }

   
}