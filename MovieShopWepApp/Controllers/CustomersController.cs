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
    public class CustomersController : Controller
    {
        private IManager<Customer, int> CusMgr = new DLLFacade().GetCustomerManager();
        private IManager<Order, int> OrdMgr = new DLLFacade().GetOrderManager();
        private IManager<Movie, int> MovMgr = new DLLFacade().GetMovieManager();
        private MovieShopContext db = new MovieShopContext();

        // GET: Customers
        public ActionResult Index()
        {
            return Redirect("~/Admin/Index");
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            ViewBag.Id = new SelectList(db.Addresses, "Id", "StreetName");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CusMgr.Create(customer);
                return RedirectToAction("Index");
            }

            ViewBag.Id = new SelectList(db.Addresses, "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CusMgr.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id = new SelectList(db.Addresses, "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                CusMgr.Update(customer);
                return RedirectToAction("Index");
            }
            ViewBag.Id = new SelectList(db.Addresses, "Id", "StreetName", customer.Id);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = CusMgr.Read(id.Value);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (var order in CusMgr.Read(id).Orders)
            {
                Order orderFromDatabase = OrdMgr.Read(order.Id);
                var movieToHaveOrderRemoved = orderFromDatabase.Movie;
                movieToHaveOrderRemoved.Order = null;
                MovMgr.Update(movieToHaveOrderRemoved);
                OrdMgr.Delete(order.Id);
            }
            CusMgr.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
