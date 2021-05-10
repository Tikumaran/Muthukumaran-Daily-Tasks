using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class PrintAndDivisibleBy7
    {
        List<int> numbers = new List<int>();
        public void GetData()
        {
            int value;
            Console.WriteLine("Please Enter the Any Positive 10 Numbers:");
            for (int i = 0; i < 10; i++)
            {
                value = Convert.ToInt32(Console.ReadLine());
                if (value > 0)
                {
                    numbers.Add(value);
                }
                else
                {
                    Console.WriteLine("Incorrect Value");
                    break;
                }
            }
            numbers.Sort();
        }
        public void PrintAndDivisible()
        {
            GetData();
            Console.WriteLine("The Numbers Divisibleby 7 are:");
            foreach (var item in numbers)
            {
                if(item%7==0)
                    Console.WriteLine(item);
            }
        }
    }
}
