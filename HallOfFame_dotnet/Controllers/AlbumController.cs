using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using HallOfFame_dotnet.Infrastructure;
using HallOfFame_dotnet.Utils;

namespace HallOfFame_dotnet.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public async Task<ActionResult> Index(int id)
        {
            var album = context.Albums.First(a => a.ID == id);

            var uri = new Uri(WebConfigurationManager.AppSettings["lastfmApi"])
                .AddQuery("method", "album.getInfo")
                .AddQuery("artist", album.Artist)
                .AddQuery("album", album.Name)
                .AddQuery("api_key", WebConfigurationManager.AppSettings["lastfmKey"]);

            HttpClient client = new HttpClient();
            var response = await client.GetAsync(uri);

            string resp = await response.Content.ReadAsStringAsync();

           
            
            return View(album);
        }
	}
}