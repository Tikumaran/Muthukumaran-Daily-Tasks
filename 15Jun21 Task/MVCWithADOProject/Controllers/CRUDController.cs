using MVCWithADOProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCWithADOProject.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home", dt);
        }
        public ActionResult Insert()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View("Create",dt);
        }
        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if(action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Title = frm["txtTitle"];
                string aname = frm["txtAname"];
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBook(Title, aname, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Delete(int bookId)
        {
            CRUDModel mdl = new CRUDModel();
            int rowIns = mdl.DeleteBook(bookId);
            return RedirectToAction("Index");
        }
        public ActionResult UpdateRecord(int bookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook(bookId);
            return View("Edit",dt);
        }
        public ActionResult Update(FormCollection frm,string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtAid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int bookId = Convert.ToInt32(frm["txtBid"]);
                int uprow = mdl.UpdateBook(bookId, title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult Authors()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayAuthor();
            return View(dt);
        }
        public ActionResult InsertAuthor()
        {
            return View("CreateAuthor");
        }
        public ActionResult InsertAuthorRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string Name = frm["txtName"];
                int rowIns = mdl.NewAuthor(Name);
                return RedirectToAction("Authors");
            }
            else
            {
                return RedirectToAction("Authors");
            }
        }
    }
}