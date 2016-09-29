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
    class GenreManager : IManager<Genre, int>
    {
        private MovieShopContext dbContext = new MovieShopContext(); 
        public Genre Create(Genre t)
        {
            using (dbContext)
            {
                dbContext.Genres.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Genre Read(int id)
        {
            using (dbContext)
            {
                return dbContext.Genres.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Genre> ReadAll()
        {
            using (dbContext)
            {
                return dbContext.Genres.ToList();
            }
        }

        public Genre Update(Genre t)
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
