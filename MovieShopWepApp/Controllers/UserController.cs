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
    }
}