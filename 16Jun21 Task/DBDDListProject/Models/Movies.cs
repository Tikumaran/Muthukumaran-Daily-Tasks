using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBDDListProject.Models
{
    public class Movies
    {
        private SqlConnection con;
        private SqlCommand cmd;
        public Movies()
        {
            con = new SqlConnection(@"data source=DESKTOP-Q3S933H\SQLEXPRESS;Integrated Security=true;database=dbMovies;");
            cmd = new SqlCommand();
        }
        public List<SelectListItem> Movie { get; set; }
        public int? Movie_Id { get; set; }
        public double? Duration { get; set; }

        public DataTable DisplayMovie()
        {
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "select * from tbl_movies";
            DataTable dt = new DataTable();
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public int NewMovie(string Title, double duration)
        {
            cmd = new SqlCommand("Insert into tbl_movies values(@Title,@duration)", con);
            cmd.Parameters.AddWithValue("Title", SqlDbType.NVarChar).Value = Title;
            cmd.Parameters.AddWithValue("duration", SqlDbType.Float).Value = duration;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public int UpdateMovie(Movies movie,string MovieName)
        {
            cmd = new SqlCommand("update tbl_Movies set Movie_Name=@Movie,Duration=@duration where Movie_Id=@MovieID", con);
            cmd.Parameters.AddWithValue("Movie", SqlDbType.NVarChar).Value = MovieName;
            cmd.Parameters.AddWithValue("duration", SqlDbType.Float).Value = movie.Duration;
            cmd.Parameters.AddWithValue("MovieID", SqlDbType.Int).Value = movie.Movie_Id;
            con.Open();
            return cmd.ExecuteNonQuery();
            con.Close();
        }
        public List<SelectListItem> PopulateMovies()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string query = " SELECT Movie_Name, Movie_Id FROM tbl_Movies";
            using (cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                con.Open();
                using (SqlDataReader sdr = cmd.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        items.Add(new SelectListItem
                        {
                            Text = sdr["Movie_Name"].ToString(),
                            Value = sdr["Movie_Id"].ToString()
                        });
                    }
                }
                con.Close();
            }
            return items;
        }

    }
}