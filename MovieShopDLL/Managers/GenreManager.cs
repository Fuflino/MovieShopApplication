using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class GenreManager : IManager<Genre, int>
    {
        public Genre Create(Genre t)
        {
            using (var dbContext = new MovieShopContext())
            {
                dbContext.Genres.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Genre Read(int id)
        {
            using (var dbContext = new MovieShopContext())
            {
                var genre = dbContext.Genres.Include("Movies").FirstOrDefault(x => x.Id == id);
                return genre;
            }
            
        }

        public List<Genre> ReadAll()
        {
            using (var dbContext = new MovieShopContext())
            {
                return dbContext.Genres.ToList();
            }
        }

        public Genre Update(Genre t)
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
                var toBeDeleted = dbContext.Genres.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Genres.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }


    }
}
