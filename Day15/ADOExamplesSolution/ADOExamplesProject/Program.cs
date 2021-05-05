using System;
using System.Data;
using System.Data.SqlClient;

namespace ADOExamplesProject
{
    class Program
    {
        String conString;
        SqlConnection con;
        SqlCommand cmd;
        public Program()
        {
            conString = @"server=DESKTOP-Q3S933H\SQLEXPRESS;Integrated security=true;Initial catalog=pubs";
            con = new SqlConnection(conString);
        }
        public void FetchAuthorsDetails()
        {
            String strcmd = "Select * from authors";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                SqlDataReader drAuthors = cmd.ExecuteReader();
                while (drAuthors.Read())
                {
                    Console.WriteLine("Authors ID: " + drAuthors[0]);
                    Console.WriteLine("Authors First_Name: " + drAuthors[2]);
                    Console.WriteLine("Authors Last_Name: " + drAuthors[1]);
                    Console.WriteLine("Authors Phone: " + drAuthors[3]);
                    Console.WriteLine("----------------------------------------");
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void FetchMoviesDetails()
        {
            String strcmd = "Select * from tblMovie";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Movie ID: " + drMovies[0] + " | Movie Name: " + drMovies[1] + " | Movie Duration: " + drMovies[2]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void FetchOneMoviesDetails()
        {
            String strcmd = "Select * from tblMovie where id=@mid";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                Console.WriteLine("Please Enter the Movie Id:");
                int id = Convert.ToInt32(Console.ReadLine());
                cmd.Parameters.Add("@mid", SqlDbType.Int);
                cmd.Parameters[0].Value = id;
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Movie ID: " + drMovies[0] + " | Movie Name: " + drMovies[1] + " | Movie Duration: " + drMovies[2]);
                    Console.WriteLine("--------------------------------------------------------------------------------");

                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void AddMovie()
        {
            Console.WriteLine("Please Enter the Movie Name:");
            String mName = Console.ReadLine();
            Console.WriteLine("Please Enter the Movie Duration:");
            double mDuration = double.Parse(Console.ReadLine());
            String StrCmd = "insert into tblMovie(name,duration)values(@mname,@mdur)";
            cmd = new SqlCommand(StrCmd, con);
            cmd.Parameters.AddWithValue("@mname", mName);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if(result>0)
                    Console.WriteLine("Movie Inserted");
                else
                    Console.WriteLine("No Can't Inserted");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void AddMovies()
        {
            int choice = 0;
            do
            {
                AddMovie();
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
        void UpdateMovie()
        {
            Console.WriteLine("Please Enter the Movie ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter the Movie Duration:");
            double mDuration = double.Parse(Console.ReadLine());
            String StrCmd = "update tblMovie set duration=@mdur where id=@mid";
            cmd = new SqlCommand(StrCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            cmd.Parameters.AddWithValue("@mdur", mDuration);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Updated");
                else
                    Console.WriteLine("No Can't Updated");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void DeleteMovie()
        {
            Console.WriteLine("Please Enter the Movie ID:");
            int id = Convert.ToInt32(Console.ReadLine());
            String StrCmd = "delete tblMovie where id=@mid";
            cmd = new SqlCommand(StrCmd, con);
            cmd.Parameters.AddWithValue("@mid", id);
            try
            {
                con.Open();
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                    Console.WriteLine("Movie Deleted");
                else
                    Console.WriteLine("No Can't Deleted Bcz No Such Movies.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                con.Close();
            }
        }
        public void FetchSortMovies()
        {
            String strcmd = "Select * from tblMovie order by duration";
            cmd = new SqlCommand(strcmd, con);
            try
            {
                con.Open();
                SqlDataReader drMovies = cmd.ExecuteReader();
                while (drMovies.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Movie ID: " + drMovies[0] +" | Movie Name: " + drMovies[1] + " | Movie Duration: " + drMovies[2]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
            }
            catch (SqlException exception)
            {
                Console.WriteLine(exception.Message);
            }
            finally
            {
                con.Close();
            }
        }
        void PrintMenu()
        {
            int choice = 0;
            do
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add a Movie");
                Console.WriteLine("2. Add a List of Movies");
                Console.WriteLine("3. Update The movie");
                Console.WriteLine("4. Delete The movie");
                Console.WriteLine("5. Print Movie by ID");
                Console.WriteLine("6. Print all Movies");
                Console.WriteLine("7. Sort The Movies");
                Console.WriteLine("8. Exit The application");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddMovie();
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
                        FetchOneMoviesDetails();
                        break;
                    case 6:
                        FetchMoviesDetails();
                        break;
                    case 7:
                        FetchSortMovies();
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            } while (choice != 8);
        }
        static void Main(string[] args)
        {
            Program ObjProgram = new Program();
            ObjProgram.PrintMenu();
        }
    }
}

