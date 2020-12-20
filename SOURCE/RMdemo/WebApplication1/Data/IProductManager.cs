using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    interface IProductManager
    {
        List<Product> GetAllData();
        Product FindByID(int id);
        void DeleteByID(int id);
        void Edit(Product product);
        List<Models.Type> GetAllTypeData();
    }
}
