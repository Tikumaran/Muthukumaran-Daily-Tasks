using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeFirstEFProject
{
   public class ProductManagement
    {
        private static EntityFrameContext db = new EntityFrameContext();//1-way
        private static Product product = new Product();
        public static void SelectAllProduct()
        {
            using (var db =new EntityFrameContext())//2-way
            {
                var result = db.Product.ToList();
                foreach (var item in result)
                {
                    Console.WriteLine("-----------------------------------------------");
                    Console.WriteLine("Product ID: " + product.ProductId + " | Name: " + product.ProductName + " | Category: " + product.ProductCategory + " | Price: " + product.ProductPrice + " | Quentity: " + product.ProductQty);
                    Console.WriteLine("-----------------------------------------------");
                }
            }
        }
        private static Product GetProduct()
        {
            Console.WriteLine("Please Enter the Product Name:");
            product.ProductName = Console.ReadLine();
            Console.WriteLine("Please Enter the Product Category:");
            product.ProductCategory = Console.ReadLine();
            Console.WriteLine("Please Enter the Product Price:");
            product.ProductPrice = (float)Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please Enter the Product Quentity:");
            product.ProductQty = Convert.ToInt32(Console.ReadLine());
            return product;
        }
        public static void InsertData()
        {
            using (var db = new EntityFrameContext())
            {
                product = GetProduct();
                db.Product.Add(product);
                db.SaveChanges();
                Console.WriteLine("Product Added");
            }
        }
        public static void AddProducts()
        {
            using (var db = new EntityFrameContext())
            {
                int choice = 0;
                do
                {
                    try
                    {
                        InsertData();
                        Console.WriteLine("Do You wise to add Another Product?? if yes enter any number other than 0.To Exit enter 0.");
                        choice = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException formatException)
                    {
                        Console.WriteLine("Not a Correct input");
                    }
                } while (choice != 0);
            }
        }
        public static void DeleteProduct()
        {
            using (var db = new EntityFrameContext())
            {
                Console.WriteLine("Please Enter the Product id to be deleted");
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    product = GetProductById(id);
                    if (product != null)
                    {
                        //db.Product.Remove(product);
                        db.Entry(product).State = EntityState.Deleted;
                        db.SaveChanges();
                        Console.WriteLine("Product Deleted Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Such Product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops Something went Wrong.Please try Again");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        public static void PrintProduct()
        {
            using (var db = new EntityFrameContext())
            {
                Console.WriteLine("Please Enter the Product id to be Print");
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    product = GetProductById(id);
                    if (product != null)
                    {
                        Console.WriteLine("-----------------------------------------------");
                        Console.WriteLine("Product ID: " + product.ProductId + " | Name: " + product.ProductName + " | Category: " + product.ProductCategory + " | Price: " + product.ProductPrice + " | Quentity: " + product.ProductQty);
                        Console.WriteLine("-----------------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("No Such Product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops Something went Wrong.Please try Again");
                    Console.WriteLine(ex.Message);
                }
            }
        }
        private static Product GetProductById(int id)
        {
            using (var dbc=new EntityFrameContext())
            {
                try
                {
                    product = dbc.Product.Find(id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            return product;
        }
        public static void UpdateProduct()
        {
            using (var db = new EntityFrameContext())
            {
                Console.WriteLine("Please Enter the Product id to be Update");
                try
                {
                    int id = Convert.ToInt32(Console.ReadLine());
                    product = GetProductById(id);
                    if (product != null)
                    {
                        Console.WriteLine("Please Enter New Product Price: ");
                        product.ProductPrice = (float)Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Please Enter New Product Quentity: ");
                        product.ProductQty = Convert.ToInt32(Console.ReadLine());
                        //db.Product.Update(product);    --it check all the records
                        db.Entry(product).State = EntityState.Modified;    //it will only check the given data
                        db.SaveChanges();
                        Console.WriteLine("Product Update Successfully");
                    }
                    else
                    {
                        Console.WriteLine("No Such Product");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops Something went Wrong.Please try Again");
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
