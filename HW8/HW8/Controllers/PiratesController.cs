using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}