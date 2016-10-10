using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;
using MovieShopDLL.Managers;

namespace MovieShopDLL
{
    public class DLLFacade
    {
        private IManager<Customer, int> cm;
        private IManager<Movie, int> mm;
        private IManager<Order, int> om;
        private IManager<Genre, int> gm;

        public IManager<Customer, int> GetCustomerManager()
        {
            return cm ?? (cm = new CustomerManager());
        }

        public IManager<Movie, int> GetMovieManager()
        {
            return mm ?? (mm = new MovieManager());
        }

        public IManager<Order, int> GetOrderManager()
        {
            return om ?? (om = new OrderManager());
        }

        public IManager<Genre, int> GetGenreManager()
        {
            return gm ?? (gm = new GenreManager());
        }
    }
}
