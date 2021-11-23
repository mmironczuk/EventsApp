using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsApp.Models
{
    public class Favourites
    {
        public int FavouritesId { get; set; }
        public int MainEventId { get; set; }
        public string UserId { get; set; }
        public virtual MainEvent MainEvent { get; set; }
        public virtual User User { get; set; }
        
    }
}
