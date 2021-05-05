using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementBLLibrary;

namespace TransportManagementFEProject
{
    class EmployeeLogin
    {
        ILogin<Employee> repo;
        public EmployeeLogin()
        {
            //repo = new EmployeeRepo();
        }
        public EmployeeLogin(ILogin<Employee> employeerepo)
        {
            this.repo = employeerepo;
        }
        public void Register()
        {
            Employee employee = new Employee();
            employee.GetEmployeeDetails();
            repo.Add(employee);
            Console.WriteLine("SuccessFully Register");
        }
        public void Login()
        {
            Employee employee = new Employee();
            Console.WriteLine("Please Enter the UserName:");
            employee.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Password:");
            employee.Password = Console.ReadLine();
            if (repo.Login(employee))
            {
                Console.WriteLine("Welcome");
            }
            else
            {
                Console.WriteLine("Invalid UserName and Password");
            }
        }
    }
}
