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
    class CustomerManager : IManager<Customer, int>
    {
        private MovieShopContext dbContext = new MovieShopContext();

        public CustomerManager()
        {
            foreach (var customer in ReadAll())
            {
                Delete(customer.Id);
            }
            Create(new Customer() {FirstName = "Stefan", LastName = "Thomsen"});
            Create(new Customer() { FirstName = "Morten", LastName = "Greis" });
        }
        public Customer Create(Customer t)
        {
            using (dbContext = new MovieShopContext())
            {
                dbContext.Customers.Add(t);
                dbContext.SaveChanges();
                return t;
            }

        }

        public Customer Read(int id)
        {
            using (dbContext = new MovieShopContext())
            {
                return dbContext.Customers.FirstOrDefault(x => x.Id == id);
            }
        }

        public List<Customer> ReadAll()
        {
            using (dbContext = new MovieShopContext())
            {
                return dbContext.Customers.ToList();
            }
        }

        public Customer Update(Customer t)
        {

            using (dbContext = new MovieShopContext())
            {
                dbContext.Entry(t).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();
                return t;
            }
        }

        public bool Delete(int id)
        {
            using (dbContext = new MovieShopContext())
            {
                if (id != null)
                {
                    var toBeDeleted = dbContext.Customers.FirstOrDefault(x => x.Id == id);
                    dbContext.Customers.Remove(toBeDeleted);
                    dbContext.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}
