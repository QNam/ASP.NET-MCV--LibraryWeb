using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Models;

namespace LibraryWeb.Controllers
{
    public class AuthorController : Controller
    {
        libraryEntities db = new libraryEntities();

        public ActionResult Index()
        {
            author author = new author();

            ViewBag.authors = db.authors.ToList();

            return View();
        }

    }
}