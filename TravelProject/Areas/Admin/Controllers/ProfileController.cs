using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

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
        [HttpPost]
        public ActionResult Index(TravelProject.Models.Admin admin)
        {
            var value = context.Admins.Find(admin.AdminId);
            value.Name = admin.Name;
            value.Surname = admin.Surname;
            value.UserName = admin.UserName;
            value.Password = admin.Password;
            value.Email = admin.Email;           
            value.Password = admin.Password;
            if (admin.ImageUrl != null)
            {
                value.ImageUrl = "/AdminTeması/assets/img/" + admin.ImageUrl;
            }
            context.SaveChanges();
            return RedirectToAction("Index", "Profile","Admin");

        }
    }
}