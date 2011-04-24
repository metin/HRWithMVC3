using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CS631.HR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            //MySql.Data.MySqlClient.MySqlConnection c = new MySql.Data.MySqlClient.MySqlConnection();
            //c.ConnectionString = "Server=localhost;Database=test;Uid=ODBC;Pwd=;";
            //MySql.Data.MySqlClient.MySqlCommand cmd = c.CreateCommand();
            //cmd.CommandText = "Select * from tbl1";
            //c.Open();
            //cmd.ExecuteReader();
            //c.Close();


            return View();
        }


        public ActionResult About()
        {
            return View();
        }
    }
}
