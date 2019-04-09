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
        public const int MINIMUM_RENT = 5000;
        public const int DEPOSIT_RATIO = 50;
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
                int deposit = (int)item.book_price / DEPOSIT_RATIO;
                if(deposit < MINIMUM_RENT)
                {
                    deposit = MINIMUM_RENT;
                }
                string json = @"{
                      value: '" + item.book_name + "'," +
                      "book_author: '" + item.author.author_name + "'," +
                      "book_price: '" + item.book_price + "'," +
                      "book_qty: ' " + item.book_qty + "'," +
                      "book_deposit: ' " + deposit + "'," +
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



        public int calcBookDeposit(int price)
        {
            int deposit = price / DEPOSIT_RATIO;
            if (deposit < MINIMUM_RENT)
            {
                deposit = MINIMUM_RENT;
            }

            return deposit;
        }


        public string Store()
        {
            user UserModel = new user();
            order OrderModel = new order();
            detail_order DetailOrderModel = new detail_order();

            string orderUserPhone = Request["orderUserPhone"];
            string orderUserName = Request["orderUserName"];
            string orderUserAddr = Request["orderUserAddr"];
            string Books = Request["Books"];

            bool userExists = db.users.Any(user => user.user_phone.Equals(orderUserPhone));

            if(!userExists)
            {
                UserModel.user_name = orderUserName;
                UserModel.user_phone = orderUserPhone;
                UserModel.user_addr = orderUserAddr;

                db.users.Add(UserModel);
                db.SaveChanges();
                OrderModel.user_id = UserModel.user_id;
            } else
            {
                var getUser = db.users.Where(user => user.user_phone == orderUserPhone).FirstOrDefault();
                OrderModel.user_id = getUser.user_id;
            }


            OrderModel.order_from = DateTime.ParseExact(Request["orderFrom"], "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);
            OrderModel.order_to = DateTime.ParseExact(Request["orderTo"], "yyyy-MM-dd",
                                       System.Globalization.CultureInfo.InvariantCulture);



            OrderBook bookOrderObj = new OrderBook();
            var bookList = JsonConvert.DeserializeObject<List<OrderBook>>(Books);

            int total = 0;
            foreach (var item in bookList)
            {
                var getBook = db.books.Where(book => book.book_id == item.id).FirstOrDefault();
                int deposit = calcBookDeposit((int)getBook.book_price);

                total += deposit * item.qty;
            }

            OrderModel.order_deposit = total;
            db.orders.Add(OrderModel);
            db.SaveChanges();

            foreach (var item in bookList)
            {
                var getBook = db.books.Where(book => book.book_id == item.id).FirstOrDefault();

                DetailOrderModel.book_deposit = calcBookDeposit( (int)getBook.book_price);
                DetailOrderModel.book_id = item.id;
                DetailOrderModel.order_qty = item.qty;
                DetailOrderModel.order_id = OrderModel.order_id;

                db.detail_order.Add(DetailOrderModel);
                db.SaveChanges();
            }


            return Request["orderFrom"];
            //return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}