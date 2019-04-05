using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Models;
namespace LibraryWeb.Controllers
{
    public class HomeController : Controller
    {
        libraryEntities db = new libraryEntities();
        public ActionResult Index()
        {
            ViewBag.data = db.authors.ToList();

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}