using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        TravelContext context = new TravelContext();
    
        public ActionResult CountryList()
        {
            ViewBag.tableAdı = "Ülke Listesi";
            var values = context.Countries.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCountry()
        {
            ViewBag.tableAdı = "Ülke Ekleme";
            return View();
        }
        [HttpPost]
        public ActionResult CreateCountry(Country country)
        {
            ViewBag.tableAdı = "Ülke Ekleme";
            context.Countries.Add(country);
            context.SaveChanges();
            return RedirectToAction("CountryList", "Country", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateCountry(int id)
        {
            ViewBag.tableAdı = "Ülke Adı Güncelleme";
            var value = context.Countries.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCountry(Country country)
        {
            ViewBag.tableAdı = "Ülke Adı Güncelleme";
            var value = context.Countries.Find(country.CountryId);
            value.CountryName =country.CountryName;
            context.SaveChanges();
            return RedirectToAction("CountryList", "Country", "Admin");
        }
        public ActionResult ChangeCountryStatusToTrue(int id)
        {
            var value = context.Countries.Find(id);
          
            context.SaveChanges();
            return RedirectToAction("CountryList", "Country", "Admin");
        }
        public ActionResult ChangeCountryStatusToFalse(int id)
        {
            var value = context.Countries.Find(id);
            
            context.SaveChanges();
            return RedirectToAction("CountryList", "Country", "Admin");
        }
    }
}