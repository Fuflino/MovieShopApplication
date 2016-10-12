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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().HasRequired<Genre>(m => m.Genre).WithMany(g => g.Movies);

            modelBuilder.Entity<Order>().HasRequired<Movie>(o => o.Movie).WithOptional(m => m.Order);

            modelBuilder.Entity<Order>().HasRequired<Customer>(c => c.Customer).WithMany(g => g.Orders);

            modelBuilder.Entity<Customer>().HasOptional<Address>(c => c.Address).WithRequired(o => o.Customer);

                base.OnModelCreating(modelBuilder);
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

            var genre = new Genre() { Name = "Ostbager" };
            genre = context.Genres.Add(genre);

            for (int i = 1; i <= 20; i++)
            {
                var movie = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre.Id,
                    Genre = genre,
                    ImageUrl = "https://i.ytimg.com/vi/I7WwCzmkBh0/maxresdefault.jpg",
                    MovieUrl = "https://www.youtube.com/embed/bnYlcVh-awE",
                    Price = 100,
                    Year = 1992,
                    Description = "Blah Blah Blah Blah Blah Blah Blah Blah Blah " +
                                  "Blah Blah Blah Blah Blah Blah Blah Blah Blah " +
                                  "Blah Blah Blah Blah Blah Blah Blah Blah Blah " +
                                  "Blah Blah Blah Blah Blah Blah Blah Blah Blah " +
                                  "Blah Blah Blah Blah Blah Blah Blah Blah Blah"
                };
                movie = context.Movies.Add(movie);
                
                var customer = new Customer() {FirstName = "Bille" + i, LastName = "Iversen" + i * 2};
                customer = context.Customers.Add(customer);

                var order = new Order() {Customer = customer, Movie = movie, DateTime = DateTime.Now};
                context.Orders.Add(order);
            }

            base.Seed(context);
        }
    }
}





