using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TravelProject.Context;

namespace TravelProject.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
           
            return View();
        }
        public PartialViewResult DefaultPartialHead()
        {
            return PartialView();
        }
        public PartialViewResult DefaultPartialHeader()
        {
            return PartialView();
        }
        public PartialViewResult DefaultPartialSlider()
        {
          var values=context.Destinations.Take(4).ToList();       
            return PartialView(values);
        }
        public PartialViewResult DefaultPartialCountry(int page = 1, int pageSize = 3)
        {
            var values = context.Destinations.OrderBy(x => x.DestinationId).Skip((page - 1) * pageSize).Take(pageSize).ToList();
            int totalRecords = context.Destinations.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.CurrentPage = page;
            return PartialView(values);
        }
        public PartialViewResult DefaultPartialReservation()
        {
            return PartialView();
        }

        public PartialViewResult DefaultPartialFooter()
        {
            return PartialView();
        }

        public PartialViewResult DefaultPartialScript()
        {
            return PartialView();
        }  
    }
}