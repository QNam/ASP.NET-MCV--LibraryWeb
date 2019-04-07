using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryWeb.Models;
using System.Web.Script.Serialization;
using LibraryWeb.Lib;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LibraryWeb.Controllers
{
    public class OrderController : BaseController
    {
        libraryEntities db = new libraryEntities();

        // GET: Order
        public ActionResult Index()
        {
            order order = new order();
            detail_order detail = new detail_order();
            book book = new book();

            ViewBag.orders = db.orders.ToList();

            JArray bookJson = new JArray();

            foreach(var item in db.books.ToList())
            {
                string json = @"{
                      value: '" + item.book_name + "'," +
                      "book_author: '" + item.author.author_name + "'," +
                      "book_price: '" + item.book_price + "'," +
                      "book_qty: ' " + item.book_qty + "'," +
                      "data: '" + item.book_id + "'}";

                bookJson.Add( JObject.Parse(json));
            }

            JArray userJson = new JArray();

            foreach (var item in db.users.ToList())
            {
                string json = @"{
                      value: '" + item.user_name + "'," +
                      "user_phone: '" + item.user_phone + "'," +
                      "user_addr: '" + item.user_addr + "'," +
                      "data: '" + item.user_id + "'}";

                userJson.Add(JObject.Parse(json));
            }

            ViewBag.bookJson = bookJson;
            ViewBag.userJson = userJson;

            return View();
        }


        public ActionResult AjaxGetAllBook()
        {
            book book = new book();

            var books = db.books.ToList();

            return Json(books, JsonRequestBehavior.AllowGet);
        }

    }
}