using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Models;
namespace Library.Controllers
{
    public class HomeController : Controller
    {
        Context db = new Context();
        public ActionResult Index()
        {
            var news = db.News.ToList();
            return View(news.ToList().Take(2));
        }

        public ActionResult Counter()
        {
            ViewBag.Visitors = HttpContext.Application["Visitors"];

            return View();
        }
    }
}