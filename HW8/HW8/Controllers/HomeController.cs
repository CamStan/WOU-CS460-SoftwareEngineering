using HW8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW8.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Booty()
        {
            return View();
        }

        public JsonResult GetBooty()
        {
            string[] pirateBooty = null;

            using (PirateUnionContext db = new PirateUnionContext())
            {
                var pb = db.Crews.GroupBy(c => c.PirateID).Select(p => new { Pirate = p.Key, TotalBooty = p.Sum(b => b.Booty) }).OrderByDescending(bp => bp.TotalBooty).ToList();

                pirateBooty = new string[pb.Count];

                for (int i = 0; i < pirateBooty.Length; ++i)
                {
                    pirateBooty[i] = $"<tr><td>{db.Pirates.Find(pb[i].Pirate).FullName}</td><td>${pb[i].TotalBooty}</td></tr>";
                }
            }

            var data = new
            {
                arr = pirateBooty
            };

            return Json(data, JsonRequestBehavior.AllowGet);
        }
    }
}