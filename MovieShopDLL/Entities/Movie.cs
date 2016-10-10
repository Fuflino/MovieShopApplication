using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    public class Movie : AbstractEntity
    {
        
        public Movie()
        {
            
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public string MovieUrl { get; set; }
        //[ForeignKey("Genre")]
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public Order Order { get; set; }
    }
}
