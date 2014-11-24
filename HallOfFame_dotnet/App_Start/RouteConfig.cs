using System.Web.Mvc;
using System.Web.Routing;

namespace HallOfFame_dotnet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Album",
                url: "{controller}/{id}",
                defaults: new { controller = "Album", action = "Index" }
            );

            routes.MapRoute(
                name: "Home",
                url: "{controller}",
                defaults: new { controller = "Home", action = "Index" }
            );
        }
    }
}
