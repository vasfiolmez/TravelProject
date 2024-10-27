using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string Title { get; set; }


        public int DayNight { get; set; }
        public string SliderImageUrl { get; set; }
        public string SliderDescription { get; set; }
        public decimal Price { get; set; }
        public int Capacity { get; set; }

        public string Image { get; set; }
        public string Description { get; set; }

        public string TourStartLocationName {  get; set; }
        public string TourStartMapLocation { get; set; }

        public int CityId { get; set; }
        public virtual City City { get; set; }

        public ICollection<Reservation> Reservations { get; set; }
    }
}