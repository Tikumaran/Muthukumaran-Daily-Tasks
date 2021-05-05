using System;
using System.Diagnostics.CodeAnalysis;

namespace TransportManagementBLLibrary
{
    public class Employee : IComparable<Employee>
    {
        const String DEFAULT_PASSWORD = "1234";
        public int Id { get; set; }
        public String Name { get; set; }
        public String Location { get; set; }
        public String Phone { get; set; }
        public String Password { get; set; }
        public Employee()
        {
            Password = DEFAULT_PASSWORD;
        }
        public Employee(int id, string name, string location, string phone, string password)
        {
            Id = id;
            Name = name;
            Location = location;
            Phone = phone;
            Password = DEFAULT_PASSWORD;
        }
        public void GetEmployeeDetails()
        {
            Console.WriteLine("Please Enter the Employee Name:");
            Name = Console.ReadLine();
            Console.WriteLine("Please Enter the Employee Phone Number:");
            Phone = Console.ReadLine();
            Console.WriteLine("Please Enter the Employee Location:");
            Location = Console.ReadLine();
        }
        public override string ToString()
        {
            String maskedPassword = GetMaskedPassword(Password);
            return "Employee ID: "+Id+" | Employee Name: "+Name+" | Phone: "+Phone+" | Location: "+Location+" | Password: "+maskedPassword;
        }
        private String GetMaskedPassword(String password)
        {
            String result = password.Substring(0, 2);
            for (int i = 2; i < password.Length; i++)
            {
                result = result + "*";
            }
            return result;
        }
        public int CompareTo([AllowNull] Employee other)
        {
            return this.Location.CompareTo(other.Location);
        }
    }
    
}
