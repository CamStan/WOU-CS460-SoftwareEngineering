using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class ShipsController : Controller
    {
        // GET: Ships
        public ActionResult Index()
        {
            using (PirateUnionContext db = new PirateUnionContext())
                return View(db.Ships.ToList());
        }
    }
}