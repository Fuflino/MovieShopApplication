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

            var genre = new Genre() { Id = 1, Name = "Horror" , Movies = new List<Movie>()};
            var genre1 = new Genre() {Id = 2, Name = "Drama", Movies = new List<Movie>() };
            var genre2 = new Genre() {Id = 3, Name = "Thriller", Movies = new List<Movie>() };
            var genre3 = new Genre() {Id = 4, Name = "Science-Fiction", Movies = new List<Movie>() };
            var genre4 = new Genre() {Id = 5, Name = "Romance", Movies = new List<Movie>() };
            var genre5 = new Genre() {Id = 6,  Name = "Crime", Movies = new List<Movie>() };
            var genre6 = new Genre() {Id = 7, Name = "Comedy", Movies = new List<Movie>() };


            for (int i = 1; i <= 6; i++)
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
                                  "Blah Blah Blah Blah Blah Blah Blah Blah Blah",
                    

                };
                movie = context.Movies.Add(movie);
                genre.Movies.Add(movie);

                var movie2 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre1.Id,
                    Genre = genre1,
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
                movie2 = context.Movies.Add(movie2);
                genre1.Movies.Add(movie2);

                var movie3 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre2.Id,
                    Genre = genre2,
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
                movie3 = context.Movies.Add(movie3);
                genre2.Movies.Add(movie3);

                var movie4 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre3.Id,
                    Genre = genre3,
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
                movie4 = context.Movies.Add(movie4);
                genre3.Movies.Add(movie4);

                var movie5 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre4.Id,
                    Genre = genre4,
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
                movie5 = context.Movies.Add(movie5);
                genre4.Movies.Add(movie5);

                var movie6 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre5.Id,
                    Genre = genre5,
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
                movie6 = context.Movies.Add(movie6);
                genre5.Movies.Add(movie6);

                var movie7 = new Movie()
                {
                    Title = "Test" + i,
                    GenreId = genre6.Id,
                    Genre = genre6,
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
                movie7 = context.Movies.Add(movie7);
                genre6.Movies.Add(movie7);

                var customer = new Customer() {FirstName = "Bille" + i, LastName = "Iversen" + i * 2};
                customer = context.Customers.Add(customer);

                var order = new Order() {Customer = customer, Movie = movie, DateTime = DateTime.Now};
                context.Orders.Add(order);
            }
            context.Genres.Add(genre);
            context.Genres.Add(genre1);
            context.Genres.Add(genre2);
            context.Genres.Add(genre3);
            context.Genres.Add(genre4);
            context.Genres.Add(genre5);
            context.Genres.Add(genre6);

            base.Seed(context);
        }
    }
}





