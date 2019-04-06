using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LibraryWeb.Controllers
{
    public class BaseController : Controller
    {
        public void SetTempData(string msg, string type)
        {
            TempData["Message"] = msg;
            TempData["Type"]    = type;

        }
    }
}