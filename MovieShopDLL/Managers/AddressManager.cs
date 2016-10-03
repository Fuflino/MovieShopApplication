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
    class AddressManager : IManager<Address, int>
    {
        private MovieShopContext dbContext = new MovieShopContext();
        public Address Create(Address t)
        {
            using (dbContext)
            {
                dbContext.Addresses.Add(t);
                dbContext.SaveChanges();
                return t;
            }
        }

        public Address Read(int id)
        {
            using (dbContext)
            {
                return dbContext.Addresses.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Address> ReadAll()
        {
            using (dbContext)
            {
                return dbContext.Addresses.ToList();
            }
        }

        public Address Update(Address t)
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
            var toBeDeleted = dbContext.Addresses.FirstOrDefault(x => x.Id == id);
            if (toBeDeleted != null)
            {
                dbContext.Addresses.Remove(toBeDeleted);
                dbContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
