using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{
    
    public class ExisteXConstraint : IRouteConstraint
    {   
        public bool Match(
            HttpContextBase httpContext, 
            Route route, 
            string parameterName, 
            RouteValueDictionary values, 
            RouteDirection routeDirection)
        {
            //return false;
            /*foreach (var x in values)
            {
                var u = x.Key;
                var v = x.Value;
            }*/
            
            object valeurContrainte = values[parameterName];
            if (valeurContrainte is null) return false;
            if (!int.TryParse(valeurContrainte.ToString(), out int id)) return false;
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            return usa.Donner(id) != null;
            throw new NotImplementedException();
        }

        /*[Route("api/Student/{id:Existe}")]*/
    }
}
 