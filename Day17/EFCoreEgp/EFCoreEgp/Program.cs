using EFCoreEgp.OrgModel;
using System;
using System.Linq;

namespace EFCoreEgp
{
    class Program
    {
        private static pubsContext db = new pubsContext();
        private static TblMovie movie = new TblMovie();
        private static void SelectAllMovies()
        {
            var result = db.TblMovies.ToList();
            foreach (var item in result)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("ID: " + item.Id + " Name: " + item.Name + " Duration: " + item.Duration);
                Console.WriteLine("-----------------------------------------------");
            }
        }
        private static TblMovie GetMovies()
        {
            Console.WriteLine("Please Enter the Movie Name:");
            movie.Name = Console.ReadLine();
            Console.WriteLine("Please Enter the Movie Duration:");
            movie.Duration = Convert.ToDouble(Console.ReadLine());
            return movie;
        }
        private static void InsertData()
        {
            movie = GetMovies();
            db.TblMovies.Add(movie);
            db.SaveChanges();
            Console.WriteLine("Movies Added");
        }
        private static void AddMovies()
        {
            int choice = 0;
            do
            {
                InsertData();
                Console.WriteLine("Do You wise to add Another Movie?? if yes enter any number other than 0.To Exit enter 0.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Not a Correct input");
                }
            } while (choice != 0);
        }
        private static void DeleteMovie()
        {
            Console.WriteLine("Please Enter the Movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movie = db.TblMovies.Find(id);
                if (movie != null)
                {
                    db.TblMovies.Remove(movie);
                    db.SaveChanges();
                    Console.WriteLine("Movie Deleted Successfully");
                }
                else
                {
                    Console.WriteLine("No Such Movies");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops Something went Wrong.Please try Again");
                Console.WriteLine(ex.Message);
            }
        }
        private static void UpdateMovie()
        {
            Console.WriteLine("Please Enter the Movie id to be Update");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movie = db.TblMovies.Find(id);
                if (movie != null)
                {
                    Console.WriteLine("Please Enter New Movie Name: ");
                    movie.Name = Console.ReadLine();
                    Console.WriteLine("Please Enter New Movie Duration: ");
                    movie.Duration = Convert.ToDouble(Console.ReadLine());
                    db.TblMovies.Update(movie);
                    db.SaveChanges();
                    Console.WriteLine("Movie Update Successfully");
                }
                else
                {
                    Console.WriteLine("No Such Movies");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops Something went Wrong.Please try Again");
                Console.WriteLine(ex.Message);
            }
        }

        static void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("1. Add movie");
                Console.WriteLine("2. Add List of Movies");
                Console.WriteLine("3. PrintAll Movies");
                Console.WriteLine("4. Update Movie Details");
                Console.WriteLine("5. Delete Movie");
                Console.WriteLine("6. Exit Application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        InsertData();
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        SelectAllMovies();
                        break;
                    case 4:
                        UpdateMovie();
                        break;
                    case 5:
                        DeleteMovie();
                        break;
                    default:
                        break;
                }

            } while (choice!=6);
        }
        static void Main(string[] args)
        {
            PrintMenu();

        }
    }
}
