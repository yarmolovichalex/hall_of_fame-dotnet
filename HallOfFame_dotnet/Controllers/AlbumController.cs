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
            var album = context.Albums.FirstOrDefault(a => a.ID == id);

            return View(album);
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.IsUserInput = true;
            return View(new Album());
        }

        [HttpPost]
        public async Task<ActionResult> GetAlbumInfo(Album album)
        {
            var uri = new Uri(WebConfigurationManager.AppSettings["lastfmApi"])
                    .AddQuery("method", "album.getInfo")
                    .AddQuery("artist", album.Artist)
                    .AddQuery("album", album.Name)
                    .AddQuery("api_key", WebConfigurationManager.AppSettings["lastfmKey"]); // TODO русские символы

            string response;
            try
            {
                response = await new HttpClient().GetAsync(uri).Result.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw;
            }
            XDocument doc = XDocument.Parse(response);

            string status = doc.Root.Attribute("status").Value;
            if (status == "failed")
                return new ContentResult { Content = doc.Root.Element("error").Value }; // TODO переделать

            album = ParseResponse(doc);

            ViewBag.IsUserInput = false;

            // чтобы заполнить форму новыми значениями
            ModelState.Clear();

            return View("Add", album);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Add(Album album)
        {
            context.Albums.Add(album);
            context.SaveChanges();

            return RedirectToAction("Index", new { id = album.ID });
        }

        private Album ParseResponse(XDocument doc)
        {
            string artist = (string)doc.Root.Element("album").Element("artist");
            string albumName = (string)doc.Root.Element("album").Element("name");

            int? year = null;
            DateTime releaseDate;
            DateTime.TryParse((string)doc.Root.Element("album").Element("releasedate"), out releaseDate);
            if (releaseDate != DateTime.MinValue)
                year = releaseDate.Year;

            // TODO выбирать картинки не больше 600 x 600 px
            var imageElement = doc.Root.Descendants("image")
                    .FirstOrDefault(e => e.Attribute("size") != null && e.Attribute("size").Value == "mega");
            string image = imageElement != null ? (string)imageElement : null;

            var descElement = doc.Root.Element("album").Element("wiki");
            string description = descElement != null ? (string)descElement.Element("summary") : null;

            XElement tracksElement = doc.Root.Element("album").Element("tracks");
            List<Track> tracks = tracksElement.Elements().Select(track => new Track
            {
                Number = int.Parse(track.Attribute("rank").Value),
                Name = track.Element("name").Value,
                Duration = int.Parse(track.Element("duration").Value)
            }).ToList();

            return CreateAlbum(artist, albumName, image, year, tracks, description);
        }

        private Album CreateAlbum(string artist, string name, string image, int? year, List<Track> tracks, string description)
        {
            return new Album()
            {
                Artist = artist,
                Name = name,
                Image = image,
                Year = year,
                Tracklist = tracks,
                Description = description,
            };
        }
    }
}