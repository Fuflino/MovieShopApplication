using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;

namespace MovieShopDLL
{
    public interface IManager<T, K> where T : AbstractEntity
    {
        T Create(T t);
        T Read(K id);
        List<T> ReadAll();
        T Update(T t);
        bool Delete(K id);
    }
}
