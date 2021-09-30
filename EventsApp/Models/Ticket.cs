using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        [Display(Name ="Wydarzenie")]
        public int MainEventId { get; set; }
        public string AccountId { get; set; }
        [Display(Name ="Cena")]
        public double cost { get; set; }
        public virtual MainEvent MainEvent { get; set; }
        public virtual User User { get; set; }
    }
}
