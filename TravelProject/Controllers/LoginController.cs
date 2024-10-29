using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Controllers
{
    public class LoginController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            var values = context.Admins.FirstOrDefault(x => x.UserName == admin.UserName && x.Password == admin.Password);
            if (values != null)
            {
                FormsAuthentication.SetAuthCookie(values.UserName, false);
                Session["x"] = values.UserName;
                Session["id"] = values.AdminId;

                Session["mail"] = values.Email;
                Session["image"] = values.ImageUrl;
                Session["name"] = values.Name+" "+values.Surname;
                


                return RedirectToAction("Index", "Profile", new { area = "Admin" });
            }
            else
            {
                return View();
            }
        }
    }
}