using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using PizzaDelivery.Models;
using Microsoft.AspNet.Identity;

namespace PizzaDelivery.Controllers
{
    public class TextAPIsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void SendText(string userId, Order order, GoogleMapInformation googleMap)
        {
            
            var user = db.Customers.Where(c => c.UserId == userId).Select(c => c).FirstOrDefault();
            var customerName = user.FirstName;
            var customerDeliveryTime = googleMap.RouteTime;
            var orderStatus = order.OrderOutForDelivery;
            

            string toPhoneNumber = "+1" + user.PhoneNumber;
            TextAPI textAPI = new TextAPI();
            textAPI.SendToPhoneNumber = toPhoneNumber;
            string sendFromNumber = "+19205450383";
            textAPI.SendFromPhoneNumber = sendFromNumber;
            const string accountSid = "ACf309d8bdb8d911c97fa8855013d33c1a";
            const string authToken = "442b02a8ee25201565d6c92237d53f81";

            if (orderStatus != true)
            {
                string textBody = "Thank you for ordering from The Italian Eatery, " + customerName + "!";

                // Find your Account Sid and Auth Token at twilio.com/console

                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(toPhoneNumber);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber(sendFromNumber),
                    body: textBody);
            }
            else if(orderStatus == true)
            {
                string textBody = "Your food is now out for delivery, " + customerName + "! Your driver should be dropping off in approximately " + customerDeliveryTime + " minutes! Enjoy the best Italian food in Milwaukee!!!";

                // Find your Account Sid and Auth Token at twilio.com/console

                TwilioClient.Init(accountSid, authToken);

                var to = new PhoneNumber(toPhoneNumber);
                var message = MessageResource.Create(
                    to,
                    from: new PhoneNumber(sendFromNumber),
                    body: textBody);
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
