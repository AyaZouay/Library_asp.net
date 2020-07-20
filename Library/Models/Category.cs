using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}