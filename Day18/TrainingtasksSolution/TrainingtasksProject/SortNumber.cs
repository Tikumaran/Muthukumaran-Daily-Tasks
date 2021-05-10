using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class SortNumber
    {
        List<int> numbers = new List<int>();
        List<int> TakeNumbersfromUser(List<int> numbers)
        {
            int number = 0;
            Console.WriteLine("Please Enter a number. If Enter a Number 0 to Quit:");
            do
            {
                try
                {
                    number = Convert.ToInt32(Console.ReadLine());
                    numbers.Add(number);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            } while (number > 0);
            if (numbers.Count == 0)
                numbers = null;
            return numbers;
        }
        public void PrintSortedNumbers()
        {
            TakeNumbersfromUser(numbers);
            if (numbers != null)
            {
                Console.WriteLine("The Ascending Order Numbers are:");
                numbers.Sort();
                foreach (var item in numbers)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine("No Such Numbers");
            }
        }
    }
}
