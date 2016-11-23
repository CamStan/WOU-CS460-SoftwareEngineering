using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW7.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Stocks(string symbol)
        {
            //validate symbol
            string stockSymbol = symbol;
            var url = $"http://chart.finance.yahoo.com/table.csv?s={symbol}&a=9&b=22&c=2016&d=10&e=22&f=2016&g=d&ignore=.csv";
            // web request class
            WebRequest csvRequest = WebRequest.Create(url);
            WebResponse csvResponse = csvRequest.GetResponse();
            StreamReader reader = new StreamReader(csvResponse.GetResponseStream());
            string file = reader.ReadToEnd();
            reader.Close();
            var data = new { csv = file };
            //var data = new { message = symbol };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}