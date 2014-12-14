using System;
using System.Collections.Generic;

namespace HallOfFame_dotnet.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<Album> Albums { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}