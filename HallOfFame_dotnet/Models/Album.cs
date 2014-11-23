﻿using System.ComponentModel.DataAnnotations.Schema;

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
    }
}