using HW8.Models;
using System.Linq;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home
        /// HttpGet to retrieve the View for the home welcome page
        /// </summary>
        /// <returns>The View object for Home/Index</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: Booty
        /// HttpGet to retrieve the view for the Pirates' Booty page
        /// </summary>
        /// <returns>The View object for Home/Booty</returns>
        public ActionResult Booty()
        {
            return View();
        }

        /// <summary>
        /// Gets the total booty haul ammount for each pirate sorted in descending order,
        /// place them in a JsonResult and send that data back to the calling Ajax function
        /// </summary>
        /// <returns>A Json object with each pirate and their total booty haul</returns>
        public JsonResult GetBooty()
        {
            // Array to hold an html string for each pirate and their booty
            string[] pirateBooty = null;

            using (PirateUnionContext db = new PirateUnionContext())
            {
                // Select each pirate's ID and the sum of their booty sorted in descending order
                var pb = db.Crews.GroupBy(c => c.PirateID).Select(p => new { Pirate = p.Key, TotalBooty = p.Sum(b => b.Booty) }).OrderByDescending(bp => bp.TotalBooty).ToList();

                pirateBooty = new string[pb.Count];

                // Create an html string for each pirate and their booty from the above LINQ query
                for (int i = 0; i < pirateBooty.Length; ++i)
                {
                    pirateBooty[i] = $"<tr><td>{db.Pirates.Find(pb[i].Pirate).FullName}</td><td>${pb[i].TotalBooty}</td></tr>";
                }
            }

            // Put the array of html strings in an ojbect for Json formatting
            var data = new
            {
                arr = pirateBooty
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}