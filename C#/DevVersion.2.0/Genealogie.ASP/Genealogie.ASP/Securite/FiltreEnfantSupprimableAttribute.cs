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
    public class FiltreEnfantSupprimableAttribute : ActionFilterAttribute
    {
        

        public FiltreEnfantSupprimableAttribute() {  }

        public override void OnActionExecuting(ActionExecutingContext contexteFiltre)
        {
            Machin(contexteFiltre);
        }

        private void Machin(ActionExecutingContext contexteFiltre)
        {

            int id =0;
            int idenfant=0;
            IDictionary<string, object> DPar = contexteFiltre.ActionParameters;
            foreach(KeyValuePair<string, object> chose in DPar)
            {
                try
                {
                    switch (chose.Key)
                    {
                        case "id": id = (int)chose.Value; break;
                        case "idenfant": idenfant = (int)chose.Value; break;
                        default: break;
                    }
                }
                catch (Exception)
                {
                    throw;
                    int jj = 0;
                    
                }
            }
            //string nomControleur = (string)contexteFiltre.RouteData.Values["controller"];
            /*int id = int.Parse((string)contexteFiltre.RouteData.Values["id"]);
            int idEnfant = int.Parse((string)contexteFiltre.RouteData.Values["idenfant"]);*/

            Personne parent = new PersonneServiceAPI().Donner(id);
            if (parent.Enfants().Where(j=>j.id==idenfant)==null) contexteFiltre.Result = new RedirectToRouteResult
                        (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));

        

        }
    }
}

// []
//