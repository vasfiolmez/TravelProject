using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using TravelProject.Models;


namespace TravelProject.Context
{
    public class TravelContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations  { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country>  Countries { get; set; }
        public DbSet<TourCityImage> TourCityImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Gönderen admin ile ilişki
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.SenderAdmin)
                .WithMany()
                .HasForeignKey(m => m.SenderAdminId)
                .WillCascadeOnDelete(false);

            // Alıcı admin ile ilişki
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.ReceiverAdmin)
                .WithMany()
                .HasForeignKey(m => m.ReceiverAdminId)
                .WillCascadeOnDelete(false);
        }

    }


}