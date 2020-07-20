using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class BookModel
    {
        private Context db = new Context();
        private List<Book> Books;
        public List<Book> findAll()
        {
            return db.books.ToList();
        }
        public Book findById(int id)
        {
            return db.books.Single(b => b.BookID.Equals(id));
        }
    }
}