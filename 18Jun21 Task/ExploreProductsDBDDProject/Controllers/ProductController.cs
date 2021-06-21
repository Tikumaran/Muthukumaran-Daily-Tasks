using ExploreProductsDBDDProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExploreProductsDBDDProject.Controllers
{
    public class ProductController : Controller
    {
        private AdventureWorks2019Entities con;
        public ProductController()
        {
           con = new AdventureWorks2019Entities();
        }
        // GET: Product
        public ActionResult Index()
        {
            List<ProductCategory> productCat = con.ProductCategories.ToList();
            ViewBag.ProductCat= new SelectList(productCat, "ProductCategoryID", "Name");
            return View();
        }
        public ActionResult GetSubProducts(int ProductCategoryId)
        {
            List<ProductSubcategory> subcategories = con.ProductSubcategories.Where(x => x.ProductCategoryID == ProductCategoryId).ToList();
            ViewBag.ProductSub = new SelectList(subcategories,"ProductSubcategoryID", "Name");
            return PartialView("DisplaySub");
        }

        public ActionResult GetProduct(int ProductSubcategoryId)
        {
            List<Product> products = con.Products.Where(x => x.ProductSubcategoryID == ProductSubcategoryId).ToList();
            ViewBag.Lists = new SelectList(products,"ProductID", "Name");
            return PartialView("DisplayProduct");
        }
    }
}