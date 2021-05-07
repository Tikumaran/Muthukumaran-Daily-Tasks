using System;
using System.Collections.Generic;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEProject
{
    class EmployeeLogin
    {
        private ILogin<Employee> _login;

        public EmployeeLogin()
        {
                
        }
        public EmployeeLogin(ILogin<Employee> login)
        {
            _login = login;
        }
        public void UserLogin()
        {
            Console.WriteLine("Please Enter the EmployeeID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Password:");
            string password = Console.ReadLine();
            Employee employee = new Employee();
            employee.id = id;
            employee.Password = password;
            try
            {
                if (_login.Login(employee))
                {
                    Console.WriteLine("WelCome");
                }
                else
                {
                    Console.WriteLine("Incorrect Id and Password");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Login Exception");
                Console.WriteLine(e.Message);
            }
        }
        public void RegisterEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_login.Add(employee))
                    Console.WriteLine("Employee Registered");
                else
                    Console.WriteLine("Could not Registered ");
            }
            catch (Exception e)
            {
                Console.WriteLine("Could Not Add Employee");
                Console.WriteLine(e.Message);
            }
        }
    }
}
