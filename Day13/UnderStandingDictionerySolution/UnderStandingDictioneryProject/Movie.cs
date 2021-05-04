using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace UnderStandingDictioneryProject
{
    public class Movie:IComparable<Movie>
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public double Duration { get; set; }
        public int CompareTo([AllowNull] Movie other)
        {
            return this.Duration.CompareTo(other.Duration);
        }
        public void TakeMovieDetails()
        {
            Console.WriteLine("Please Enter Movie Name:");
            Name = Console.ReadLine();
            double duration = 0;
            Console.WriteLine("Please Enter the Movie Duration:");
            while(!double.TryParse(Console.ReadLine(),out duration))
            {
                Console.WriteLine("Invalid entry for Duration.Please try Again");
            }
            Duration = duration;
        }
        public override string ToString()
        {
            return "MovieId: " + Id + "  Name :" + Name + "  Duration :" + Duration;
        }

    }
}
