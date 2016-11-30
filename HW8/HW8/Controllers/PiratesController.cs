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
        public ActionResult Index(int? page = 1)
        {
            var pirates = db.Pirates.OrderBy(p => p.FirstName).ToList();

            int pageSize = 3;
            double numOfPages = Math.Ceiling((double)pirates.Count / pageSize);

            int pageNumber = page ?? 0;
            if (page < 1 || page > numOfPages)
                return HttpNotFound();

            ViewBag.NumberOfPages = numOfPages;

            var pagedPirates = pirates.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return View(pagedPirates);
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

            ViewBag.NumOfShips = pirate.Crews.Count();
            ViewBag.TotalBooty = "$" + pirate.Crews.Sum(b => b.Booty);

            return View(pirate);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Pirate pirate)
        {
            if (ModelState.IsValid && pirate.ConscriptionDate < DateTime.Now)
            {
                db.Pirates.Add(pirate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            if (pirate.ConscriptionDate > DateTime.Now)
            {
                ViewBag.Error = 1;
                ViewBag.ErrorMessage = "Conscription Date cannot be in the future";
            }

            return View(pirate);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if (pirate == null)
            {
                return HttpNotFound();
            }

            return View(pirate);
        }

        [HttpPost]
        public ActionResult Edit(Pirate newPirate)
        {
            if (ModelState.IsValid && newPirate.ConscriptionDate < DateTime.Now)
            {
                var oldPirate = db.Pirates.Find(newPirate.ID);
                UpdateModel(oldPirate);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = oldPirate.ID } );
            }
            if (newPirate.ConscriptionDate > DateTime.Now)
            {
                ViewBag.Error = 1;
                ViewBag.ErrorMessage = "Conscription Date cannot be in the future";
            }

            return View(newPirate);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if (pirate == null)
            {
                return HttpNotFound();
            }

            return View(pirate);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Pirate pirate = db.Pirates.Find(id);
            db.Pirates.Remove(pirate);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}