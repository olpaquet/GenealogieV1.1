using Genealogie.ASP.Models;
using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{    
    public class FiltreProprietaireArbreAttribute : ActionFilterAttribute
    {
        private string _modele;

        public FiltreProprietaireArbreAttribute(string modele) { _modele = modele; }

        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);            
        }

        private void Machin(ActionExecutingContext contexteFiltre)
        {
            //IDictionary<string, object> DPar = contexteFiltre.ActionParameters;
            //string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            int id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);

            switch (_modele)
            {
                case "arbre":
                    Arbre a = new ArbreServiceAPI().Donner(id);
                    if (a.idCreateur != SessionUtilisateur.Utilisateur.id) contexteFiltre.Result = new RedirectToRouteResult
                        (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));
                    break;
                case "personne":                    
                    if (  new ArbreServiceAPI().Donner(new PersonneServiceAPI().Donner(id).idArbre).idCreateur != SessionUtilisateur.Utilisateur.id) contexteFiltre.Result = new RedirectToRouteResult
                        (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));
                    break;
                default:
                    contexteFiltre.Result = new RedirectToRouteResult
                        (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));
                    break;


            }
            
        }
    }
}