using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;

namespace TravelProject.Controllers
{
    public class AboutController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult Head()
        {
            return PartialView();
        }
        public PartialViewResult Header()
        {
            return PartialView();
        }

        public PartialViewResult Banner(int id) 
        {
            var values=context.Destinations.Where(x=>x.DestinationId==id).ToList();
            return PartialView(values);
        }
        public PartialViewResult Cities(int id) 
        {
            var values = context.TourCityImages.Where(c => c.CityId == id).ToList();
            var cityName = context.Cities.Where(c => c.CityId == id).Select(c => c.CityName).FirstOrDefault();
            ViewBag.cN= cityName;
            return PartialView(values);
        }
        public PartialViewResult Detail() 
        {
            return PartialView();
        }

        public PartialViewResult Reservation()
        {
            return PartialView();
        }

        public PartialViewResult Footer()
        {
            return PartialView();
        }

        public PartialViewResult Script()
        {
            return PartialView();
        }
    }
}