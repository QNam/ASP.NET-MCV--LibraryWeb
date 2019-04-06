using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Models;
using LibraryWeb.Lib;

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

        [HttpPost]
        public string ajaxEditnameAuthor()
        {
            int id = Convert.ToInt32(Request["pk"]);
            string name = Request["value"];

            author author = new author();
            author.author_id = id;
            author.author_name = name;

            db.authors.AddOrUpdate(author);

            db.SaveChanges();

            return "";
        }

        [HttpPost]
        public ActionResult GetOneAuthor()
        {
            int id = Convert.ToInt32(Request["authorId"]);

            var data = db.authors.Find(id);
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Store()
        {
            bool flag = true;
            author author = new author();
            int id = 0;

            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}

            try
            {
                id = Convert.ToInt32(Request["authorId"]);
            }
            catch (Exception e)
            {
                flag = false;
            }

            string name = Request["authorName"];

            if(flag = true)
            {
                author.author_id    = id;
                author.author_name  = name;

                db.authors.Add(author);
            } else
            {
                author.author_name = name;

                db.authors.Add(author);
            }

            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AjaxRemoveAuthor()
        {
            author author = new author();
            Message mes = new Message();

            int id = Convert.ToInt32(Request["authorId"]);
            try
            {
                author.author_id = id;
                db.authors.Attach(author);
                db.authors.Remove(author);
                db.SaveChanges();

                mes.Status = true;
                mes.Msg = "Xóa tác giả thành công !";

                return Json(mes, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                mes.Status = true;
                mes.Msg = "Xóa tác giả thất bại !";

                return Json(mes, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}