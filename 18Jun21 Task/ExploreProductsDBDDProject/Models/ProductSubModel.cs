using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreProductsDBDDProject.Models
{
    public class ProductSubModel
    {
        public int ProductID { get; set; }
        public int ProductCategoryID { get; set; }
        public int ProductSubCategoryID { get; set; }
    }
}