﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieShopDLL;
using MovieShopDLL.Entities;

namespace MovieShopWepApp.Controllers
{
    public class UserController : Controller
    {

        private IManager<Movie, int> _movieManager = new DLLFacade().GetMovieManager();

        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MovieDetails(int id)
        {
            return View(_movieManager.Read(id));
        }
    }
}