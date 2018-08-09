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

        //public ActionResult GetMaps()
        //{

        //    return View();
        //}

        [HttpPost]
        public ActionResult GetMaps(/*string customerDurationResults, string customerDistanceResults, string customerInput*/)
        {
            var userId = User.Identity.GetUserId();
            var customer = db.Customers.Where(c => c.UserId == userId).Select(c => c).First();
            var customerAddress = customer.Address + ", " + customer.City + ", " + customer.State + ", " + customer.Zipcode.ToString();
            ViewBag.ToAdress = customerAddress;
            GoogleMapInformation googleMapInformation = new GoogleMapInformation();
            db.GoogleMapInformations.Add(googleMapInformation);

            googleMapInformation.RouteTime = "5 mins";
            googleMapInformation.RouteDistance = "40 miles";
            googleMapInformation.CustomerAddress = customerAddress;
            var thisGoogle = db.GoogleMapInformations.Where(g => g.ID == 11).FirstOrDefault();

            ViewBag.Time = thisGoogle.RouteTime;
            ViewBag.Distance = googleMapInformation.RouteDistance;
            ViewBag.Address = googleMapInformation.CustomerAddress;

            db.SaveChanges();
            return RedirectToAction("Progress", "OrderItems");
        }

    }
}
