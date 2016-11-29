using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{

    public class PiratesController : Controller
    {
        private PirateUnionContext db = new PirateUnionContext();

        // GET: Pirates
        public ActionResult Index()
        {
            return View(db.Pirates.OrderBy(p => p.FirstName).ToList());
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if(pirate == null)
            {
                return HttpNotFound();
            }

            ViewBag.TotalBooty = "$" + pirate.Crews.Sum(b => b.Booty);

            return View(pirate);
        }
    }
}