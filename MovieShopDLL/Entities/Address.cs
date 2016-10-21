using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieShopDLL.Entities
{
    public class Address : AbstractEntity
    {
        public string StreetName { get; set; }
        public int StreetNumber { get; set; }
        public int Zipcode { get; set; }
        public string City { get; set; }
        
    }
}
