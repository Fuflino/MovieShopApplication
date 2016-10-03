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
    class OrderManager : IManager<Order, int>
    {
        private MovieShopContext dbContext = new MovieShopContext();
        public Order Create(Order t)
        {
            using (dbContext)
            {
                dbContext.Orders.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Order Read(int id)
        {
            using (dbContext)
            {
                return dbContext.Orders.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Order> ReadAll()
        {
            using (dbContext)
            {
                return dbContext.Orders.ToList();
            }
        }

        public Order Update(Order t)
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
                var toBeDeleted = dbContext.Orders.FirstOrDefault(x => x.Id == id);
                if (toBeDeleted != null)
                {
                    dbContext.Orders.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
