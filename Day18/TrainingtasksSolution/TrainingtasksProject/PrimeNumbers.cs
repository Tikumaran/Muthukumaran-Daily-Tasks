using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class PrimeNumbers
    {
        public void PrintPrimeNumbers()
        {
            int Max_Number = 0, Min_Number = 0, Number = 0, flag = 0;
            Console.WriteLine("Please Enter the Minimum Number:");
            Min_Number = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Please Enter the Maximum Number:");
            Max_Number = Int32.Parse(Console.ReadLine());
            if (Max_Number > Min_Number)
            {
                for (Number = Min_Number; Number <= Max_Number; Number++)
                {
                    flag = 0;

                    for (int range = 2; range <= Number / 2; range++)
                    {
                        if (Number % range == 0)
                        {
                            flag++;
                            break;
                        }
                    }

                    if (flag == 0 && Number != 1)
                        Console.WriteLine("{0} ", Number);
                }
            }
            else
            {
                Console.WriteLine("Invalid Entry");
            }
        }
    }
}
