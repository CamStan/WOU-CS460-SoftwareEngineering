using HW8.Models;
using HW8.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class CrewsController : Controller
    {
        private PirateUnionContext db = new PirateUnionContext();

        /// <summary>
        /// GET: Crews
        /// HttpGet to retrieve the View for Crews. This is the relationship
        /// between Pirates and Ships. This method displays each ship and its
        /// respective crews.
        /// </summary>
        /// <returns>The View object for Crews/Index</returns>
        public ActionResult Index()
        {
            var ships = db.Ships.OrderBy(s => s.Name).ToList();
            var crews = db.Crews.OrderBy(p => p.Pirate.FirstName).ToList();
            // Put ships and crews in a ViewModel in order to use both in View
            ShipCrews sc = new ShipCrews { TheShips = ships, TheCrews = crews };

            return View(sc);
        }
    }
}