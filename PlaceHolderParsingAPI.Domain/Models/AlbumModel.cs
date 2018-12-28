using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceHolderParsingAPI.Domain.Models
{
    /// <summary>
    /// модель альбома
    /// </summary>
    public class AlbumModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
    }
}
