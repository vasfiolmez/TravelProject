using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;

namespace TravelProject.Controllers
{
    public class DefaultController : Controller
    {
        TravelContext context=new TravelContext();
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
            return PartialView();
        }
        public PartialViewResult DefaultPartialCountry()
        {
            var values = context.Destinations.ToList();
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