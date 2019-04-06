using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryWeb.Lib
{
    public class Message
    {
        public bool Status { get; set; }
        public string Msg { get; set; }
    }
}