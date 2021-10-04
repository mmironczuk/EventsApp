using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Tag
    {
        public int TagId { get; set; }
        public string name { get; set; }
        public string group { get; set; }
        public virtual ICollection<TagEvent> TagEvents { get; set; }
    }
}
