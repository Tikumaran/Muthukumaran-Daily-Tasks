using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CodeFirstEFProject
{
    class Product
    {
        [Key]
        public int ProductId { get; set; }
        public String ProductName { get; set; }
        public string ProductCategory { get; set; }
        public float ProductPrice { get; set; }
        public int ProductQty { get; set; }
    }
}
