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
               name: "Default",
               url: "{controller}/{action}",
               defaults: new { controller = "Home", action = "Index" }
               );

            routes.MapRoute(
                name: "ShowAlbum",
                url: "album/show/{id}",
                defaults: new { controller = "Album", action = "Index" });
        }
    }
}
