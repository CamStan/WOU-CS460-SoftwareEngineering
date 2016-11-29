using HW8.Models;
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
            return View(db.Crews.OrderBy(s => s.Ship.Name).ThenBy(p => p.Pirate.FirstName).ToList());
        }
    }
}