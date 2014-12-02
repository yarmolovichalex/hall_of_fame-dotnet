using HallOfFame_dotnet.Models;

namespace HallOfFame_dotnet.Infrastructure
{
    public static class Mapper
    {
        public static AlbumViewModel MapToAlbumViewModel(Album album)
        {
            return new AlbumViewModel
            {
                ID = album.ID,
                Artist = album.Artist,
                Name = album.Name,
                Year = album.Year,
                Tracklist = album.Tracklist,
                Image = album.Image,
                Description = album.Description,
            };
        }

        public static AlbumEditModel MapToAlbumEditModel(Album album)
        {
            return new AlbumEditModel
            {
                ID = album.ID,
                Artist = album.Artist,
                Name = album.Name,
                Year = album.Year,
                Tracklist = album.Tracklist,
                Image = album.Image,
                Description = album.Description,
            };
        }

        public static Album MapToAlbum(AlbumEditModel album)
        {
            return new Album
            {
                ID = album.ID,
                Artist = album.Artist,
                Name = album.Name,
                Year = album.Year,
                Tracklist = album.Tracklist,
                Image = album.Image,
                Description = album.Description,
            };
        }
    }
}