using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class DealsController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Reservation reservation)
        {
            
            reservation.ReservationStatus = "Beklet";
            context.Reservations.Add(reservation);
            context.SaveChanges();
            TempData["Success"] = true;
            return RedirectToAction("Index");
        }
        public PartialViewResult Header() 
        {
            return PartialView();
        }
        public PartialViewResult DealSearch()
        {
            List<SelectListItem> destinasyon = (from x in context.Countries.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.CountryName ,
                                                    Value = x.CountryId.ToString()

                                                }).ToList();
            ViewBag.destinasyon = destinasyon;

            List<SelectListItem> destinasyonFiyat = (from x in context.Destinations.OrderBy(y=>y.Price).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Price.ToString(),
                                                    Value = x.DestinationId.ToString()

                                                }).ToList();
            ViewBag.destinasyonf = destinasyonFiyat;


            
            return PartialView();
        }
        public PartialViewResult DealList()
        {
            var values=context.Destinations.ToList();
            return PartialView(values);
        }

    }
}