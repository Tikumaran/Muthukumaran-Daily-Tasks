using System;
using System.Collections.Generic;
using System.Text;
using TransportManagementBLLibrary;

namespace TransportManagementFEProject
{
    class EmployeeDetails
    {
        IRepo<Employee> repo;
        public EmployeeDetails() { }
        public EmployeeDetails(IRepo<Employee> repo)
        {
            this.repo = repo;
        }
        public void AddEmployee()
        {
            Employee employee = new Employee();
            employee.GetEmployeeDetails();
            repo.Add(employee);
        }
        public void GetEmployee()
        {
            Console.WriteLine("Please Enter Employee Id to Print Details:");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = repo.Get(id);
            if (employee == null)
                Console.WriteLine("No Such Employee");
            else
                PrintEmployee(employee);
        }
        public void GetAll()
        {
            var employees = repo.GetAll();
            if (employees != null)
            {
                foreach (var item in employees)
                {
                    PrintEmployee(item);
                }
            }
            else
            {
                Console.WriteLine("No More Employees");
            }
            
        }
        public void DeleteEmployee()
        {
            Console.WriteLine("Please enter the Employee Id to Delete");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee = repo.Get(id);
            if (employee == null)
            {
                 Console.WriteLine("Cannot Delete.No Such Employee");
            }
            else
            {
                 repo.Delete(id);
                 Console.WriteLine("Deleted The Employee");
            }
        }
        public void PrintEmployee(Employee employe)
        {
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(employe);
            Console.WriteLine("----------------------------------------------------------------------------------------------------------------");
        }
        public void UpdateEmployee()
        {
            Console.WriteLine("Please Enter the Employee Id for Updation");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee employee=null;
            employee= repo.Get(id);
            if (employee != null)
            {
                String name;
                String location;
                Console.WriteLine("What do you want to Update Name or Location or Both");
                String choice = Console.ReadLine();
                switch (choice)
                {
                    case "name":
                        Console.WriteLine("Please Enter the New Name:");
                        name = Console.ReadLine();
                        employee.Name = name;
                        repo.Update(id, employee);
                        Console.WriteLine("Name Updated");
                        break;
                    case "location":
                        Console.WriteLine("Please Enter the New Location");
                        location = Console.ReadLine();
                        employee.Location = location;
                        repo.Update(id, employee);
                        Console.WriteLine("Location Updated");
                        break;
                    case "both":
                        Console.WriteLine("Please Enter the New Name:");
                        name = Console.ReadLine();
                        employee.Name = name;
                        repo.Update(id, employee);
                        Console.WriteLine("Please Enter the New Location");
                        location = Console.ReadLine();
                        employee.Location = location;
                        repo.Update(id, employee);
                        Console.WriteLine("Name And Location Updated");
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No Such Employee");
            }
        }
    }
}
