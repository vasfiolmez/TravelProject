using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;



namespace TravelProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        TravelContext context = new TravelContext();
        public ActionResult CategoryList()
        {
            ViewBag.tableAdı = "Kategori Listesi";
            var values = context.Categories.ToList();
            return View(values);
        }
    }
}