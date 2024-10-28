using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
    public class CityController : Controller
    {
        TravelContext context = new TravelContext();

        public ActionResult CityList()
        {
            ViewBag.tableAdı = "Şehir Listesi";
            var values = context.Cities.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCity()
        {

            List<SelectListItem> country = (from x in context.Countries.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CountryName,
                                             Value = x.CountryId.ToString()

                                         }).ToList();
            ViewBag.country = country;

            ViewBag.tableAdı = "Yeni Şehir Ekleme";
            return View();
        }
        [HttpPost]
        public ActionResult CreateCity(City city)
        {
            ViewBag.tableAdı = "Yeni Şehir Ekleme";
            context.Cities.Add(city);
            context.SaveChanges();
            return RedirectToAction("CityList", "City", "Admin");
        }
        [HttpGet]
        public ActionResult UpdateCity(int id)
        {
            ViewBag.tableAdı = "Şehir Bilgisi Güncelleme";

            List<SelectListItem> country = (from x in context.Countries.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CountryName,
                                                Value = x.CountryId.ToString()

                                            }).ToList();
            ViewBag.country = country;

            var value = context.Cities.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCity(City country)
        {
            var value = context.Cities.Find(country.CityId);
            value.CityName = country.CityName;
            context.SaveChanges();
            return RedirectToAction("CityList", "City", "Admin");
        }
        public ActionResult ChangeCityStatusToTrue(int id)
        {
            var value = context.Cities.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("CityList", "City", "Admin");
        }
        public ActionResult ChangeCityStatusToFalse(int id)
        {
            var value = context.Cities.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("CityList", "City", "Admin");
        }
    }
}