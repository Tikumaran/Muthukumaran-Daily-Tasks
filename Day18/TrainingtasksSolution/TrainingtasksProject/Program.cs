using System;

namespace TrainingtasksProject
{
    
    public class Program 
    {
        PrintAndDivisibleBy7 divisibleBy7;
        PrimeNumbers primeNumbers;
        RepeatNumbers repeatNumbers;
        SortNumber sortNumber;
        LoginStatus loginStatus;
        CowAndBull cowbull;
        CardValidation cardValidation;
        public Program()
        {
            divisibleBy7 = new PrintAndDivisibleBy7();
            primeNumbers = new PrimeNumbers();
            repeatNumbers = new RepeatNumbers();
            sortNumber = new SortNumber();
            loginStatus = new LoginStatus();
            cowbull = new CowAndBull();
            cardValidation = new CardValidation();
        }
        void PrintMenu()
        {
            int choice = 0;
            try
            {
                do
                {
                    Console.WriteLine("---------------------Menu--------------------");
                    Console.WriteLine("-----------Choose the Program Number-------------");
                    Console.WriteLine("1.Given Numbers to Print And Divisible by 7");
                    Console.WriteLine("2.Print The Prime Numbers");
                    Console.WriteLine("3.Print The Repeated Numbers");
                    Console.WriteLine("4.Print The Numbers in Ascending Orders");
                    Console.WriteLine("5.Login Status");
                    Console.WriteLine("6.COW and Bull Game");
                    Console.WriteLine("7.For Check Credit Card Validate or Not");
                    Console.WriteLine("8.Exit..");
                    Console.WriteLine("Enter The Option:");
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            divisibleBy7.PrintAndDivisible();
                            break;
                        case 2:
                            primeNumbers.PrintPrimeNumbers();
                            break;
                        case 3:
                            repeatNumbers.PrintRepeatedNumbers();
                            break;
                        case 4:
                            sortNumber.PrintSortedNumbers();
                            break;
                        case 5:
                            loginStatus.PrintLoginStatus();
                            break;
                        case 6:
                            cowbull.CowandBull();
                            break;
                        case 7:
                            cardValidation.CardValidations();
                            break;
                        case 8:
                            Console.WriteLine("Exiting.....");
                            break;
                        default:
                            Console.WriteLine("Invalid Choice");
                            break;
                    }
                } while (choice != 8);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
        }
        static void Main(string[] args)
        {
            new Program().PrintMenu();
        }
    }
}
