using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Album
    {
        public int AlbumId { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
        public string title { get; set; }
        [Display(Name = "Opis")]
        public string description { get; set; }
        [Display(Name = "Wydarzenie")]
        public int MainEventId { get; set; }
        public virtual MainEvent MainEvent { get; set; }
        public virtual ICollection<Photo> Photos{get;set;}
    }
}
