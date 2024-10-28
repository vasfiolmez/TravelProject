using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;



namespace TravelProject.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        TravelContext context = new TravelContext();

        [Authorize]
        public ActionResult CategoryList()
        {
            ViewBag.tableAdı = "Tur Kategori Listesi";
            var values = context.Categories.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            ViewBag.tableAdı = "Tur Kategori Oluştur";
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            ViewBag.tableAdı = "Tur Kategori Oluştur";
            category.CategoryStatus = false;
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList","Category","Admin");
        }
        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            var value = context.Categories.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            var value = context.Categories.Find(category.CategoryId);
            value.CategoryName = category.CategoryName;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
        public ActionResult ChangeCategoryStatusToTrue(int id)
        {
            var value = context.Categories.Find(id);
            value.CategoryStatus = true;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
        public ActionResult ChangeCategoryStatusToFalse(int id)
        {
            var value = context.Categories.Find(id);
            value.CategoryStatus = false;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
    }
}