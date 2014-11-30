using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HallOfFame_dotnet.Models
{
    public class Album
    {
        public int ID { get; set; }
        [DisplayName("Album name:")]
        public string Name { get; set; }
        [DisplayName("Artist:")]
        public string Artist { get; set; }
        [DisplayName("Year:")]
        public int? Year { get; set; }
        [DisplayName("Image:")]
        public string Image { get; set; }
        [DisplayName("Tracklist:")]
        public virtual ICollection<Track> Tracklist { get; set; }
        //public List<string> Tags { get; set; } 
        [DisplayName("Description:")]
        public string Description { get; set; }
    }

    public class Track
    {
        public int ID { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public string Name { get; set; }
        public int Duration { get; set; }
        public int AlbumID { get; set; }
    }
}