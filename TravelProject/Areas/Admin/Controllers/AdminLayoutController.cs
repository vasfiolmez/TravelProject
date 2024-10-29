using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;

namespace TravelProject.Areas.Admin.Controllers
{
    public class AdminLayoutController : Controller
    {
      TravelContext _context=new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        public PartialViewResult PartialHead()
        {
            return PartialView();
        }
        public PartialViewResult PartialSidebar() 
        {
            return PartialView();
        }
        public PartialViewResult PartialNavbar() 
        {
            return PartialView();
        }
        public PartialViewResult DestinationNavbar()
        {
            var destinations = _context.Destinations.OrderByDescending(d => d.DestinationId).Take(4).ToList();
            return PartialView(destinations); 
        }
        public PartialViewResult MessagesNavbar() 
        {
            var id = Session["id"];
            var inbox = _context.Messages.Where(x => x.ReceiverAdminId.ToString() == id.ToString()).ToList();
            ViewBag.message= _context.Messages.Where(x => x.ReceiverAdminId.ToString() == id.ToString()).Count().ToString();
            return PartialView(inbox);
        }
        public PartialViewResult PartialFooter()
        {
            return PartialView();
        }
        public PartialViewResult PartialScripts()
        {
            return PartialView();
        }
    }
}
