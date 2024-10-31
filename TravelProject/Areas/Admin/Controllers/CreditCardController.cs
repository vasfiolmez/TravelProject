using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TravelProject.Areas.Admin.Controllers
{
    public class CreditCardController : Controller
    {
        // GET: Admin/CreditCard
        public ActionResult Index()
        {
            ViewBag.tableAdı = "Kredi Kartı Ödeme Sayfası";
            return View();
        }
    }
}