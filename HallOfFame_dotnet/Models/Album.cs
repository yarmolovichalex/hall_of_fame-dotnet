using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HallOfFame_dotnet.Models
{
    public class Album
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public int Year { get; set; }
        public string Image { get; set; }
        public List<Track> Tracklist { get; set; }
        //public List<string> Tags { get; set; } 
        public string Description { get; set; }
    }

    public class Track
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}