using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Library.Models

{
    public class Context:DbContext
    {
        public Context() : base("MyCS") { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Book> books { get; set; }

        public System.Data.Entity.DbSet<Library.Models.New> News { get; set; }

        public System.Data.Entity.DbSet<Library.Models.Cart> Carts { get; set; }

    }
}