using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{
    public class FiltreExisteAttribute : ActionFilterAttribute
    {
        private string _modele;

        public FiltreExisteAttribute(string modele = null)
        {
            _modele = modele;
        }

        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);
            
        }
        
        private void Machin(ActionExecutingContext contexteFiltre)
        {
            string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            int id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);
            bool b = false;

            string ch = (_modele == null) ? nomControleur.ToLower() : _modele;

            switch (nomControleur.ToLower())
            {
                case "role":
                    b = new RoleServiceAPI().Donner(id) != null;
                    break;
                case "personne":
                    b = new PersonneServiceAPI().Donner(id) != null;
                    break;
                case "utilisateur":
                    b = new UtilisateurServiceAPI().Donner(id) != null;
                    break;
                case "abonnement":
                    b = new AbonnementServiceAPI().Donner(id) != null;
                    break;
                case "arbre":
                    b = new ArbreServiceAPI().Donner(id) != null;
                    break;
                case "nouvelle":
                    b = new NouvelleServiceAPI().Donner(id) != null;
                    break;
                case "theme":
                    b = new ThemeServiceAPI().Donner(id) != null;
                    break;
                default:
                    b = false;
                    break;
            }
            if (!b) contexteFiltre.Result = new RedirectToRouteResult
                (new RouteValueDictionary(new { Area = "", Controller = nomControleur, Action = "Index" }));

        }
        

    }
}