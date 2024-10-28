using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
    public class ReservationController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult ReservationList()
        {
            ViewBag.tableAdı = "Rezervasyon Listesi";
            var values = context.Reservations.ToList();
            return View(values);
        }

        public ActionResult DeleteReservation(int id)
        {
            ViewBag.tableAdı = "Rezervasyon Listesi";
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "İptal Edildi";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult ApprovedReservation(int id)
        {
            ViewBag.tableAdı = "Rezervasyon Listesi";
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "Onaylandı";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        public ActionResult WaitReservation(int id)
        {
            var values = context.Reservations.Find(id);
            values.ReservationStatus = "Beklet";
            context.SaveChanges();
            return RedirectToAction("ReservationList");
        }
        [HttpGet]
        public ActionResult UpdateReservation(int id)
        {
            var value = context.Reservations.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateReservation(Reservation Reservation)
        {
            var value = context.Reservations.Find(Reservation.ReservationId);
            value.ReservationStatus = Reservation.ReservationStatus;
            context.SaveChanges();
            return RedirectToAction("ReservationList");

        }
    }
}