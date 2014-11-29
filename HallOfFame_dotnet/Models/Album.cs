﻿using System.Collections.Generic;
using System.ComponentModel;

namespace HallOfFame_dotnet.Models
{
    public class Album
    {
        public int ID { get; set; }
        [DisplayName("Album name")]
        public string Name { get; set; }
        public string Artist { get; set; }
        public int? Year { get; set; }
        public string Image { get; set; }
        //public List<string> Tags { get; set; } 
        public string Description { get; set; }

        public virtual ICollection<Track> Tracklist { get; set; }
    }

    public class Track
    {
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int AlbumID { get; set; }
    }
}