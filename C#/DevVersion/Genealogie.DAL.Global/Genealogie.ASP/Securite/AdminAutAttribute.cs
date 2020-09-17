using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{
    public class AdminAutAttribute : AuthorizeAttribute
    {
        /* Il faut être vérbonden pour accéder à l'info*/
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            return SessionUtilisateur.EstAdmin();

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.Result = new RedirectToRouteResult
                (new RouteValueDictionary(new { Area = "", Controller = "Home", Action = "Index" }));
            //base.HandleUnauthorizedRequest(filterContext);
        }

        protected override HttpValidationStatus OnCacheAuthorization(HttpContextBase httpContext)
        {
            return base.OnCacheAuthorization(httpContext);
        }
    }
}