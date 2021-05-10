using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class RepeatNumbers
    {
        List<int> numbers = new List<int>();
        List<int> TakeNumbersfromUser(List<int> numbers)
        {
            int number = 0;
            Console.WriteLine("Please Enter a number. If Enter a Negative number to Quit:");
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
            } while (number >= 0);
            if (numbers.Count == 0)
                numbers = null;
            return numbers;
        }
        public void PrintRepeatedNumbers()
        {
            TakeNumbersfromUser(numbers);
            if (numbers != null)
            {
                Console.WriteLine("The Repeadted Numbers are:");
                for (int i = 0; i < numbers.Count; i++)
                {
                    for (int j = i+1; j < numbers.Count; j++)
                    {
                        if(numbers[i]==numbers[j])
                            Console.WriteLine(numbers[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("No Such Numbers");
            }
           
        }
    }
}
