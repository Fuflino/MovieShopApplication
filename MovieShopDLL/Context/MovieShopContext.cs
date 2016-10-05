using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;

namespace MovieShopDLL.Context
{
        public class MovieShopContext : DbContext
        {
            public MovieShopContext() : base("MovieStoreDB")
            {
                
            }

            public DbSet<Genre> Genres { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Address> Addresses { get; set; }



        }
    }

