using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class ArtistController : Controller
    {

        private ArtContext db = new ArtContext();

        // GET: Artist
        public ActionResult Index()
        {
            return View(db.Artists.OrderBy(a => a.FirstName).ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = db.Artists.Find(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            ViewBag.NumOfArt = artist.ArtWorks.Count();

            return View(artist);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Artist artist)
        {
            if (ModelState.IsValid)
            {
                db.Artists.Add(artist);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(artist);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = db.Artists.Find(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            ViewBag.FN = artist.FullName;

            return View(artist);
        }

        [HttpPost]
        public ActionResult Edit(Artist newArtist)
        {
            int nameLength = newArtist.FirstName.Length + newArtist.LastName.Length;

            if (ModelState.IsValid && nameLength < 50)
            {
                var oldArtist = db.Artists.Find(newArtist.ID);
                UpdateModel(oldArtist);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = oldArtist.ID });
            }

            if (nameLength > 50)
            {
                ViewBag.Error = 1;
                ViewBag.ErrorMessage = "Artist full name cannot be longer than 50 characters";
            }

            return View(newArtist);
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var artist = db.Artists.Find(id);

            if (artist == null)
            {
                return HttpNotFound();
            }

            return View(artist);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            Artist artist = db.Artists.Find(id);
            db.Artists.Remove(artist);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}