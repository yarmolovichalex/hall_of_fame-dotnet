using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HallOfFame_dotnet.Models
{
    public class Album
    {
        public int ID { get; set; }
        [Required]
        [DisplayName("Album name:")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Artist:")]
        public string Artist { get; set; }
        [Required]
        [Range(1900, 2015, ErrorMessage = "Invalid year!")] // TODO
        [DisplayName("Year:")]
        public int? Year { get; set; }
        [Required]
        [Url(ErrorMessage = "Invalid URL!")]
        [DisplayName("Image:")]
        public string Image { get; set; }
        [Required]
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