using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    interface IProductType
    {
        int TypeID { get; set; }
        string Description { get; set; }
        string Code { get; set; }
    }
}
