using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using System.Xml.Linq;
using HallOfFame_dotnet.Infrastructure;
using HallOfFame_dotnet.Models;
using HallOfFame_dotnet.Utils;

namespace HallOfFame_dotnet.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public ActionResult Index(int id)
        {
            var album = context.Albums.First(a => a.ID == id);
            album.Tracklist = context.Tracks.Where(t => t.AlbumID == id).ToList();

            return View(album);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Add(string artist, string albumName, int year)
        {
            Album album = new Album()
            {
                Artist = artist,
                Name = albumName,
                Year = year,
                Tracklist = new List<Track>()
            };

            var uri = new Uri(WebConfigurationManager.AppSettings["lastfmApi"])
                    .AddQuery("method", "album.getInfo")
                    .AddQuery("artist", artist)
                    .AddQuery("album", albumName)
                    .AddQuery("api_key", WebConfigurationManager.AppSettings["lastfmKey"]);

            var response = await new HttpClient().GetAsync(uri).Result.Content.ReadAsStringAsync();

            album = ParseResponse(response, album);

            // TODO errors handling

            context.Albums.Add(album);
            context.SaveChanges(); 

            return View("Index", album);
        }

        private Album ParseResponse(string response, Album album)
        {
            XDocument doc = XDocument.Parse(response);

            var image = doc.Root.Descendants("image")
                    .FirstOrDefault(e => e.Attribute("size") != null && e.Attribute("size").Value == "mega");
            if (image != null)
                album.Image = image.Value;

            var description = doc.Root.Element("album").Element("wiki").Element("summary").Value;
            album.Description = description;

            XElement tracks = doc.Root.Element("album").Element("tracks");
            foreach (var track in tracks.Elements())
            {
                album.Tracklist.Add(new Track
                {
                    Number = int.Parse(track.Attribute("rank").Value),
                    Name = track.Element("name").Value,
                    Duration = int.Parse(track.Element("duration").Value)
                });
            }

            return album;
        }
    }
}