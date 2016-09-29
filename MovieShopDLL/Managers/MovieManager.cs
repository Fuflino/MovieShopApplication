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

        public Movie Create(Movie t)
        {
            using (var DbContext = new MovieShopContext())
            {
                DbContext.Movies.Add(t);
                DbContext.SaveChanges();
                return t;
            }
        }

        public Movie Read(int id)
        {
            using (var DbContext = new MovieShopContext())
            {
                return DbContext.Movies.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Movie> ReadAll()
        {
            using (var DbContext = new MovieShopContext())
            {

                return DbContext.Movies.ToList();
            }
        }

        public Movie Update(Movie t)
        {
            using (var DbContext = new MovieShopContext())
            {
                DbContext.Entry(t).State = EntityState.Modified;
                DbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var DbContext = new MovieShopContext())
            {
                var toBeDeleted = DbContext.Movies.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    DbContext.Movies.Remove(toBeDeleted);
                    DbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
