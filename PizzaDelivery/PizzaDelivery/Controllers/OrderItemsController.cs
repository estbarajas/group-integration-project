﻿using System;
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
    public class OrderItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: OrderItems
        public ActionResult Index()
        {
            var orderItems = db.OrderItems.Include(o => o.Item);
            return View(orderItems.ToList());
        }

        public ActionResult SingleIndex(string searchString)
        {

            //var orderItem = db.OrderItems.Where(o => o.OrderId == order.Id);
            //var total = 0;
            //foreach (var item in orderItem)
            //{
            //    total = total + item.Item.Price;
            //}
            //order.Total = total;

            //Employee employee = new Employee();

            //var orderItemList = from s in db.OrderItems
            //                   select s;

            //string userId = User.Identity.GetUserId();
            //var customerInfo = db.Customers.Where(c => c.UserId.Equals(userId)).Single();
            //int? orderId = customerInfo.OrderId;
            //orderItemList = orderItemList.Include(o=>o.Item).Include(o=>o.Order).Where(s => s.OrderId == orderId);
            var latestOrder = db.Orders.OrderByDescending(c => c.Id).FirstOrDefault();

            var userId = User.Identity.GetUserId();


            var orderItem = db.OrderItems.Include(o=>o.Item).Include(o=>o.Order).Where(o => o.Order.UserId == userId && o.OrderId == latestOrder.Id).ToList();


            var total = 0;
            foreach (var item in orderItem)
            {
                total += item.Item.Price;
            }
            orderItem.First().Order.Total = total;

            ViewBag.TotalAmount = total;

            

            var coupons = from s in db.Coupons
                          select s;
            if (!String.IsNullOrEmpty(searchString)) //use this for day and bottom code run all time for zipcode
            {
                var coupon = coupons.Where(s => s.Name.Contains(searchString)).Select(v => v.Value).First();
                ViewBag.TotalAmount = total - coupon;
            }

           


            //return View(orderItemList.ToList());
            return View(orderItem);
        }

        // GET: OrderItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // GET: OrderItems/Create
        public ActionResult Create()
        {
           

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name");
            return View();
        }

        // POST: OrderItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ItemId")] OrderItem orderItem)
        {
            var orderId = db.Orders.OrderByDescending(c => c.Id).FirstOrDefault();
            orderId.UserId = User.Identity.GetUserId();
            //orderItem.Order.UserId = User.Identity.GetUserId();
            var result = db.Orders.OrderByDescending(c => c.Id).Select(c => c.Id).First();
            orderItem.OrderId = result;



            if (ModelState.IsValid)
            {
                db.OrderItems.Add(orderItem);
                db.SaveChanges();
                return RedirectToAction("SingleIndex");
            }

            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
            return View(orderItem);
        }

        public ActionResult Purchase()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Purchase(Order order)
        {
            
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult MakeNewOrder()
        {
            Order order = new Order();
            db.Orders.Add(order);
            db.SaveChanges();
            return RedirectToAction("Create");
        }

        // GET: OrderItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
            return View(orderItem);
        }

        // POST: OrderItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ItemId")] OrderItem orderItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemId = new SelectList(db.Items, "Id", "Name", orderItem.ItemId);
            return View(orderItem);
        }

        // GET: OrderItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderItem orderItem = db.OrderItems.Find(id);
            if (orderItem == null)
            {
                return HttpNotFound();
            }
            return View(orderItem);
        }

        // POST: OrderItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderItem orderItem = db.OrderItems.Find(id);
            db.OrderItems.Remove(orderItem);
            db.SaveChanges();
            return RedirectToAction("SingleIndex");
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
