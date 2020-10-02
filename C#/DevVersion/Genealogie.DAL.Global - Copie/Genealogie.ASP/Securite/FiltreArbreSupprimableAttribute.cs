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
    public class FiltreArbreSupprimableAttribute : ActionFilterAttribute
    {
       

        public FiltreArbreSupprimableAttribute() { }

        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);
        }

        private void Machin(ActionExecutingContext contexteFiltre)
        {
            //IDictionary<string, object> DPar = contexteFiltre.ActionParameters;
            //string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            int id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);
            Arbre a = new ArbreServiceAPI().Donner(id);
            if (a.NombreDePersonnes() != 0) contexteFiltre.Result = new RedirectToRouteResult
                        (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));

        }
    }
}