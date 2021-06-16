using DBDDListProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DBDDListProject.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            Movies mok = new Movies();
            DataTable dt = mok.DisplayMovie();
            return View("Home", dt);
        }
        public ActionResult Insert()
        {
            return View("Create");
        }
        public ActionResult InsertRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                Movies mok = new Movies();
                string Title = frm["txtMovie"];
                double duration = Convert.ToDouble(frm["txtDuration"]);
                int rowIns = mok.NewMovie(Title, duration);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Edit()
        {
            Movies mok = new Movies();
            mok.Movie = mok.PopulateMovies();
            return View(mok);
        }
        [HttpPost]
        public ActionResult Edit(Movies mok,string action)
        {
            mok.Movie = mok.PopulateMovies();
            var selectedItem = mok.Movie.Find(p => p.Value == mok.Movie_Id.ToString());//checking ID of Movie
            if (selectedItem != null && action=="Submit")
            {
                int uprow = mok.UpdateMovie(mok,selectedItem.Text);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}