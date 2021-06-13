using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnd_BookManagementProject
{
    class Program
    {
        private BookAndAuthorManage manage;
        private bool result;
        public Program()
        {
            manage = new BookAndAuthorManage();
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1.  Register a New Author: ");
                Console.WriteLine("2.  Add a Book: ");
                Console.WriteLine("3.  Update The Author Details ");
                Console.WriteLine("4.  Delete The Author Details ");
                Console.WriteLine("5.  Update The Book Details ");
                Console.WriteLine("6.  Delete The Book Details ");
                Console.WriteLine("7.  Print Books by Author ");
                Console.WriteLine("8.  Print all Books ");
                Console.WriteLine("9.  Print all Authors ");
                Console.WriteLine("10. Print Book By ID ");
                Console.WriteLine("11. Print Author By ID ");
                Console.WriteLine("12. Exit The application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        result = manage.InsertingAuthor();
                        if(result == true) { 
                            Console.WriteLine("Registered Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 2:
                        result = manage.InsertingBook();
                        if (result == true) { 
                            Console.WriteLine("Added Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 3:
                        result = manage.UpdatingAuthor();
                        if (result == true) { 
                            Console.WriteLine("Updated Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 4:
                        result = manage.DeletingAuthor();
                        if (result == true) { 
                            Console.WriteLine("Deleted Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 5:
                        result = manage.UpdatingBook();
                        if (result == true) {
                            Console.WriteLine("Updated Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 6:
                        result=manage.DeletingBook();
                        if (result == true) {
                            Console.WriteLine("Deleted Sucessfully");
                        }
                        else
                        {
                            Console.WriteLine("InComplete Try Again");
                            break;
                        }
                        break;
                    case 7:
                        manage.PrintBookByAuthor();
                        break;
                    case 8:
                        manage.PrintBooks();
                        break;
                    case 9:
                        manage.PrintAuthors();
                        break;
                    case 10:
                        manage.PrintBookByID();
                        break;
                    case 11:
                        manage.PrintAuthorByID();
                        break;
                    case 12:
                        Console.WriteLine("Good Byeeeeeeeeeeee");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 12);
        }
        static void Main(string[] args)
        {
            Program obj = new Program();
            obj.PrintMenu();
        }
    }
}
