using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class User:IdentityUser
    {
        public string name { get; set; }
        public string surname { get; set; }
        public DateTime birthDate { get; set; }
        public ICollection<Favourites> Favourites { get; set; }
        public ICollection<Opinion> Opinions { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
    }
}
