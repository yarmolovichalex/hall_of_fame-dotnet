using System.Linq;
using System.Web.Mvc;
using HallOfFame_dotnet.Infrastructure;

namespace HallOfFame_dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public ActionResult Index()
        {
            var albums = context.Albums.ToList();

            return View(albums);
        }
	}
}