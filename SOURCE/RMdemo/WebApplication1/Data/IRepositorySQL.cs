using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    interface IRepositorySQL
    {
        void GetAllData();
        void FindByID(int id);
        void DeleteByID(int id);
    }
}
