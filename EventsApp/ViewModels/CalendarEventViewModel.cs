using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.ViewModels
{
    public class CalendarEventViewModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public string url { get; set; }
    }
}
