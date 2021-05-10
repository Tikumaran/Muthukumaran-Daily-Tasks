using System;
using System.Collections.Generic;
using System.Text;

namespace TrainingtasksProject
{
    public class CowAndBull
    {
        List<String> words = new List<String>();
        List<String> TakeDatafromPlayer1(List<String> words)
        {
            int val = 0;
            Console.WriteLine("Please Enter a number of words to Guess:");
            try
            {
                val = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Player 1 Guess Words:");
                for (int i = 0; i < val; i++)
                {
                    words.Add(Console.ReadLine());
                }                    
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return words;
        }
        public void CowandBull()
        {
            TakeDatafromPlayer1(words);
            Console.WriteLine("--------Player-2-Ready-to-Play-----");
            for (int i = 0; i < words.Count; i++)
            {
                Console.WriteLine("Enter the Guess Word:");
                string GuessWord = Console.ReadLine();
                string guess = words[i];
                int cow = 0, bulls = 0;
                if (guess.Length == GuessWord.Length)
                {
                    for (i = 0; i < guess.Length; i++)
                    {
                        if (guess[i] == GuessWord[i])
                        {
                            cow += 1;
                        }
                        else
                        {
                            for (int j = 0; j < guess.Length; j++)
                            {
                                if (guess[i] == GuessWord[j] && i != j)
                                {
                                    bulls += 1;
                                }
                            }
                        }
                        Console.WriteLine("Cows=>" + cow + " Bulls=>" + bulls);
                    }

                    if (cow == guess.Length)
                    {
                        Console.WriteLine("Congratulations You Won the Game");
                    }
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine("Please Enter " + guess.Length + " letter of Word");
                    Console.WriteLine("");
                }
            }
        }

    }
}
