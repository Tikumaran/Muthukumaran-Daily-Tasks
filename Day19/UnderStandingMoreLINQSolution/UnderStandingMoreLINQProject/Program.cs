using System;
using System.Linq;

namespace UnderStandingMoreLINQProject
{
    class Program
    {
        int[] feedbackScore = { 90, 76, 45, 22, 60, 65, 75, 15, 85 };
        //IQueryable<int> numbers;
        /// <summary>
        /// Feedback below 60 is low
        /// </summary>
        void PrintLowFeedBackCount()
        {
            //var count = from n in feedbackScore where n < 60 select n;
            var count = feedbackScore.Where(score => score < 60).Count();
            Console.WriteLine("The Number of feedback that are less than 60 is "+count);
        }
        void PrintfeedBackInAscendingOrder()
        {
            var sortedFeedback = feedbackScore.OrderBy(score => score);
            Console.WriteLine("Printing Sorted FeedBacks");
            foreach (var item in sortedFeedback)
            {

            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
