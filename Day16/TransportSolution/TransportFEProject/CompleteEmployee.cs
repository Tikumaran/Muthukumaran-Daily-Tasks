using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using TransportDALLibrary;

namespace TransportFEProject
{
    class CompleteEmployee : Employee, IComparable<Employee>
    {
        const string INITIAL_PASSWORD = "1334";

        public CompleteEmployee()
        {
                
        }
        public CompleteEmployee(Employee employee)
        {
            this.id = employee.id;
            this.Name = employee.Name;
            this.Password = employee.Password;
            this.VehicleNumber = employee.VehicleNumber;
            this.Phone = employee.Phone;
            this.Location = employee.Location;
        }
        public int CompareTo([AllowNull] Employee other)
        {
            return this.id.CompareTo(other.id);
        }
        public void TakeEmployeeData()
        {
            Console.WriteLine("Please Enter The Employee Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Please Enter The Employee Location:");
            Location = Console.ReadLine();
            Console.WriteLine("Please Enter The Employee Phone:");
            Phone = Console.ReadLine();
            Console.WriteLine("Please Enter The Vehicle Number:");
            VehicleNumber = Console.ReadLine();
            Password = INITIAL_PASSWORD;
        }
        public override string ToString()
        {
            String maskedpassword = GetMaskedPassword(Password);
            return "Id: " + id + " Name: " + Name + " Location: " + Location + " Phone: " + Phone + " Password: " + maskedpassword  + " Vehicle Number: " + VehicleNumber;
        }
        private string GetMaskedPassword(string Password)
        {
            string result = Password.Substring(0, 2);
            for (int i = 2; i < Password.Length; i++)
            {
                result += "*";
            }
            return result;
        }
    }
}
