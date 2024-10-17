using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelProject.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
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
            return PartialView();
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