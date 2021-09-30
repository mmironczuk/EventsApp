using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Place
    {
        public int PlaceId { get; set; }
        [Required]
        [Display(Name ="Województwo")]
        public string province { get; set; }
        [Required]
        [Display(Name = "Miasto")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string address { get; set; }
        [Display(Name ="Typ obiektu")]
        public string placeType{ get; set; }
        public virtual ICollection<MainEvent> MainEvents { get; set; }
    }
}
