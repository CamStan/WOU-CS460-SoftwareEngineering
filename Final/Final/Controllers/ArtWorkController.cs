using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class ArtWorkController : Controller
    {

        private ArtContext db = new ArtContext();

        // GET: ArtWork
        public ActionResult Index()
        {
            return View(db.ArtWorks.ToList());
        }
    }
}