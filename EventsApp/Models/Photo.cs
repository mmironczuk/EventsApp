using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Photo
    {
        public int PhotoId { get; set; }
        public string photo { get; set; }
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
    }
}
