using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShopDLL.Entities;

namespace MovieShopWepApp.Models
{
    public class PartialViewModel
    {
        public Genre Genre { get; set; }
        public List<Movie> Movies { get; set; }
    }
}