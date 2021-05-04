using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UnderStandingDictioneryProject
{
    class ManageMovies
    {
        Dictionary<int, Movie> movies;
        public ManageMovies()
        {
            movies = new Dictionary<int, Movie>();
        }
        private int GenerateId()
        {
            if (movies.Count == 0)
            {
                return 1;
            }
            int id = movies[movies.Count-0].Id;
            id++;
            return id;
        }
        public Movie CreateMovie()
        {
            Movie movie = new Movie();
            movie.Id = GenerateId();
            movie.TakeMovieDetails();
            return movie;
        }
        public int GetMovieIndexById(int id)
        {
            bool result = movies.ContainsKey(id);
            if (result == true)
                return id;
            else
                return Convert.ToInt32(result);
        }
        public Movie UpdateMovieName(int id,String name)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if(idx != 0)
            {
                movies[idx].Name = name;
                movie = movies[idx];
            }
            return movie;
        }
        private void PrintMovieById()
        {
            Console.WriteLine("Please Enter the Movie id to be Print:");
            int id = Convert.ToInt32(Console.ReadLine());
            int idx= GetMovieIndexById(id);
            if (idx > 0)
                PrintMovie(movies[idx]);
            else
                Console.WriteLine("No Such Movie");
        }
        private void DeleteMovie()
        {
            Console.WriteLine("Please Enter the Movie id to be deleted");
            try
            {
                int id = Convert.ToInt32(Console.ReadLine());
                movies.Remove(GetMovieIndexById(id));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops Something went Wrong.Please try Again");
                Console.WriteLine(ex.Message);
            }
        }
        public Movie UpdateMovieDuration(int id,double duration)
        {
            Movie movie = null;
            int idx = GetMovieIndexById(id);
            if (idx != 0)
            {
                movies[idx].Duration = duration;
                movie = movies[idx];
            }
            return movie;
        }
        public void PrintMovieById(int id)
        {
            int idx = GetMovieIndexById(id);
            if (idx != 0)
                PrintMovie(movies[idx]);
            else
                Console.WriteLine("No Such Movies");
        }
        public void PrintAllMovies()
        {
            if (movies.Count == 0)
                Console.WriteLine("No Movies Present");
            else
                foreach (var item in movies.Keys)
                {
                    PrintMovie(movies[item]);
                }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                Movie movie = CreateMovie();
                movies.Add(movie.Id, movie);
                Console.WriteLine("Do You wise to add Another Movie?? if yes enter any number other than 0.To Exit enter 0.");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException formatException)
                {
                    Console.WriteLine("Not a Correct input");
                }
            } while (choice!=0);
        }
        public void SortMovies()
        {
            if (movies.Count != 0)
            {
                List<Movie> ids = movies.Values.ToList();
                ids.Sort();
                PrintAllMovies();
            }
            else
            {
                Console.WriteLine("No elements to be sorted");
            }
                
        }
        public void PrintMovie(Movie movie)
        {
            Console.WriteLine("-----------------------------------------------");
            Console.WriteLine(movie);
            Console.WriteLine("-----------------------------------------------");
        }
        void UpdateMovie()
        {
            Console.WriteLine("Please Enter the Movie Id for Updation");
            int id = Convert.ToInt32(Console.ReadLine());
            int ids = GetMovieIndexById(id);
            if ( ids!= 0)
            {
                Console.WriteLine("What do you want to Update Name or Duration or Both");
                String choice = Console.ReadLine();
                String name;
                double duration;
                switch (choice)
                {
                    case "name":
                        Console.WriteLine("Please enter the New Name:");
                        name = Console.ReadLine();
                        UpdateMovieName(id, name);
                        break;
                    case "duration":
                        Console.WriteLine("Please enter the New Duration");
                        while (!double.TryParse(Console.ReadLine(), out duration))
                        {
                            Console.WriteLine("Invalid entry for duration.please try again");
                        }
                        UpdateMovieDuration(id, duration);
                        break;
                    case "both":
                        Console.WriteLine("Please enter the New Name:");
                        name = Console.ReadLine();
                        UpdateMovieName(id, name);
                        Console.WriteLine("Please enter the New Duration");
                        while (!double.TryParse(Console.ReadLine(), out duration))
                        {
                            Console.WriteLine("Invalid entry for duration.please try again");
                        }
                        UpdateMovieDuration(id, duration);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("No Such Movie");
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a movie");
                Console.WriteLine("2. Add a list of movies");
                Console.WriteLine("3. Update the movie");
                Console.WriteLine("4. Delete the movie");
                Console.WriteLine("5. Print movie by ID");
                Console.WriteLine("6. Print all movies");
                Console.WriteLine("7. Sort movies");
                Console.WriteLine("8. Exit the application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Movie movie = CreateMovie();
                        movies.Add(movie.Id,movie);
                        break;
                    case 2:
                        AddMovies();
                        break;
                    case 3:
                        UpdateMovie();
                        break;
                    case 4:
                        DeleteMovie();
                        break;
                    case 5:
                        PrintMovieById();
                        break;
                    case 6:
                        PrintAllMovies();
                        break;
                    case 7:
                        SortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 8);
        }

        static void Main(string[] s)
        {
            new ManageMovies().PrintMenu();
        }
    }
}
