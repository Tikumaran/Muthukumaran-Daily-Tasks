using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorAnd_BookManagementProject
{
    public class BookAndAuthorManage
    {
        public SqlConnection con;
        public SqlCommand cmd;
        private bool result;
        public BookAndAuthorManage()
        {
            con = new SqlConnection("data source=DESKTOP-Q3S933H\\SQLEXPRESS;Integrated Security=true;database=BooksDb;");
            cmd = new SqlCommand();
        }
        public bool InsertingBook()
        {
            try
            {
                Console.WriteLine("Enter The Book Title:");
                string Book_Title = Console.ReadLine();
                Console.WriteLine("Enter The Author ID of the Book:");
                int Author_Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The Book Price:");
                int Price = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("sp_InsertBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Title", SqlDbType.NVarChar).Value = Book_Title;
                cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Author_Id;
                cmd.Parameters.AddWithValue("Price", SqlDbType.Money).Value = Price;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }
        }
        public bool UpdatingBook()
        {
            try
            {
                Console.WriteLine("Enter The Book ID Number:");
                int Book_Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Price Of the Book:");
                double Price = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("sp_UpdateBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Price", SqlDbType.Money).Value = Price;
                cmd.Parameters.AddWithValue("BookID", SqlDbType.Int).Value = Book_Id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }            
        }
        public bool DeletingBook()
        {
            try
            {
                Console.WriteLine("Enter The Book ID Number:");
                int Book_Id = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("sp_DeleteBook", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("BookID", SqlDbType.Int).Value = Book_Id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }            
        }
        public bool InsertingAuthor()
        {
            try
            {
                Console.WriteLine("Enter The Author_Name:");
                string Author_Name = Console.ReadLine();
                cmd = new SqlCommand("sp_InsertAuthor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = Author_Name;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }
        }
        public bool UpdatingAuthor()
        {
            try
            {
                Console.WriteLine("Enter The Author ID Wants to Update :");
                int Author_Id = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter The New Author Name :");
                string Author_Name = Console.ReadLine();
                cmd = new SqlCommand("sp_UpdateAuthor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Author_Id;
                cmd.Parameters.AddWithValue("AuthorName", SqlDbType.NVarChar).Value = Author_Name;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }
        }
        public bool DeletingAuthor()
        {
            try
            {
                Console.WriteLine("Enter The Author ID Number:");
                int Author_Id = Convert.ToInt32(Console.ReadLine());
                cmd = new SqlCommand("sp_DeleteAuthor", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Author_Id;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close(); 
                result = true;
                return result;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                result = false;
                return result;
            }
        }
        public void PrintBookByAuthor()
        {
            try
            {
                Console.WriteLine("Enter The Author ID Number:");
                int Author_Id = Convert.ToInt32(Console.ReadLine());
                cmd.Connection = con;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tbl_Books where AuthorID=@AuthorID";
                cmd.Parameters.AddWithValue("AuthorID", SqlDbType.Int).Value = Author_Id;
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Book ID: " + reader[0] + " | Book Title: " + reader[1] + " | Author ID: " + reader[2] + " | Book Price: " + reader[3]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
        }
        public void PrintBookByID()
        {
            try
            {
                Console.WriteLine("Enter The Book ID Number:");
                int Book_ID = Convert.ToInt32(Console.ReadLine());
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tbl_Books where BookID=@BookID";
                cmd.Parameters.AddWithValue("BookID", SqlDbType.Int).Value = Book_ID;
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Book ID: " + reader[0] + " | Book Title: " + reader[1] + " | Author ID: " + reader[2] + " | Book Price: " + reader[3]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintAuthorByID()
        {
            try
            {
                Console.WriteLine("Enter The Author ID Number:");
                int Author_ID = Convert.ToInt32(Console.ReadLine());
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tbl_author where AuthorID=@Author";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("Author", SqlDbType.Int).Value = Author_ID;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Author ID: " + reader[0] + " | Author Name: " + reader[1]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintBooks()
        {
            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tbl_Books";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Book ID: " + reader[0] + " | Book Title: " + reader[1] + " | Author ID: " + reader[2] + " | Book Price: " + reader[3]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void PrintAuthors()
        {
            try
            {
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from tbl_author";
                cmd.Connection = con;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("--------------------------------------------------------------------------------");
                    Console.WriteLine("Author ID: " + reader[0] + " | Author Name: " + reader[1]);
                    Console.WriteLine("--------------------------------------------------------------------------------");
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
