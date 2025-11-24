using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BharatiRadio
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Programs",
                url: "Programs/",
                defaults: new { controller = "Home", action = "Programs", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "About Us",
                url: "about-us/",
                defaults: new { controller = "Home", action = "AboutUS", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Contact Us",
                url: "contact-us/",
                defaults: new { controller = "Home", action = "ContactUs", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "FeedBack",
                url: "feedback/",
                defaults: new { controller = "Feedback", action = "feedback", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Shows",
                url: "Shows/",
                defaults: new { controller = "Shows", action = "Show", id = UrlParameter.Optional }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Home", id = UrlParameter.Optional }
            );
        }
    }
}
