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

namespace HallOfFame_dotnet.Controllers
{
    public class AlbumController : Controller
    {
        private readonly AlbumContext context = new AlbumContext();

        public ActionResult Index(string artist, string albumName)
        {
            var album = context.Albums.FirstOrDefault(a => (a.Artist == artist && a.Name == albumName));

            return View(Mapper.MapToAlbumViewModel(album));
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new AlbumCreateModel());
        }

        [HttpPost]
        public ActionResult Create(AlbumCreateModel model)
        {
            if (ModelState.IsValid)
            {
                TempData["model"] = model;
                return RedirectToAction("Edit", new {model});
            }
            return View();
        }

        public ActionResult Edit(AlbumCreateModel model)
        {
            if (model == null)
            {
                model = (AlbumCreateModel)TempData["model"];
            }
            AlbumEditModel album = GetLastfmAlbumInfo(model).Result;
            return View(album);
        }

        [HttpPost, ValidateInput(false)] // TODO пока не валидировать
        public ActionResult Save(AlbumEditModel album)
        {
            if (ModelState.IsValid)
            {
                context.Albums.Add(Mapper.MapToAlbum(album));
                context.SaveChanges();
                return RedirectToAction("Index", new { artist = album.Artist, albumName = album.Name });
            }
            return View("Edit");
        }

        public ActionResult Remove(string artist, string albumName)
        {
            var album = context.Albums.FirstOrDefault(a => (a.Artist == artist && a.Name == albumName));

            context.Albums.Remove(album);
            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        private async Task<AlbumEditModel> GetLastfmAlbumInfo(AlbumCreateModel model)
        {
            var uri = new Uri(string.Format("{0}?method=album.getInfo&artist={1}&album={2}&api_key={3}",
                WebConfigurationManager.AppSettings["lastfmApi"], model.Artist, model.Name, WebConfigurationManager.AppSettings["lastfmKey"]));

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
            {
                //return new ContentResult { Content = doc.Root.Element("error").Value }; // TODO переделать
            }

            return ParseResponse(doc);
        }

        private AlbumEditModel ParseResponse(XDocument doc)
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

            return Mapper.MapToAlbumEditModel(CreateAlbum(artist, albumName, image, year, tracks, description));
        }

        private Album CreateAlbum(string artist, string name, string image, int? year, List<Track> tracks, string description)
        {
            return new Album
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