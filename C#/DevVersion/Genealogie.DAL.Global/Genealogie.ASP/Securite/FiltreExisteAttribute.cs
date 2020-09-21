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
        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);
            
        }
        
        private void Machin(ActionExecutingContext contexteFiltre)
        {
            string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            int id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);
            bool b = false;
            switch (nomControleur.ToLower())
            {
                case "role":
                    b = new RoleServiceAPI().Donner(id) != null;
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