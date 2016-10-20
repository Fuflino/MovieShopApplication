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
    public class MoviesController : Controller
    {
        private IManager<Movie, int> MovMgr = new DLLFacade().GetMovieManager();
        private IManager<Order, int> OrdMgr = new DLLFacade().GetOrderManager();
        private IManager<Customer, int> CusMgr = new DLLFacade().GetCustomerManager();
        private MovieShopContext db = new MovieShopContext();

        // GET: Movies
        public ActionResult Index()
        {
            return Redirect("~/Admin/Index");
        }

        // GET: Movies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = MovMgr.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movies/Create
        public ActionResult Create()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name");
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,Year,Price,ImageUrl,MovieUrl,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                MovMgr.Create(movie);
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", movie.Id);
            return View(movie);
        }

        // GET: Movies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = MovMgr.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", movie.Id);
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,Year,Price,ImageUrl,MovieUrl,GenreId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                MovMgr.Update(movie);
                return RedirectToAction("Index");
            }
            ViewBag.GenreId = new SelectList(db.Genres, "Id", "Name", movie.GenreId);
            ViewBag.Id = new SelectList(db.Orders, "Id", "Id", movie.Id);
            return View(movie);
        }

        // GET: Movies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Movie movie = MovMgr.Read(id.Value);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            foreach (Order ord in OrdMgr.ReadAll())
            {
                if (ord.Movie.Id == id)
                {
                    Customer customerToHaveOrderRemoved = CusMgr.Read(ord.Customer.Id);
                    customerToHaveOrderRemoved.Orders.RemoveAll(x => x.Id == ord.Id);
                    CusMgr.Update(customerToHaveOrderRemoved);
                    OrdMgr.Delete(ord.Id);
                }
            }
            MovMgr.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
