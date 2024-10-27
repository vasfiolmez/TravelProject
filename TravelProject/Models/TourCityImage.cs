using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class TourCityImage
    {
        public int TourCityImageId { get; set; }
        public string CityImage { get; set; }
        public string CityImageName { get; set; }
       
        public int CityId { get; set; }
        public virtual City City { get; set; }

    }
}