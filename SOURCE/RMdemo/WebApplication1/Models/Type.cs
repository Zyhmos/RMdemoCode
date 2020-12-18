using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Type : IProductType
    {
        public int TypeID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
    }
}