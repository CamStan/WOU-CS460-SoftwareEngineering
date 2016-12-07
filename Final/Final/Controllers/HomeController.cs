using Final.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final.Controllers
{
    public class HomeController : Controller
    {
        private ArtContext db = new ArtContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Genres.OrderBy(g => g.Name).ToList());
        }

        public JsonResult GetGenre(int genre)
        {
            var pas = db.Genres.Find(genre).Classifications.ToList().Select(a => new { Piece = a.ArtWorkID, Art = a.ArtWork.ArtistID }).ToList();

            string[] pieceArtist = new string[pas.Count()];

            for (int i = 0; i < pieceArtist.Length; ++i)
            {
                pieceArtist[i] = $"<tr><td>{db.ArtWorks.Find(pas[i].Piece).Title}</td><td>{db.Artists.Find(pas[i].Art).FullName}</td></tr>";
            }

            var data = new
            {
                arr = pieceArtist
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}