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
    public class AdminController : Controller
    {
        private IManager<Customer, int> cusMgr = new DLLFacade().GetCustomerManager();
        private IManager<Movie, int> movMgr = new DLLFacade().GetMovieManager();
        private IManager<Order, int> ordMgr = new DLLFacade().GetOrderManager();

        // GET: Admin
        public ActionResult Index()
        {
            
            return View(new AdminViewModel() {Customers = cusMgr.ReadAll(), Movies = movMgr.ReadAll(), Orders = ordMgr.ReadAll()});
        }

        
    }
}