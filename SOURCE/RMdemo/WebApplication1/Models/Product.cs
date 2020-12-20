using System;
using System.Collections.Generic;
//RMA 20/12/20 TFS-[Practice Task] File Creation

using System.ComponentModel.DataAnnotations;
using WebApplication1.Data;

namespace WebApplication1.Models
{
    public class Product : IProduct
    {
        [Required]
        public int ProductID { get; set; }

        [Required]
        [StringLength(250,MinimumLength = 1)]
        public string Description { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 1)]
        public string Code { get; set; }

        public int TypeID { get; set; }

        public string TypeCode { get; set; }

        [Required]
        [Range(0, Int32.MaxValue, ErrorMessage = "Amount can't be negative")]
        public int Amount { get; set; }

        [Required]
        [Range(0.01, Double.MaxValue, ErrorMessage = "It has to cost something")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid price")]
        public double Price { get; set; }
    }
}