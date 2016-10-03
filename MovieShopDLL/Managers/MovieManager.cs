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
        private MovieShopContext dbContext = new MovieShopContext();
        public Movie Create(Movie t)
        {
            using (dbContext)
            {
                dbContext.Movies.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Movie Read(int id)
        {
            using (dbContext)
            {
                return dbContext.Movies.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Movie> ReadAll()
        {
            using (dbContext)
            {

                return dbContext.Movies.ToList();
            }
        }

        public Movie Update(Movie t)
        {
            using (dbContext)
            {
                dbContext.Entry(t).State = EntityState.Modified;
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (dbContext)
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
