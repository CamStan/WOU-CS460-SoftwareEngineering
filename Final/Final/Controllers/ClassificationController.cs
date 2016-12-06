using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class ClassificationController : Controller
    {

        private ArtContext db = new ArtContext();

        // GET: Classification
        public ActionResult Index()
        {
            return View(db.Classifications.ToList());
        }
    }
}