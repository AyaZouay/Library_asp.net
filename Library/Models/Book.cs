using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    
    public class Book
    {
        public int BookID { get; set; }
        [DisplayName("Category")]
        public int CategoryId { get; set; } 
        public virtual Category Category { get; set; }
        [StringLength(40)]
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

    }
}