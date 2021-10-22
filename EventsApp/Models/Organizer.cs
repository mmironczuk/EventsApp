using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Organizer
    {
        public int OrganizerId { get; set; }
        public string name { get; set; }
        public bool confirmed { get; set; }
        public virtual ICollection<MainEvent> MainEvents { get; set; }
    }
}
