using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Product : IProduct
    {
        public int ProductID { get; set; }
        public string Description { get; set; }
        public string Code { get; set; }
        public int TypeID { get; set; }
        public string TypeCode { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}