using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MovieShopDLL.Entities
{
    public class Genre : AbstractEntity
    {
        public string Name { get; set; }
        //[JsonIgnore]
        //[IgnoreDataMember]
        public List<Movie> Movies { get; set; }
    }
}
