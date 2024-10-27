using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TravelProject.Models
{
    public class SearchViewModel
    {
        public int DestinationId { get; set; }     
        public decimal Price { get; set; }    
        public int CountryId { get; set; }
        public string CountryName { get; set; }
    }
}