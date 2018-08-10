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
        public void SendEmail(string userId, Order order, GoogleMapInformation google)
        {
            
            var user = db.Customers.Where(c => c.UserId == userId).Select(c => c).FirstOrDefault();
            var userEmail = user.Email;
            var customerName = user.FirstName;
            var orderStatus = order.OrderOutForDelivery;
            var customerDeliveryTime = google.RouteTime;

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.Host = "smtp.gmail.com";
            client.Port = 587;

            // setup Smtp authentication
            NetworkCredential credentials =
            new NetworkCredential("oliver.ryan9008@gmail.com", "Yashua86");
            client.UseDefaultCredentials = false;
            client.Credentials = credentials;

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("devcodeitalianeatery@gmail.com", "The Italian Eatery");
            msg.To.Add(new MailAddress(userEmail));
            if (orderStatus != true)
            {
                msg.Subject = "Thank you for your order!";
                msg.IsBodyHtml = false;
                msg.Body = string.Format("Thank you for ordering from The Italian Eatery, " + customerName + "!");
                

                client.Send(msg);
            }
            else
            {
                msg.Subject = "Thank you for your order!";
                msg.Body = string.Format("Your food is now out for delivery, " + customerName + "! Your driver should be dropping off in approximately " + customerDeliveryTime + " minutes! Enjoy the best Italian food in Milwaukee!!!");
                client.Send(msg);
            }
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
