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
        private IManager<Customer, int> _CustomerManager = new DLLFacade().GetCustomerManager();

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

        public PartialViewResult GetMoviesResult(int? id)
        {

        
            return PartialView("PartialMovieView", _genreManager.Read(id.Value).Movies);
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