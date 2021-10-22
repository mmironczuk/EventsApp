using EventsApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventsApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Album> Album { get; set; }
        public DbSet<MainEvent> Event { get; set; }
        public DbSet<Favourites> Favourites { get; set; }
        public DbSet<Opinion> Opinion { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Place> Place { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<EventsApp.Models.Organizer> Organizer { get; set; }
    }
}
