using System.ComponentModel.DataAnnotations;

namespace HallOfFame_dotnet.Models
{
    public class AlbumCreateModel
    {
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Name { get; set; }
    }
}