using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelProject.Context;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        TravelContext context = new TravelContext();
        public ActionResult Inbox(TravelProject.Models.Admin admin)
        {
            var adminId = Session["id"];
            var values = context.Messages.Where(x => x.ReceiverAdminId.ToString() == adminId.ToString()).ToList();
            return View(values);
        }
        public ActionResult SendBox()
        {
            var adminId = Session["id"];
            var values = context.Messages.Where(x => x.SenderAdminId.ToString() == adminId.ToString()).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SendMessage()
        {
            var adminId = Session["id"];
            List<SelectListItem> sendMessage = (from x in context.Admins.Where(x => x.AdminId.ToString() != adminId.ToString()).ToList()
                                                select new SelectListItem
                                                {
                                                    Text = x.Email,
                                                    Value = x.AdminId.ToString(),
                                                }).ToList();
            ViewBag.Sendmessage = sendMessage;
            return View();
        }

        [HttpPost]
        public ActionResult SendMessage(TravelProject.Models.Message message)
        {
            var adminId = Session["id"];           
            var senderAdmin = context.Admins.Where(x => x.AdminId.ToString() == adminId.ToString()).Select(y => y.AdminId).FirstOrDefault();
            message.SenderAdminId = senderAdmin;
            message.SendDate = DateTime.Now;
            message.IsRead = false;
            context.Messages.Add(message);
            context.SaveChanges();
            return RedirectToAction("SendBox", "Message", new { area = "Admin" });
        }
    }
}