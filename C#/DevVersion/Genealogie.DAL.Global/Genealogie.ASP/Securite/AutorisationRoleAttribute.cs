using Genealogie.ASP.Models;
using Genealogie.ASP.Services.API;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Genealogie.ASP.Securite
{
    public class AutorisationRoleAttribute : AuthorizeAttribute
    {
        private EnumRole _role;
        public AutorisationRoleAttribute(EnumRole role) { _role = role; }


        /* Il faut être vérbonden pour accéder à l'info*/
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            Utilisateur u = SessionUtilisateur.Utilisateur;
            if (u == null) return false;
            UtilisateurServiceAPI usa = new UtilisateurServiceAPI();

            if (_role == EnumRole.ADMIN) return usa.EstAdmin(u.id);
            if (_role == EnumRole.ADMINNOUVELLE) return usa.EstAdminNouvelle(u.id);
            if (_role == EnumRole.ADMINFORUM) return usa.EstAdminForum(u.id);
            if (_role == EnumRole.ADMINMESSAGE) return usa.EstAdminMessage(u.id);

            return false;
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