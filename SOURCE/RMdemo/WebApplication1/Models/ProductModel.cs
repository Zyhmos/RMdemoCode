using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public Product Selected { get; set; }
        public List<Product> Products { get; set; }
        public List<Type> Types { get; set; }
        public ProductSQL Manager { get; set; }
    }
}