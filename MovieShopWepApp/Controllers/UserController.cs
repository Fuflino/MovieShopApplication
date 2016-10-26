using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using MovieShopDLL;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;
using MovieShopWepApp.Models;

namespace MovieShopWepApp.Controllers
{
    public class UserController : Controller
    {
        private IManager<Genre, int> _genreManager = new DLLFacade().GetGenreManager();
        private IManager<Movie, int> _movieManager = new DLLFacade().GetMovieManager();
        private IManager<Customer, int> _customerManager = new DLLFacade().GetCustomerManager();
        private IManager<Order, int> _orderManager = new DLLFacade().GetOrderManager();

        // GET: User
        public ActionResult Index(int? id)
        {
            var model = new UserViewModel()
            {
                Genres = _genreManager.ReadAll(),
                Movies = _movieManager.ReadAll()
            };
            if (id.HasValue)
            {
                model.Genre = _genreManager.Read(id.Value);
            }
            return View(model);
        }

        public PartialViewResult GetMovieDetails(int? id)
        {
            return PartialView("PartialMovieDetailsView", _movieManager.Read(id.Value));
        }

        public PartialViewResult GetMoviesResult(int? id)
        {   
            return PartialView("PartialMovieView", _genreManager.Read(id.Value).Movies);
        }

        public ActionResult MovieDetails(int id)
        {
            return View(_movieManager.Read(id));
        }


        [HttpGet]
        public ActionResult Checkout(int id, string email)
        {
            var movieToOrder = _movieManager.Read(id);
            Customer c = SearchByEmail(email);

            var viewModel = new CheckoutViewModel() {customer = c, movie = movieToOrder};
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Checkout(int id, Customer customer)
        {
            if (customer.Id < 1)
            {
                customer = _customerManager.Create(customer);
            }
            else
            {
                customer = _customerManager.Update(customer);
            }
            var movie = _movieManager.Read(id);
            var order = new Order() { MovieId = movie.Id, CustomerId = customer.Id, DateTime = DateTime.Now};
            order = _orderManager.Create(order);
            movie.Orders.Add(order);       
            customer.Orders.Add(order);
            _movieManager.Update(movie);
            _customerManager.Update(customer);
            return RedirectToAction("Index");
        }

        public Customer SearchByEmail(string email)
        {
            if (email != null)
            {
                foreach (var customer in _customerManager.ReadAll())
                {
                    if (customer.Email.Trim().Equals(email.Trim())) return customer;
                }
            }
            return null;
        }
    }
}