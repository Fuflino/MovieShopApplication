using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Context;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Managers
{
    class CustomerManager : IManager<Customer, int>
    {
        public Customer Create(Customer t)
        {
            using (var DbContext = new MovieShopContext())
            {
                DbContext.Customers.Add(t);
                DbContext.SaveChanges();
                return t;
            }

        }

        public Customer Read(int id)
        {
            using (var DbContext = new MovieShopContext())
            {
                return DbContext.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Customer> ReadAll()
        {
            using (var DbContext = new MovieShopContext())
            {
                return DbContext.Customers.ToList();
            }
        }

        public Customer Update(Customer t)
        {

            using (var DbContext = new MovieShopContext())
            {
                DbContext.Entry(t).State = System.Data.Entity.EntityState.Modified;
                DbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (var DbContext = new MovieShopContext())
            {
                if (id != null)
                {
                    var toBeDeleted = DbContext.Customers.FirstOrDefault(x => x.Id == id);
                    DbContext.Customers.Remove(toBeDeleted);
                    DbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
