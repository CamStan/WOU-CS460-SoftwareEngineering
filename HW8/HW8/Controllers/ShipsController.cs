using HW8.Models;
using System.Linq;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ShipsController : Controller
    {
        /// <summary>
        /// GET: Ships
        /// HttpGet to retrieve the View for Pirate Ships listed in 
        /// alphabetical order
        /// </summary>
        /// <returns>The View object for Ships/Index</returns>
        public ActionResult Index()
        {
            using (PirateUnionContext db = new PirateUnionContext())
                return View(db.Ships.OrderBy(s => s.Name).ToList());
        }
    }
}