using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Library.Models
{
    public class Item
    {
        public Book Book{ get; set; }
        public int Quantity { get; set; }
    }
}