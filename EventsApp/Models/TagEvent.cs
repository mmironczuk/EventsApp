using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class TagEvent
    {
        public int TagEventId { get; set; }
        public int TagId { get; set; }
        public int MainEventId { get; set; }
        public virtual Tag Tag { get; set; }
        public virtual MainEvent MainEvent { get; set; }
    }
}
