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
    public class AuthorController : BaseController
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
            author author = new author();

            var data = db.authors.Find(id);
            author.author_id    = data.author_id;
            author.author_name  = data.author_name;

            return Json(author, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Store()
        {
            bool update = true;
            author author = new author();
            int id = 0;

            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index","Home");
            //}

            //check xem có id ko nếu có thì là update nếu không thì là insert
            try
            {
                id = Convert.ToInt32(Request["authorId"]);
            }
            catch (Exception e)
            {
                update = false;
            }

            string name = Request["authorName"];

            //chuẩn bị câu lệnh
            if (update == true)
            {
                
                author.author_id    = id;
                author.author_name  = name;
                db.authors.AddOrUpdate(author);
            } else
            {
                author.author_name = name;
                db.authors.Add(author);
            }

            //chạy lệnh
            try
            {
                db.SaveChanges();

                if (update == true)
                    SetTempData("Cập nhật tác giả thành công !", "success");
                else
                    SetTempData("Thêm tác giả thành công !", "success");
            }
            catch (Exception e)
            {
                if (update == true)
                    SetTempData("Cập nhật tác giả thất bại !", "error");
                else
                    SetTempData("Thêm tác giả thất bại !", "error");
            }

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
                mes.Status = false;
                mes.Msg = "Xóa tác giả thất bại !";

                return Json(mes, JsonRequestBehavior.AllowGet);
            }
            
        }
    }
}