using System.Web.Mvc;
using System.Web.Routing;

namespace HallOfFame_dotnet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.AppendTrailingSlash = true;

            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new {controller = "Home", action = "Index"}
                );

            routes.MapRoute(
                name: "Albums",
                url: "Album",
                defaults: new { controller = "Home", action = "Index" });

            routes.MapRoute(
                name: "Album",
                url: "Album/{artist}/{albumname}",
                defaults: new { controller = "Album", action = "Index" });

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
               );

            
        }
    }
}
