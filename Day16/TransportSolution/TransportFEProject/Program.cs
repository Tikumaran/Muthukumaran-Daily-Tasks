using System;
using TransportBLLibrary;

namespace TransportFEProject
{
    class Program
    {
        EmployeeLogin login;
        EmployeeManagement management;
        EmployeeBL bl;
        public Program()
        {
            bl = new EmployeeBL();
            login = new EmployeeLogin(bl);
            management = new EmployeeManagement(bl);
        }
        void printMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("----Menu----");
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Login");
                Console.WriteLine("3. PrintAll Employees Details");
                Console.WriteLine("4. Sort and PrintAll");
                Console.WriteLine("5. Reset Password");
                Console.WriteLine("6. Update Employee Details");
                Console.WriteLine("7. Exit the Application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        login.RegisterEmployee();
                        break;
                    case 2:
                        login.UserLogin();
                        break;
                    case 3:
                        management.PrintAllEmployee();
                        break;
                    case 4:
                        management.PrintEmployeesSortedByID();
                        break;
                    case 5:
                        management.ResetPAssword();
                        break;
                    case 6:
                        management.UpdateEmployees();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;
                }
            } while (choice!=7);
        }
        static void Main(string[] args)
        {
            new Program().printMenu();
        }
    }
}
