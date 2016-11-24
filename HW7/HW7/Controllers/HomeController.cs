﻿using System;
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
            var url = $"http://chart.finance.yahoo.com/table.csv?s={symbol}&a=9&b=22&c=2016&d=10&e=22&f=2016&g=d&ignore=.csv";
            var csvRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (var csvResponse = csvRequest.GetResponse() as HttpWebResponse)
                {
                    if (csvRequest.HaveResponse && csvResponse != null)
                    {
                        using (var reader = new StreamReader(csvResponse.GetResponseStream()))
                        {
                            string file = reader.ReadToEnd();
                            reader.Close();

                            var data = new { csv = file,
                                title = symbol.ToUpper(),
                                error = 0
                            };
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        var data = new { error = "Invalid Stock Symbol" };
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (WebException wex)
            {
                var data = new { error = "Invalid Stock Symbol" };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        //public JsonResult Symbols()
        //{
        //    var url = "http://oatsreportable.finra.org/OATSReportableSecurities-SOD.txt";

        //    WebRequest symRequest = WebRequest.Create(url);
        //    WebResponse symResponse = symRequest.GetResponse();
        //    StreamReader reader = new StreamReader(symResponse.GetResponseStream());
        //    string file = reader.ReadToEnd();
        //    reader.Close();

        //    var data = new { txt = file[1] };

        //    return Json(data, JsonRequestBehavior.AllowGet);
        //}
    }
}