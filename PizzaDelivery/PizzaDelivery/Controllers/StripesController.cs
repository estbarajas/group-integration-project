using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Stripe;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    public class StripesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Stripes
        public ActionResult Index()
        {
            StripeConfiguration.SetApiKey("sk_test_CnNJ5zBRKKTfFb3NCSj6MGLf");
            var stripePublishKey = "pk_test_qXVnowf9XbxuKvbKIq8a5UiG";
            ViewBag.StripePublishKey = stripePublishKey;

            return View();
        }
        public ActionResult Charge(string stripeEmail, string stripeToken)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var customer = customers.Create(new StripeCustomerCreateOptions
            {
                Email = stripeEmail,
                SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions
            {
                Amount = 500,//charge in cents
                Description = "Sample Charge",
                Currency = "usd",
                CustomerId = customer.Id
            });

            // further application specific code goes here

            return View("Charge");
        }
    }
}