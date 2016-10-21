using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW4.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home
        /// </summary>
        /// <returns>The Index View Object that represents the result of the this action.</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: GetPage
        /// Gets the GetPage View which contains a form for users to input two words. This gets this
        /// page again, creating messages from the words input by the user. 
        /// </summary>
        /// <returns>The GetPage View Object that represents the result of this action.</returns>
        public ActionResult GetPage()
        {
            if (Request.QueryString.HasKeys()) // check if submit was clicked
            {
                // collect the two input values
                string w1 = Request.QueryString["word1"].Trim().ToLower();
                string w2 = Request.QueryString["word2"].Trim().ToLower();
                ViewBag.caseHeader = "Your words in:";

                // capatilize first letter of second word and create camel message
                w2 = w2.Equals("") ? w2 : w2.First().ToString().ToUpper() + w2.Substring(1);
                ViewBag.camelMessage = "Camel case: " + w1 + w2;

                // capatilize first letter of first word and create pascal message
                w1 = w1.Equals("") ? w1 : w1.First().ToString().ToUpper() + w1.Substring(1);
                ViewBag.pascalMessage = "Pascal case: " + w1 + w2;
            }

            return View();
        }

        /// <summary>
        /// GET: PostPage
        /// Gets the PostPage View which contains a form for users to input a username and password.
        /// </summary>
        /// <returns>The PostPage View Object that represents the result of this action. </returns>
        public ActionResult PostPage()
        {
            return View();
        }

        /// <summary>
        /// POST: PostPage
        /// Take the username and password input from the user, determines their lengths, and performs
        /// a few simple algebra operations on them.
        /// </summary>
        /// <param name="form"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult PostPage(FormCollection form)
        {
            // The length of each input
            int u = form["username"].Length;
            int p = form["password"].Length;

            // Array holding the output values
            string[] values = { "Sum: " + (u + p), "Difference: " + (u - p), "Product: " + (u * p) };

            // Messages and data to be sent back to the view
            ViewBag.message1 = "Username Length: " + u;
            ViewBag.message2 = " Password Length: " + p;
            ViewBag.data = values;
            return View();
        }

        public ActionResult LoanCalc()
        {
            return View();
        }
    }
}