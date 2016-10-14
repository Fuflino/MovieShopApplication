using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Razor;
using MovieShopDLL;
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
            if (id != null)
            {
                return PartialView("PartialMovieView", new UserViewModel() { Genre = _genreManager.Read(id.Value), Movies = _movieManager.ReadAll() });
            }
            return View(new UserViewModel() { Genres = _genreManager.ReadAll(), Movies = _movieManager.ReadAll()});
        }

        public PartialViewResult GetMoviesResult(int? id)
        {
            return PartialView("PartialMovieView", new UserViewModel() { Genre = _genreManager.Read(id.Value), Movies = _movieManager.ReadAll() });
        }

        public ActionResult MovieDetails(int id)
        {
            return View(_movieManager.Read(id));
        }
    }
}