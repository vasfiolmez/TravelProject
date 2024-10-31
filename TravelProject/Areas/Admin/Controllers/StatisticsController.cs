using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;

namespace TravelProject.Areas.Admin.Controllers
{
    public class StatisticsController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            List<int> capacity = context.Destinations.Select(x => x.Capacity).ToList();
            ViewBag.Capacity = capacity;

            List<decimal> price = context.Destinations.Select(x => x.Price).ToList();
            ViewBag.Price = price;

            List<int> daynight = context.Destinations.Select(x => x.DayNight).ToList();
            ViewBag.DayNight = daynight;

            var values = context.Destinations.ToList();




            ViewBag.destinasyon=context.Destinations.Select(s=>s.Title).ToList();
            return View(values);
         
        }
    }
}