using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Opinion
    {
        public int OpinionId { get; set; }
        public int MainEventId { get; set; }
        public string AccountId { get; set; }
        [Display(Name ="Treść")]
        public string content { get; set; }
        public virtual MainEvent MainEvent { get; set; }
        public virtual User User { get; set; }
    }
}
