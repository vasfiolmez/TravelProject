using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
    [Authorize]
    public class DestinationController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult DestinationList()
        {
            ViewBag.tableAdı = "Destinasyon Listesi";
            var values=context.Destinations.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateDestination()
        {
            ViewBag.tableAdı = "Destinasyon Oluşturma Sayfası";
            return View();
        }
        [HttpPost]
        public ActionResult CreateDestination(Destination destination)
        {
            ViewBag.tableAdı = "Destinasyon Oluşturma Sayfası";
            context.Destinations.Add(destination);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination","Admin");
        }
        public ActionResult DeleteDestination(int id)
        {
            var value = context.Destinations.Find(id);
            context.Destinations.Remove(value);
            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateDestination(int id)
        {
            ViewBag.tableAdı = "Destinasyon Güncelleme Sayfası";

            var value =context.Destinations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateDestination(Destination destination)
        {
            ViewBag.tableAdı = "Destinasyon Güncelleme Sayfası";
            var value = context.Destinations.Find(destination.DestinationId);
            value.Description = destination.Description;
            value.City = destination.City;
            value.Country = destination.Country;
            value.DayNight = destination.DayNight;
            value.ImageUrl = destination.ImageUrl;
            value.Title = destination.Title;
            value.Price = destination.Price;

            context.SaveChanges();
            return RedirectToAction("DestinationList", "Destination", "Admin");
        }
    }
}