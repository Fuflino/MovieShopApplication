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
            Movie m1 = new Movie()
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

            Movie m2 = new Movie()
            {
                Id = 2,
                Title = "Test2",
                Genre = new Genre() { Id = 2, Movies = new List<Movie>(), Name = "Horror" },
                ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                Orders = new List<Order>(),
                Price = 100,
                Year = 1992
            };

            Movie m3 = new Movie()
            {
                Id = 3,
                Title = "Test3",
                Genre = new Genre() { Id = 3, Movies = new List<Movie>(), Name = "Horror" },
                ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                Orders = new List<Order>(),
                Price = 100,
                Year = 1992
            };

            Movie m4 = new Movie()
            {
                Id = 4,
                Title = "Test4",
                Genre = new Genre() { Id = 4, Movies = new List<Movie>(), Name = "Horror" },
                ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                Orders = new List<Order>(),
                Price = 100,
                Year = 1992
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
