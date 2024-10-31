using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using TravelProject.Context;

namespace TravelProject.Areas.Admin.Controllers
{
    public class DashboardController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            ViewBag.tableAdı = "Dashboard";

            ViewBag.toplamRezervasyon=context.Reservations.Count().ToString();
            ViewBag.bekletilenRezervasyonSayisi=context.Reservations.Where(x=>x.ReservationStatus=="Beklet").Count().ToString();    
            ViewBag.iptalEdilenRezervasyonSayisi=context.Reservations.Where(x=>x.ReservationStatus=="İptal Edildi").Count().ToString();
            ViewBag.onaylananRezervasyonSayisi = context.Reservations.Where(x => x.ReservationStatus == "Onaylandı").Count().ToString();


            ViewBag.destinayonSayımız=context.Destinations.Count().ToString();
            ViewBag.yurtiçiDestinasyon = context.Destinations.Where(x => x.City.Country.CountryName == "Türkiye").Count().ToString();
            ViewBag.yurtdışıdestinayon= context.Destinations.Where(x => x.City.Country.CountryName != "Türkiye").Count().ToString();
            ViewBag.toplamSehirsayısı= context.Cities.Count().ToString();


            ViewBag.ToplamAdminSayısı=context.Admins.Count().ToString();
            ViewBag.turKategoriSayısı=context.Categories.Count().ToString();
            ViewBag.destinasyonOrtFiyat = context.Destinations.Average(c => c.Price).ToString();
            ViewBag.enKısaTurSüresi=context.Destinations.OrderBy(c=>c.DayNight).Select(c=>c.DayNight).FirstOrDefault();


            return View();
        }
    }
}