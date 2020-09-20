using Genealogie.Modeles.API.ASP.Modeles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Genealogie.API.Models
{
    
    public class Utilisateur : BUtilisateur{}
    public class UtilisateurRole : BUtilisateurRole { }
    public class Role : BRole { }
    public class Blocage : BBlocage { }
    public class Theme : BTheme { }
    public class Nouvelle : BNouvelle { }
    public class Abonnement : BAbonnement { }
    public class Arbre : BArbre { }
    public class Personne : BPersonne { }    
}