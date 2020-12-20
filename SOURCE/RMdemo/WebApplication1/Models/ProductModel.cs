//RMA 20/12/20 TFS-[Practice Task] File Creation

using System.Collections.Generic;

namespace WebApplication1.Models
{
    public class ProductModel
    {
        public Product Selected { get; set; }
        public List<Product> Products { get; set; }
        public List<Type> Types { get; set; }
        public ProductManager Manager { get; set; }
    }
}