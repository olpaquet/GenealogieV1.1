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
    public class FiltreAuteurConversationAttribute : ActionFilterAttribute
    {


        public FiltreAuteurConversationAttribute() { }

        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);
        }

        private void Machin(ActionExecutingContext contexteFiltre)
        {
            //IDictionary<string, object> DPar = contexteFiltre.ActionParameters;
            //string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            string nomAction = (string)contexteFiltre.RouteData.Values["action"];
            int id;
            try
            {
                id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);
            }
            catch (Exception)
            {
                contexteFiltre.Result = new RedirectToRouteResult
                              (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));
                return;
                throw;
            }
            
            if (new ConversationServiceAPI().Donner(id).idEmetteur != SessionUtilisateur.Utilisateur.id) contexteFiltre.Result = new RedirectToRouteResult
                              (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));



        }
    }
}

// []
//