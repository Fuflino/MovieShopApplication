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
        private IManager<Customer, int> _CustomerManager = new DLLFacade().GetCustomerManager();

        // GET: User
        public ActionResult Index()
        {
            return View(_movieManager.ReadAll());
        }

        public ActionResult MovieDetails(int id)
        {
            return View(_movieManager.Read(id));
        }



        public ActionResult Checkout(int movieId)
        {
            var movieToOrder = _movieManager.Read(movieId);
            var viewModel = new CheckoutViewModel() { customer = null, movie = movieToOrder };
            return View(viewModel);
        }

        //GET: Checkout view
        public ActionResult Checkout(String email, Movie movieToOrder)
        {
            var customer = SearchByEmail(email);
            var viewModel = new CheckoutViewModel() {customer = customer, movie = movieToOrder};
            return View(viewModel);

        }
        
        public Customer SearchByEmail(String email)
        {
            foreach (var customer in _CustomerManager.ReadAll())
            {
                if (customer.Email.Trim().Equals(email.Trim())) return customer;
            }
            return null;
        }
    }
}