using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class MainEvent
    {
        public int MainEventId { get; set; }
        [Required]
        [Display(Name ="Tytuł")]
        public string title { get; set; }
        [Display(Name = "Opis")]
        public string description { get; set; }
        [Required]
        [Display(Name = "Data")]
        [DataType(DataType.DateTime)]
        public DateTime date { get; set; }
        [Required]
        [Display(Name ="Ilość biletów")]
        public int freeTickets { get; set; }
        [Required]
        [Display(Name = "Miejsce odbywania się wydarzenia")]
        public int PlaceId { get; set; }
        public string OrganizerId { get; set; }
        public virtual User Organizer { get; set; }
        public virtual Place Place { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
    }
}
