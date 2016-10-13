using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopWepApp.Controllers
{
    public class OrdersController : Controller
    {
        private IManager<Order, int> mgr = new DLLFacade().GetOrderManager();
        private MovieShopContext db = new MovieShopContext();

        // GET: Orders
        public ActionResult Index()
        {
            //var orders = db.Orders.Include(o => o.Customer).Include(o => o.Movie);
            //return View(orders.ToList());
            return Redirect("~/Admin/Index");
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = mgr.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = mgr.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", order.CustomerId);
            ViewBag.MovieId = new SelectList(db.Movies, "Id", "Title", order.MovieId);
            ViewBag.Id = new SelectList(db.Movies, "Id", "Title", order.Id);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DateTime,CustomerId,MovieId")] Order order)
        {
            
            if (ModelState.IsValid)
            {
                mgr.Update(order);
                return Redirect("~/admin/index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "FirstName", order.CustomerId);
            ViewBag.Id = new SelectList(db.Movies, "Id", "Title", order.Id);
            return Redirect("~/admin/index");
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = mgr.Read(id.Value);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mgr.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
