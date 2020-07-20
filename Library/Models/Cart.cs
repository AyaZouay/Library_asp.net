using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;


namespace Library.Models
{
    public class Cart
    {
        public int CartID { get; set; }
        [DisplayName("Book")]
        public int BookID { get; set; }
        public virtual Book Book { get; set; }
        private DateTime _borrowingDate = DateTime.Now;
        public DateTime BorrowingDate { get { return _borrowingDate; } set { _borrowingDate = value; } }
    }
}