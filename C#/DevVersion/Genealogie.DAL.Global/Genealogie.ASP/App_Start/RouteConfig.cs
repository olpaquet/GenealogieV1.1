using Genealogie.ASP.Securite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using System.Web.Http.Routing;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace Genealogie.ASP
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {

            /*je rajoute la contrainte personnalisée pour l'attribut de route*/
            /*DefaultInlineConstraintResolver constraintResolver = new DefaultInlineConstraintResolver();
            constraintResolver.ConstraintMap.Add("ExisteX", typeof(ExisteXConstraint));

            routes.MapMvcAttributeRoutes(constraintResolver);*/            

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional } /*,
                constraints: new {id=new ExisteXConstraint()}*/
            );
        }
    }
}
