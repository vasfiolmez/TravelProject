using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;

namespace TravelProject.Areas.Admin.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        TravelContext context=new TravelContext();
        public ActionResult Index()
        {
            var a = Session["x"];
            var values=context.Admins.Where(x=>x.UserName==a).FirstOrDefault();
            return View(values);
        }
    }
}