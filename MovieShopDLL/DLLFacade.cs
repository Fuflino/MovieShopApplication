using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieShopDLL.Entities;
using MovieShopDLL.Managers;

namespace MovieShopDLL
{
    public class DLLFacade
    {
        private IManager<Customer, int> cm;
        public IManager<Customer, int> GetCustomerManager()
        {
            return cm ?? (cm = new CustomerManager());
        }
    }
}
