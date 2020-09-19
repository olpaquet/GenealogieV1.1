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
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return false;
            foreach (var x in values)
            {
                var u = x.Key;
                var v = x.Value;

            }


            object valueConstraint = values[parameterName];
            if (valueConstraint is null) return false;
            if (!int.TryParse(valueConstraint.ToString(), out int searchedId)) return false;
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();
            return usa.Donner(searchedId) != null;
            throw new NotImplementedException();
        }

        /*[Route("api/Student/{id:Existe}")]*/
    }
}
 