using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;
using MovieShopWepApp.Models;

namespace MovieShopWepApp.Controllers
{
    public class UserController : Controller
    {

        private IManager<Movie, int> _movieManager = new DLLFacade().GetMovieManager();
        private IManager<Customer, int> _customerManager = new DLLFacade().GetCustomerManager();
        private IManager<Order, int> _orderManager = new DLLFacade().GetOrderManager();

        // GET: User
        public ActionResult Index()
        {
            return View(_movieManager.ReadAll());
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
        public ActionResult Checkout(Customer customer, int movieId)
        {
            var movie = _movieManager.Read(movieId);
            var order = new Order() {Customer = customer, CustomerId = customer.Id, Movie = movie, MovieId = movieId, DateTime = DateTime.Now};
            movie.Order = order;
            _orderManager.Create(order);
            if (customer.Id < 1)
            {
                _customerManager.Create(customer);
            }
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