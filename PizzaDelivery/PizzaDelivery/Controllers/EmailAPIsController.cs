using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PizzaDelivery.Models;
using System.Net.Mail;
using Microsoft.AspNet.Identity;

namespace PizzaDelivery.Controllers
{
    public class EmailAPIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult ShowError()
        {
            return RedirectToAction("ShowError");
        }

        public ActionResult ShowSuccess()
        {
            return RedirectToAction("ShowSuccess");
        }

        public ActionResult SendEmail()
        {
            return View();
        }

        [HttpPost]
        public void SendEmail(string userID)
        {
            userID = User.Identity.GetUserId();
            var user = db.Users.Where(c => c.Id == userID).FirstOrDefault();
            var userEmail = user.Email;

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            System.Net.NetworkCredential credentials =
            new System.Net.NetworkCredential("oliver.ryan9008@gmail.com", "Yashua86");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("devcodeitalianeatery@gmail.com", "The Italian Eatery");
            msg.To.Add(new MailAddress(userEmail));

            msg.Subject = "Thank God";
            msg.IsBodyHtml = true;
            msg.Body = string.Format("<html><head></head><body><b>Fuck yes...... this worked!!!</b></body>");

            client.Send(msg);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
