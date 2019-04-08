using LibraryWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Lib;

namespace LibraryWeb.Controllers
{
    public class CategoryController : BaseController
    {
        // GET: Category
        libraryEntities db = new libraryEntities();
        public ActionResult Index()
        {
            ViewBag.category = db.categories.ToList();
            return View();
        }
        [HttpPost]
        public string ajaxEditnameCategory()
        {
            int id = Convert.ToInt32(Request["pk"]);
            string name = Request["value"];

            category cate = new category();
            cate.cat_id = id;
            cate.cat_name = name;

            db.categories.AddOrUpdate(cate);

            db.SaveChanges();

            return "";
        }

        [HttpPost]
        public ActionResult GetOneCate()
        {
            int id = Convert.ToInt32(Request["cateId"]);
            category cate = new category();

            var data = db.categories.Find(id);
            cate.cat_id= data.cat_id;
            cate.cat_name = data.cat_name;

            return Json(cate, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Store()
        {
            bool update = true;
            category category = new category();
            int id = 0;

            //if (ModelState.IsValid)
            //{
            //    return RedirectToAction("Index","Home");
            //}

            //check xem có id ko nếu có thì là update nếu không thì là insert
            try
            {
                id = Convert.ToInt32(Request["cateId"]);
            }
            catch (Exception e)
            {
                update = false;
            }

            string name = Request["cateName"];

            //chuẩn bị câu lệnh
            if (update == true)
            {

                category.cat_id = id;
                category.cat_name = name;
                db.categories.AddOrUpdate(category);
            }
            else
            {
                category.cat_name = name;
                db.categories.Add(category);
            }

            //chạy lệnh
            try
            {
                db.SaveChanges();

                if (update == true)
                    SetTempData("Cập nhật danh mục thể loại thành công !", "success");
                else
                    SetTempData("Thêm danh mục thể loại thành công !", "success");
            }
            catch (Exception e)
            {
                if (update == true)
                    SetTempData("Cập nhật danh mục thể loại thất bại !", "error");
                else
                    SetTempData("Thêm danh mục thể loại thất bại !", "error");
            }

            return RedirectToAction("Index");
        }

        //public ActionResult AjaxRemoveCategory()
        //{
        //    category category = new category();
        //    book book = new book();
        //    Message mes = new Message();

        //    int id = Convert.ToInt32(Request["cateId"]);
        //    try
        //    {
        //        category.cat_id = id;
        //        // Update tất cả các sách có cat_id bị xóa về id 0 tức là cat_name = Unassign Category
        //        if (ModelState.IsValid)
        //        {
        //            var books = db.Set<book>().SingleOrDefault(o => o.category_id == id);
        //            books.category_id = 0;
        //            db.SaveChanges();
        //        }

        //        db.categories.Attach(category);
        //        db.categories.Remove(category);
        //        //db.books.AddOrUpdate(n => book.category_id == id, new book() { });
        //        db.SaveChanges();
        //        mes.Status = true;
        //        mes.Msg = "Xóa danh mục thể loại thành công !";

        //        return Json(mes, JsonRequestBehavior.AllowGet);
        //    }
            //catch (Exception e)
            //{
            //    mes.Status = false;
            //    mes.Msg = "Xóa danh mục thể loại thất bại !";

            //    return Json(mes, JsonRequestBehavior.AllowGet);
            //}

        }
    }
//}