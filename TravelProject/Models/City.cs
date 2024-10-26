using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public ICollection<TourCityImage> TourCityImages { get; set; }
        public ICollection<Destination> Destinations { get; set; }
    }
}