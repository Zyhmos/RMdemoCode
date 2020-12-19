using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    interface IProduct
    {
        int ProductID { get; set; }
        string Description { get; set; }
        string Code { get; set; }
        int TypeID { get; set; }
        string TypeCode { get; set; }
        int Amount { get; set; }
        double Price { get; set; }
    }
}
