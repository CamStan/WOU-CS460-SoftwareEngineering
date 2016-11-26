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
        /// <summary>
        /// GET: Home
        /// Gets the View for the Home page of this application
        /// </summary>
        /// <returns>The View object for Home/Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Gets the historical data .csv for the last thirty days for the desired stock symbol
        /// from Yahoo Finance and an appropriate error message, if needed, and puts them in a Json
        /// object to send back to the calling AJAX method.
        /// </summary>
        /// <param name="symbol">The desired stock symbol to send to Yahoo Finance</param>
        /// <returns>A Json object with the Yahoo Finance .csv file, stock symbol, and error message</returns>
        public JsonResult Stocks(string symbol)
        {
            // Generate the appropriate dates to match Yahoo Finance's query string
            var today = DateTime.Today;
            var day = today.Day == 31 ? 30 : today.Day;
            var month = today.Month == 1 ? 12 : today.Month - 1;
            var smonth = month == 1 ? 12 : month - 1;
            var year = month == 12 ? today.Year - 1 : today.Year;
            var syear = smonth == 12 ? today.Year - 1 : today.Year;
            // The url to download the appropriate .csv from Yahoo Finance
            var url = $"http://chart.finance.yahoo.com/table.csv?s={symbol}&a={smonth}&b={day}&c={syear}&d={month}&e={day}&f={year}&g=d&ignore=.csv";

            // Create and validate a WebRequest using the above url
            var csvRequest = (HttpWebRequest)WebRequest.Create(url);
            try
            {
                using (var csvResponse = csvRequest.GetResponse() as HttpWebResponse)
                {
                    if (csvRequest.HaveResponse && csvResponse != null)
                    {
                        // WebRequest was successful and valid
                        using (var reader = new StreamReader(csvResponse.GetResponseStream()))
                        {
                            string file = reader.ReadToEnd();
                            reader.Close();

                            // Create Json object to send back to AJAX call
                            var data = new
                            {
                                csv = file,
                                title = symbol.ToUpper(),
                                error = 0
                            };
                            // Log the successful stock request
                            LogStockRequest(data.title);
                            return Json(data, JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        // Log the stock request
                        LogStockRequest(symbol);
                        // WebRequest was not successful
                        var data = new { error = "Invalid Stock Symbol" };
                        return Json(data, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (WebException wex)
            {
                // Log the stock request
                LogStockRequest(symbol);
                // Stock symbol was not valid
                var data = new { error = "Invalid Stock Symbol" };
                return Json(data, JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// GET: RequestLog
        /// Gets the View for the RequestLog page to list log containing all previous stock symbol requsts
        /// </summary>
        /// <returns>The View object for Home/RequestLog</returns>
        public ActionResult RequestLog()
        {
            using (StockRequestContext db = new StockRequestContext())
                return View(db.StockRequests.ToList());
        }

        /// <summary>
        /// Creates and populates a new StockRequest object and places it in the database.
        /// </summary>
        /// <param name="symbol">The stock symbol to create the log for</param>
        private void LogStockRequest(string symbol)
        {
            using (StockRequestContext db = new StockRequestContext())
            {
                StockRequest request = db.StockRequests.Create();
                request.StockSymbol = symbol;
                request.Date = DateTime.Now;

                // If IP Address is localhost, change the format to full ip
                string ip = Request.UserHostAddress;
                request.IP_Address = ip.Equals("::1") ? "127.0.0.1" : ip;

                request.Browser = Request.Browser.Type;
                db.StockRequests.Add(request);
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Queries Aonaware Dictionary Service with the input word to find the appropriate defintion based
        /// on the context of this application. The word and its definition are placed in a Json Object and
        /// sent back to the AJAX method calling this method.
        /// </summary>
        /// <param name="key">The word to find the definition for</param>
        /// <returns>A JSON ojbect containing the key word and its appropriate definition</returns>
        public JsonResult Definition(string key)
        {
            // Repalce any spaces with a '+' symbol
            string searchKey = key.ToLower().Replace(' ', '+');
            var url = $"http://services.aonaware.com/DictService/Default.aspx?action=define&dict=*&query={searchKey}";

            // Create a webrequest using the above url and serchKey
            WebRequest def = WebRequest.Create(url);
            WebResponse defResponse = def.GetResponse();
            StreamReader reader = new StreamReader(defResponse.GetResponseStream());
            string file = reader.ReadToEnd();
            reader.Close();

            // Find the appropriate definition of the key for the context of this application
            string definition = GetDefinition(file, key);

            // Create ojbect to put in JSON format containing the word and its definition
            var data = new 
            {
                word = key,
                def = definition
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Filters out the appropriate definition of the desired key word from string of definitions
        /// that was received via a WebRequest. I realized I could have just stored these four
        /// definitions and sent them as necessary, but wanted to practice using WebRequests, JSON,
        /// and AJAX. This function is definitely not the most efficient. It is designed to find
        /// the appropirate definition for each word based on the specific layout of file/string of
        /// definitions for that word that was received via the WebRequest.
        /// </summary>
        /// <param name="file">The file/string to filter the appropriate definition from.</param>
        /// <param name="key">The word for find the definition for</param>
        /// <returns>A string containing the definition for the input key/word</returns>
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