using System.Data.Entity;
using HallOfFame_dotnet.Models;

namespace HallOfFame_dotnet.Infrastructure
{
    public class AlbumContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
    }
}