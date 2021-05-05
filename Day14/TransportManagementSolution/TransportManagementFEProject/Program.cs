using System;
using TransportManagementBLLibrary;

namespace TransportManagementFEProject
{
    class Program
    {
        EmployeeRepo repo;
        EmployeeLogin login;
        EmployeeDetails get;
        public Program()
        {
            repo = new EmployeeRepo();
            login = new EmployeeLogin(repo);
            get = new EmployeeDetails(repo);
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1.Login");
                Console.WriteLine("2.Register");
                Console.WriteLine("3.Print The Employees Details");
                Console.WriteLine("4.Update The Employee");
                Console.WriteLine("5.Print The Employees Details By ID");
                Console.WriteLine("6.Delete The Employee");
                Console.WriteLine("7.Exit");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        login.Login();
                        break;
                    case 2:
                        login.Register();
                        break;
                    case 3:
                        get.GetAll();
                        break;
                    case 4:
                        get.UpdateEmployee();
                        break;
                    case 5:
                        get.GetEmployee();
                        break;
                    case 6:
                        get.DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice!=7);
            

        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            new Program().PrintMenu();
        }
    }
}
