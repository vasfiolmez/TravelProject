using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class AboutController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Reservation reservation)
        {
            reservation.PersonCount = 1;
            context.Reservations.Add(reservation);
            context.SaveChanges();
            TempData["Success"] = true;
            return RedirectToAction("Index");
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
            var values=context.Destinations.Where(x=>x.CityId==id).ToList();
            return PartialView(values);
        }
        public PartialViewResult Cities(int id) 
        {
            var values = context.TourCityImages.Where(c => c.CityId == id).ToList();
            var cityName = context.Cities.Where(c => c.CityId == id).Select(c => c.CityName).FirstOrDefault();
            ViewBag.cN= cityName;
            return PartialView(values);
        }
        public PartialViewResult Detail(int id) 
        {
            var cityName=context.TourCityImages.Where(x=>x.CityId==id).Select(c=>c.CityImageName).FirstOrDefault();
            ViewBag.turBaslangic= cityName;

            var values = context.Destinations.Where(x => x.CityId == id).FirstOrDefault();
            return PartialView(values);
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