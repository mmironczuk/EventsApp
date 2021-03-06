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
        [Display(Name = "Data rozpoczęcia")]
        [DataType(DataType.DateTime)]
        public DateTime dateStart { get; set; }
        [Required]
        [Display(Name = "Data zakończenia")]
        [DataType(DataType.DateTime)]
        public DateTime dateEnd { get; set; }
        [Required]
        [Display(Name ="Ilość biletów")]
        public int freeTickets { get; set; }
        [Display(Name ="Minimalna cena biletów")]
        public float minPrice { get; set; }
        [Display(Name ="Maksymalna cena biletów")]
        public float maxPrice { get; set; }
        [Required]
        public int PlaceId { get; set; }
        [Display(Name ="Kategoria wydarzenia")]
        public string type { get; set; }
        [Display(Name = "Zdjęcie")]
        public byte[] picture { get; set; }
        public bool confirmed { get; set; }
        public string UserId { get; set; }
        public int OrganizerId { get; set; }
        public virtual User User { get; set; }
        public virtual Place Place { get; set; }
        public virtual Organizer Organizer { get; set; }
        public virtual ICollection<Opinion> Opinions { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
        public virtual ICollection<Favourites> Favourites { get; set; }
    }
}
