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
            var m1 = new Movie()
            {
                Id = 1,
                Title = "Horror movie",
                Description = "Just another movie",
                Orders = new List<Order>(),
                ImageUrl = "http://img2.rnkr-static.com/list_img_v2/1755/1041755/C480/the-most-terrifying-japanese-horror-movies-of-all-time-u3.jpg",
                Price = 139.95,
                Year = 2100,
                Genre = new Genre() { Id = 4, Movies = new List<Movie>(), Name = "Sci-Fi" },
                GenreId = 4,
                MovieUrl = "http://www.xnxx.com/video-7r2at9f/blonde_mom_handjob_and_facial"

            };

            var m2 = new Movie()
            {
                Title = "Horror movie",
                Description = "Just another movie",
                Id = 2,
                ImageUrl = "http://img2.rnkr-static.com/list_img_v2/1755/1041755/C480/the-most-terrifying-japanese-horror-movies-of-all-time-u3.jpg",
                Price = 139.95,
                Year = 2100,
                Genre = new Genre() { Id = 3, Movies = new List<Movie>(), Name = "Drama" },
                GenreId = 1,
                MovieUrl = "http://www.xnxx.com/video-7r2at9f/blonde_mom_handjob_and_facial",
                Orders = new List<Order>()

            };

            var m3 = new Movie()
            {
                Title = "Horror movie",
                Description = "Just another movie",
                Id = 3,
                ImageUrl = "http://img2.rnkr-static.com/list_img_v2/1755/1041755/C480/the-most-terrifying-japanese-horror-movies-of-all-time-u3.jpg",
                Price = 139.95,
                Year = 2100,
                Genre = new Genre() { Id = 1, Movies = new List<Movie>(), Name = "Horror"},
                GenreId = 1,
                MovieUrl = "http://www.xnxx.com/video-7r2at9f/blonde_mom_handjob_and_facial",
                Orders = new List<Order>()

            };

            var m4 = new Movie()
            {
                Title = "Horror movie",
                Description = "Just another movie",
                Id = 4,
                ImageUrl = "http://img2.rnkr-static.com/list_img_v2/1755/1041755/C480/the-most-terrifying-japanese-horror-movies-of-all-time-u3.jpg",
                Price = 139.95,
                Year = 2100,
                Genre = new Genre() { Id = 2, Movies = new List<Movie>(), Name = "Comic" },
                GenreId = 1,
                MovieUrl = "http://www.xnxx.com/video-7r2at9f/blonde_mom_handjob_and_facial",
                Orders = new List<Order>()

            };

            Create(m1);
            Create(m2);
            Create(m3);
            Create(m4);
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
