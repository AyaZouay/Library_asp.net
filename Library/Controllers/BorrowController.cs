using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using Library.Models;
using System.Data.Entity;
namespace Library.Controllers
{
    public class BorrowController: Controller 
    {

     //Get : Borrow
        private Context db = new Context();
        public ActionResult Index()
        {
            ViewBag.Message = "Categories";
            return View(db.Categories.Include("Books").ToList());
        }
        public ActionResult Category(string category)
        {

            var model = db.Categories.Include("Books")
            .Single(c => c.Name == category);


            return View(model);
        }

        public ActionResult AllBooks()
        {
            var model = db.books.Include(p => p.Category);
            return View(model);
        }
        public ActionResult ShowBooks(int BookID)
        {
            var book = db.books.Find(BookID);
            return View(book);
        }


    }
}
