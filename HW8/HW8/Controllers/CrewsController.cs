using HW8.Models;
using HW8.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class CrewsController : Controller
    {
        private PirateUnionContext db = new PirateUnionContext();

        // GET: Crews
        public ActionResult Index()
        {
            var ships = db.Ships.OrderBy(s => s.Name).ToList();
            var crews = db.Crews.OrderBy(p => p.Pirate.FirstName).ToList();
            ShipCrews sc = new ShipCrews { TheShips = ships, TheCrews = crews };

            return View(sc);
        }
    }
}