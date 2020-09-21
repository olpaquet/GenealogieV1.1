using Genealogie.ASP.Services.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{
    public class ProprietaireConstraint : IRouteConstraint
    {
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            return true;
            foreach (var x in values)
            {
                var u = x.Key;
                var v = x.Value;

            }


            object valueConstraint = values[parameterName];
            if (valueConstraint is null) return false;
            if (!int.TryParse(valueConstraint.ToString(), out int id)) return false;
            ArbreServiceAPI usa = new ArbreServiceAPI();
            return usa.Donner(id).idCreateur == SessionUtilisateur.Utilisateur.id;
            
        }

        /*[Route("api/Student/{id:Existe}")]*/
    }
}