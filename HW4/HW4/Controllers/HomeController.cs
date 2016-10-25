using System;
using System.Linq;
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
        /// <returns>The PostPage View Object that represents the result of this action.</returns>
        public ActionResult PostPage()
        {
            return View();
        }

        /// <summary>
        /// POST: PostPage
        /// Take the username and password input from the user, determines their lengths, and performs
        /// a few simple algebra operations on them.
        /// </summary>
        /// <param name="form">The collection of form data from the PostPage View</param>
        /// <returns>The PostPage View Object that represents the result of this action.</returns>
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

        /// <summary>
        /// GET: LoanCalc
        /// Gets the LoanCalc View which contains a form for users to input values
        /// to determine monthly payments on a loan.
        /// </summary>
        /// <returns>The LoanCalc View Object that represents the result of this action.</returns>
        public ActionResult LoanCalc()
        {
            return View();
        }

        /// <summary>
        /// POST: LoanCalc
        /// Takes the three values input by the user and calculates the monthly payment and sum of
        /// payments and returns that information to the view.
        /// </summary>
        /// <param name="principal">The desired amount for the loan.</param>
        /// <param name="interest">The annual interest rate of the loan.</param>
        /// <param name="term">The number of years payments will be made.</param>
        /// <returns>The LoanCalc View Object that represents the result of this action.</returns>
        [HttpPost]
        public ActionResult LoanCalc(int? principal, double? interest, int? term)
        {
            // Assign the input values to temp variables or give the value of -1 if null
            int p = principal ?? -1;
            double i = interest ?? -1.0;
            int t = term ?? -1;
            // If any of the values were null, send an error message to the view
            if ((p == -1) | (i == -1.0) | (t == -1))
            {
                ViewBag.Error = "Please enter a value in all fields";
                return View();
            }

            // Calculate the monthly payment
            double monthly = CalculateMonthly(p, i, t);

            // Add the calculated values to the ViewBag
            ViewBag.Sum = Math.Round(monthly * (t * 12), 2);
            ViewBag.Monthly = Math.Round(monthly, 2);

            return View();
        }

        /// <summary>
        /// Calculate the monthly payment based on the values input by the user.
        /// </summary>
        /// <param name="p">The desired amount for the loan.</param>
        /// <param name="i">The annual interest rate of the loan.</param>
        /// <param name="t">The number of years payments will be made.</param>
        /// <returns>The monthly payment.</returns>
        private double CalculateMonthly(int p, double i, int t)
        {
            double monthlyInterest = (i / 100) / 12;
            double payments = t * 12;

            return p * (monthlyInterest / (1 - Math.Pow((1 + monthlyInterest), -payments)));
        }
    }
}