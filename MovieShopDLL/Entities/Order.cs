using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    public class Order : AbstractEntity
    {
        public DateTime DateTime { get; set; }
        public Customer Customer { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
