using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class LoginStatus
    {
        public void PrintLoginStatus()
        {
            int count = 0;
            Console.WriteLine("----Login----");

            for (count = 0; count < 3; count++)
            {
                Console.WriteLine("UserName:");
                String User_Name = Console.ReadLine();
                Console.WriteLine("Password:");
                String Password = Console.ReadLine();
                if (User_Name == "Admin" && Password == "admin")
                {
                    Console.WriteLine("Welcome");
                    break;
                }
                else if (count != 2)
                {
                    Console.WriteLine("Incorrect UserName And/or Password");
                    Console.WriteLine("Try again");
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Incorrect UserName And/or Password");
                    Console.WriteLine("Sorry Your Account Was Locked....");
                    break;
                }
            }
        }
    }
}
