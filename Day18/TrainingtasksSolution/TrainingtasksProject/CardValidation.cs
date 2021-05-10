using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class CardValidation
    {
        public void CardValidations()
        {
            Console.WriteLine("Enter the card Number");
            string cardnum = Console.ReadLine();
            Console.WriteLine("Enter a Expiery Year");
            int Year = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Expiery Month");
            int Month = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter a Expiery Date");
            int Date = Convert.ToInt32(Console.ReadLine());
            DateTime dt = new DateTime(Year, Month, Date);
            Console.WriteLine("Enter the CVV on credit card");
            string SecureNo = Console.ReadLine();
            string RevrerseString = string.Empty;
            for (int i = cardnum.Length - 1; i >= 0; i--)
            {
                RevrerseString += cardnum[i];
            }
            Console.WriteLine(RevrerseString);
            int num, num1, sum = 0, num2 = 0, num3 = 0;
            for (int i = 0; i < RevrerseString.Length; i++)
            {
                char v = RevrerseString[i];
                num = (int)Char.GetNumericValue(v);
                if (i % 2 == 0)
                {
                    num1 = num * 2;
                    num3 += num1;
                }
                else
                {
                    num2 += num;
                }
                sum = num3 + num2;
            }
            int value = dt.CompareTo(DateTime.Today);
            if ((cardnum.Length == 16 || cardnum.Length == 15) && (value > 0) && (SecureNo.Length == 3) && (sum % 10 == 0))
            {
                Console.WriteLine("Congratulations Your Credit Card Is Valid");
            }
            else if ((cardnum.Length != 16 & cardnum.Length > 16) || (cardnum.Length != 15 & cardnum.Length < 15))
            {
                Console.WriteLine("Invalied Credit Card Number");
            }
            else if (SecureNo.Length != 3)
            {
                Console.WriteLine("Invalied CVV ");
            }
            else if (value < 0)
            {
                Console.WriteLine("Your card has been Expired");
            }
            else if (sum % 10 != 0)
            {
                Console.WriteLine("Incorrect Card Number");
            }
            else
            {
                Console.WriteLine("Details are Invalid");
            }
        }
    }
}
