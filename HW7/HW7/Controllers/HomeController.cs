using HW7.DAL;
using HW7.Models;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
            var today = DateTime.Today;
            var day = today.Day == 31 ? 30 : today.Day;
            var month = today.Month == 1 ? 12 : today.Month - 1;
            var smonth = month == 1 ? 12 : month - 1;
            var year = month == 12 ? today.Year - 1 : today.Year;
            var syear = smonth == 12 ? today.Year - 1 : today.Year;
            var url = $"http://chart.finance.yahoo.com/table.csv?s={symbol}&a={smonth}&b={day}&c={syear}&d={month}&e={day}&f={year}&g=d&ignore=.csv";
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

                            var data = new
                            {
                                csv = file,
                                title = symbol.ToUpper(),
                                error = 0
                            };
                            LogStockRequest(data.title);
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        LogStockRequest(symbol);
                        var data = new { error = "Invalid Stock Symbol" };
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (WebException wex)
            {
                LogStockRequest(symbol);
                var data = new { error = "Invalid Stock Symbol" };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult RequestLog()
        {
            using (StockRequestContext db = new StockRequestContext())
                return View(db.StockRequests.ToList());
        }

        private void LogStockRequest(string symbol)
        {
            using (StockRequestContext db = new StockRequestContext())
            {
                StockRequest request = db.StockRequests.Create();
                request.StockSymbol = symbol;
                request.Date = DateTime.Now;
                string ip = Request.UserHostAddress;
                request.IP_Address = ip.Equals("::1") ? "127.0.0.1" : ip;
                request.Browser = Request.Browser.Type;
                db.StockRequests.Add(request);
                db.SaveChanges();
            }
        }

        public JsonResult Definition(string key)
        {
            string searchKey = key.ToLower().Replace(' ', '+');
            var url = $"http://services.aonaware.com/DictService/Default.aspx?action=define&dict=*&query={searchKey}";
            WebRequest def = WebRequest.Create(url);
            WebResponse defResponse = def.GetResponse();
            StreamReader reader = new StreamReader(defResponse.GetResponseStream());
            string file = reader.ReadToEnd();
            reader.Close();

            string definition = GetDefinition(file, key);

            var data = new 
            {
                word = key,
                def = definition
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        private string GetDefinition(string file, string key)
        {
            string[] sfile = file.Split('\n');
            string definition = null;
            bool found = false;
            if (key.Equals("Stock"))
            {
                foreach (string s in sfile)
                {
                    if (found && s.Trim().StartsWith("8."))
                        break;
                    if (found)
                        definition = definition + " " + Regex.Replace(s.Trim(), "<.*?>", "");
                    if (s.Trim().StartsWith("7."))
                    {
                        definition = s.Trim();
                        found = true;
                    }
                }
            }
            if (key.Equals("Bond"))
            {
                foreach (string s in sfile)
                {
                    if (found && s.Trim().StartsWith("7."))
                        break;
                    if (found)
                        definition = definition + " " + s.Trim();
                    if (s.Trim().StartsWith("6."))
                    {
                        definition = s.Trim();
                        found = true;
                    }
                }
            }
            if (key.Equals("Mutual Fund"))
            {
                foreach (string s in sfile)
                {
                    if (found)
                        definition = definition + " " + s.Trim().Split('[').First();
                    if (found && s.Trim().StartsWith(""))
                        break;
                    if (s.Trim().StartsWith("n :"))
                    {
                        definition = s.Trim().Split(':').Last();
                        found = true;
                    }
                }
            }
            if (key.Equals("Certificate of Deposit"))
            {
                foreach (string s in sfile)
                {
                    if (found && s.StartsWith(""))
                        break;
                    if (s.Trim().StartsWith("n :"))
                    {
                        definition = s.Trim().Split(':').Last();
                        found = true;
                    }
                }
            }
            return definition;
        }
    }
}