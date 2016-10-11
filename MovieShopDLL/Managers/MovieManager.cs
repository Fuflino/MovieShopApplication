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
        private IManager<Genre, int> _genreManager = new DLLFacade().GetGenreManager();

        public MovieManager()
        {
            //InitDummyMovies();
        }

        private void InitDummyMovies()
        {
            Genre g = new Genre() {Name = "Horror"};
            g = _genreManager.Create(g);
            Movie m1 = new Movie()
            {
                Title = "Test1",
                Description = "This is so horrifying that you will be a whiny kiddy crying in your bed. " +
                              "So BE CAREFUL when watching this imba movie of DOOOOOOM!!!!",
                GenreId = g.Id,
                Genre = g,
                ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                Price = 100,
                Year = 1992
            };
            Create(m1);
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
                var m = dbContext.Movies.FirstOrDefault(x => x.Id == id);
                m.Genre = _genreManager.Read(m.GenreId);
                return m;
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
