using System.Linq;
using System.Web.Mvc;
using HallOfFame_dotnet.Infrastructure;

namespace HallOfFame_dotnet.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public ActionResult Index(int id)
        {
            var album = context.Albums.First(a => a.ID == id);
            return View(album);
        }
	}
}