using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace erudite
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "About", id = UrlParameter.Optional }
            );


            routes.MapRoute(
                "Categories",
                "{controller}/{action}/{id}",
                new { controller = "TeacherApplication", action = "TeachingCategory", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Area",
                "{controller}/{action}/{id}",
                new { controller = "TeacherApplication", action = "InstituteAreas", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Form",
                "{controller}/{action}/{id}",
                new { controller = "TeachersApplicationForm", action = "ApplicationForm", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                "Thanks",
                "{controller}/{action}/{id}",
                new { controller = "TeachersApplicationForm", action = "Thanks" , id = UrlParameter.Optional}
                );
        }
    }
}
