using System.Collections.Generic;
using System.Data.Entity;
using HallOfFame_dotnet.Models;

namespace HallOfFame_dotnet.Infrastructure
{
    public class AlbumInitializer : DropCreateDatabaseIfModelChanges<AlbumContext>
    {
        protected override void Seed(AlbumContext context)
        {
            var albums = new List<Album>
            {
                new Album
                {
                    ID = 1,
                    Artist = "Metallica",
                    Name = "Master Of Puppets",
                    Year = 1986,
                    Image = "http://userserve-ak.last.fm/serve/500/61682269/Master+of+Puppets+cover_masterofpuppets_lg.jpg"
                },
                new Album
                {
                    ID = 2,
                    Artist = "Slayer",
                    Name = "Reign In Blood",
                    Year = 1986,
                    Image = "http://userserve-ak.last.fm/serve/500/46065199/Reign+in+Blood.png"
                },
                new Album
                {
                    ID = 3,
                    Artist = "Totalselfhatred",
                    Name = "Totalselfhatred",
                    Year = 2008,
                    Image = "http://userserve-ak.last.fm/serve/500/22875641/Totalselfhatred+80a386ab638d330b9251c2589b694a.jpg"
                },
                new Album
                {
                    ID = 4,
                    Artist = "Radiohead",
                    Name = "In Rainbows",
                    Year = 2007,
                    Image = "http://userserve-ak.last.fm/serve/500/47882499/In+Rainbows.png"
                },
                new Album
                {
                    ID =5,
                    Artist = "Jon Hopkins",
                    Name = "Insides",
                    Year = 2008,
                    Image = "http://userserve-ak.last.fm/serve/_/87289153/Insides+DS015D2.png"
                },
                new Album
                {
                    ID = 6,
                    Artist = "Rob Dougan",
                    Name = "Furious Angels",
                    Year = 2001,
                    Image = "http://userserve-ak.last.fm/serve/500/45719219/Furious+Angels.png"
                },
            };

            albums.ForEach(a => context.Albums.Add(a));
            context.SaveChanges();
        }
    }
}