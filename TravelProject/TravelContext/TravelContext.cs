using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TravelProject.Models;

namespace TravelProject.TravelContext
{
    public class TravelContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations  { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}