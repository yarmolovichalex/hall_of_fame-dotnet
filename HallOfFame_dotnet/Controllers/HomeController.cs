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

        public ActionResult Index(int page = 1)
        {
            var albums = context.Albums.ToList();

            int pageSize = 8;
            IEnumerable<Album> albumsPerPage = albums.Skip((page - 1) * pageSize).Take(pageSize);
            PageInfo pageInfo = new PageInfo { PageNumber = page, PageSize = pageSize, TotalItems = albums.Count };

            IndexViewModel model = new IndexViewModel
            {
                Albums = albumsPerPage,
                PageInfo = pageInfo
            };

            return View(model);
        }
	}
}