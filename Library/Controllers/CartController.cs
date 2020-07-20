using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;

using Library.Models;


namespace Library.Controllers
{
    public class CartController : Controller
    {
        private Context db = new Context();

        // GET: Carts
        public ActionResult Index()
        {
            var carts = db.Carts.Include(c => c.Book);
            return View(carts.ToList());
        }

        public ActionResult Lend(int id)
        {
            BookModel bookModel = new BookModel();
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item { Book = bookModel.findById(id), Quantity = 1 });
                Session["cart"] = cart;
                Session["cartSize"] = cart.Count();
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExist(id);
                if (index != -1)
                    cart[index].Quantity++;
                else
                    cart.Add(new Item { Book = bookModel.findById(id), Quantity = 1 });
                Session["cart"] = cart;
                Session["cartSize"] = cart.Count();


            }
            return RedirectToAction("Index", "Cart");
        }

        private int isExist(int id)
        {

            List<Item> cart = (List<Item>)Session["cart"];
            Session["cartSize"] = cart.Count();
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Book.BookID.Equals(id))
                    return i;
            return -1;
        }
        public ActionResult UpdateCart(FormCollection form)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            string[] quantities = form.GetValues("quantity");

            for (int i = 0; i < cart.Count; i++)
            {
                cart[i].Quantity = Convert.ToInt32(quantities[i]);
            }
            Session["cart"] = cart;
            Session["cartSize"] = cart.Count();
            return RedirectToAction("Index");
        }

        // GET: Carts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

       /* // GET: Carts/Create
        public ActionResult Create()
        {
            ViewBag.BookID = new SelectList(db.books, "BookID", "Title");
            return View();
        }

        // POST: Carts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CartID,BookID,BorrowingDate")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Carts.Add(cart);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookID = new SelectList(db.books, "BookID", "Title", cart.BookID);
            return View(cart);
        }

        // GET: Carts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookID = new SelectList(db.books, "BookID", "Title", cart.BookID);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CartID,BookID,BorrowingDate")] Cart cart)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cart).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookID = new SelectList(db.books, "BookID", "Title", cart.BookID);
            return View(cart);
        }

        // GET: Carts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cart cart = db.Carts.Find(id);
            if (cart == null)
            {
                return HttpNotFound();
            }
            return View(cart);
        }

        // POST: Carts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cart cart = db.Carts.Find(id);
            db.Carts.Remove(cart);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        */
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
