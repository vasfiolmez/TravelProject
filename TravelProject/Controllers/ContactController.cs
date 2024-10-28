using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class ContactController : Controller
    {
        TravelContext context = new TravelContext();
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
        public PartialViewResult Header()
        {
            return PartialView();
        }
        public PartialViewResult PartialContact()
        {
            var values = context.Contacts.FirstOrDefault();
            return PartialView(values);
        }
    }
}