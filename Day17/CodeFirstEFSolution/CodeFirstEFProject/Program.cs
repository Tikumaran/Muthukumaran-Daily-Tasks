using System;

namespace CodeFirstEFProject
{
    class Program : ProductManagement
    {
       private static void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Add List of Product");
                Console.WriteLine("3. PrintAll Product");
                Console.WriteLine("4. Print Product By ID");
                Console.WriteLine("5. Update Product Details");
                Console.WriteLine("6. Delete Product");
                Console.WriteLine("7. Exit Application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertData();
                        break;
                    case 2:
                        AddProducts();
                        break;
                    case 3:
                        SelectAllProduct();
                        break;
                    case 4:
                        PrintProduct();
                        break;
                    case 5:
                        UpdateProduct();
                        break;
                    case 6:
                        DeleteProduct();
                        break;
                    default:
                        break;
                }

            } while (choice != 7);
        }
        static void Main(string[] args)
        {
            PrintMenu();

        }
    }
}
