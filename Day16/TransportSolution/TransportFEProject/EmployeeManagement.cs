using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TransportBLLibrary;
using TransportDALLibrary;

namespace TransportFEProject
{
    class EmployeeManagement
    {
        private IRepo<Employee> _repo;
        public EmployeeManagement()
        {
                
        }
        public EmployeeManagement(IRepo<Employee> repo)
        {
            _repo = repo;
        }
        public void CreateEmployee()
        {
            CompleteEmployee employee = new CompleteEmployee();
            employee.TakeEmployeeData();
            try
            {
                if (_repo.Add(employee))
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
        public List<Employee> GetAllEmployees()
        {
            List<Employee> employees = _repo.GetAll().ToList();
            return employees;
        }
        public List<CompleteEmployee> PrintEmployees()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));
            }
            return employees;
        }
        public void PrintAllEmployee()
        {
            var employees = PrintEmployees();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public List<CompleteEmployee> SortEmployees()
        {
            List<CompleteEmployee> employees = new List<CompleteEmployee>();
            foreach (var item in GetAllEmployees())
            {
                employees.Add(new CompleteEmployee(item));
            }
            return employees;
        }
        public void PrintEmployeesSortedByID()
        {
            var employees = SortEmployees();
            employees.Sort();
            foreach (Employee employee in employees)
            {
                Console.WriteLine(employee);
            }
        }
        public void ResetPAssword()
        {
            Console.WriteLine("Please Enter the Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Employee Old Password:");
            string password = Console.ReadLine();
            Employee employee = GetAllEmployees().Find(e => e.id == id && e.Password == password);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("Please Enter New Password:");
                    var newpassword = Console.ReadLine();
                    Console.WriteLine("Please Enter Confirm Password:");
                    var cfmpassword = Console.ReadLine();
                    if (newpassword == cfmpassword)
                    {
                        employee.Password = newpassword;
                        if (_repo.Update(employee))
                            Console.WriteLine("Password Updated");
                        else
                            Console.WriteLine("Please Try Again");
                    }
                    else
                        Console.WriteLine("Password mismatch");
                }
                else
                {
                    Console.WriteLine("Incorrect UserName And Password");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Could Not Update Password");
                Console.WriteLine(exception.Message);
            }
        }

        public void UpdateEmployees()
        {
            Console.WriteLine("Please Enter the Employee ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = GetAllEmployees().Find(e => e.id == id);
            try
            {
                if (employee != null)
                {
                    Console.WriteLine("Please Enter New Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please Enter New Location:");
                    string location = Console.ReadLine();
                    Console.WriteLine("Please Enter New Phone.No:");
                    string phone = Console.ReadLine();
                    employee.Name = name;
                    employee.Location = location;
                    employee.Phone = phone;
                    if (_repo.UpdateEmployee(employee))
                        Console.WriteLine("Employee Details Updated");
                    else
                        Console.WriteLine("Please Try Again");
                }
                else
                {
                    Console.WriteLine("No Such Employee.");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Could Not Update the Details");
                Console.WriteLine(exception.Message);
            }
        }
    }
}
