using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PizzaDelivery.Models;

namespace PizzaDelivery.Controllers
{
    public class GoogleMapInformationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult GetMaps()
        {

            return View();
        }

        [HttpPost]
        public ActionResult GetMaps(string customerDurationResults, string customerDistanceResults, string customerInput)
        {           
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.UserId == userId).Select(c => c).First();
            var customerFullAddress = customer.Address + ", " + customer.City + ", " + customer.State + ", " + customer.Zipcode.ToString();
            ViewBag.FullAddress = customerFullAddress;


            GoogleMapInformation google = new GoogleMapInformation();
            google.RouteTime = customerDurationResults;
            google.RouteDistance = customerDistanceResults;
            google.CustomerAddress = customerFullAddress;
            db.GoogleMapInformations.Add(google);

            ViewBag.Time = google.RouteTime;
            ViewBag.Distance = google.RouteDistance;
            ViewBag.FullAddress = customerFullAddress;

            db.SaveChanges();
            //return RedirectToAction("Progress", "OrderItems");
            return View();
        }

    }
}
