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

                Database.SetInitializer(new MovieDBInitializer());

            }
            
            public DbSet<Genre> Genres { get; set; }
            public DbSet<Customer> Customers { get; set; }
            public DbSet<Movie> Movies { get; set; }
            public DbSet<Order> Orders { get; set; }
            public DbSet<Address> Addresses { get; set; }
            


        }

    public class MovieDBInitializer : DropCreateDatabaseAlways<MovieShopContext>
    {
        protected override void Seed(MovieShopContext context)
        {
            var genre = new Genre() {Name = "Ostbager"};
            genre = context.Genres.Add(genre);

            var movie = new Movie() {Title = "Big shark 2", GenreId = genre.Id};
            movie = context.Movies.Add(movie);
            
            var customer = new Customer() {FirstName = "Bille", LastName = "Iversen"};
            customer = context.Customers.Add(customer);
          
            var order = new Order() { Customer = customer, Movie = movie, DateTime = DateTime.Now};
            context.Orders.Add(order);

            base.Seed(context);
        }
    }
}





