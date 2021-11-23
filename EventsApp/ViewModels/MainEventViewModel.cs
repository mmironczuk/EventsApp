using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.ViewModels
{
    public class MainEventViewModel
    {
        public int MainEventId { get; set; }
        [Required]
        [Display(Name = "Tytuł")]
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
        [Display(Name = "Minimalna cena biletów")]
        public float minPrice { get; set; }
        [Display(Name = "Maksymalna cena biletów")]
        public float maxPrice { get; set; }
        [Required]
        [Display(Name = "Miejsce odbywania się wydarzenia")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Województwo")]
        public string province { get; set; }
        [Required]
        [Display(Name = "Miasto")]
        public string city { get; set; }
        [Required]
        [Display(Name = "Adres")]
        public string address { get; set; }
        [Display(Name ="Kategoria wydarzenia")]
        public string type { get; set; }
        [Display(Name = "Zdjęcie")]
        public IFormFile picture { get; set; }
        [Display(Name = "Organizator")]
        public string OrganizerName { get; set; }
    }
}
