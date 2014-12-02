using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HallOfFame_dotnet.Infrastructure;
using HallOfFame_dotnet.Models;

namespace HallOfFame_dotnet.Controllers
{
    public class HomeController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public ActionResult Index()
        {
            var albums = context.Albums.ToList();
            List<AlbumViewModel> model = albums.Select(Mapper.MapToAlbumViewModel).ToList();

            return View(model);
        }
	}
}