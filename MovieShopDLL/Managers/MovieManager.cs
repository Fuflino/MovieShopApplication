using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    public class MovieManager : IManager<Movie, int>
    {
        public MovieManager()
        {
            InitDummyMovies();
        }

        private void InitDummyMovies()
        {
            Movie m = new Movie()
            {
                Id = 1,
                Title = "Test1",
                Genre = new Genre() { Id = 1, Movies = new List<Movie>(), Name = "Horror" },
                ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                Orders = new List<Order>(),
                Price = 100,
                Year = 1992
            };
            Create(m);
        }

        public Movie Create(Movie t)
        {
            using (var dbContext = new MovieShopContext())
            {
                dbContext.Movies.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Movie Read(int id)
        {
            using (var dbContext = new MovieShopContext())
            {
                return dbContext.Movies.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Movie> ReadAll()
        {
            using (var dbContext = new MovieShopContext())
            {

                return dbContext.Movies.ToList();
            }
        }

        public Movie Update(Movie t)
        {
            using (var dbContext = new MovieShopContext())
            {
                dbContext.Entry(t).State = EntityState.Modified;
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var dbContext = new MovieShopContext())
            {
                var toBeDeleted = dbContext.Movies.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Movies.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
