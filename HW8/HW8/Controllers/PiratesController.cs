using HW8.Models;
using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace HW8.Controllers
{

    public class PiratesController : Controller
    {
        private PirateUnionContext db = new PirateUnionContext();

        /// <summary>
        /// GET: Pirates
        /// HttpGet to retrieve the view for Pirates and display them in
        /// pages which 3 elements on each page
        /// </summary>
        /// <param name="page">The page number to retrieve</param>
        /// <returns>The View object for Pirates/Index with the elements for the indicated page</returns>
        public ActionResult Index(int? page = 1)
        {
            // Get the pirates sorted by first name
            var pirates = db.Pirates.OrderBy(p => p.FirstName).ToList();

            int pageSize = 3; // elements per page
            double numOfPages = Math.Ceiling((double)pirates.Count / pageSize); // number of pages needed

            int pageNumber = page ?? 0;
            if (page < 1 || page > numOfPages)
                return HttpNotFound(); // indicated page is out of bounds

            ViewBag.NumberOfPages = numOfPages;

            // Get the three pirates needed for the page indicated
            var pagedPirates = pirates.Skip(pageSize * (pageNumber - 1)).Take(pageSize);

            return View(pagedPirates);
        }

        /// <summary>
        /// GET: Pirates' Details
        /// HttpGet for retrieving the details view for the desired pirate
        /// </summary>
        /// <param name="id">The ID of the desired pirate</param>
        /// <returns>The View object for Pirates/Details/{id}</returns>
        public ActionResult Details(int? id)
        {
            if (id == null) // id not entered
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if (pirate == null) // pirate doesn't exist
            {
                return HttpNotFound();
            }

            // Send a pirate's ship count and total booty haul to the view
            ViewBag.NumOfShips = pirate.Crews.Count();
            ViewBag.TotalBooty = "$" + pirate.Crews.Sum(b => b.Booty);

            return View(pirate);
        }

        /// <summary>
        /// GET: Pirate Create
        /// Http get to retrieve the view for creating a new pirate
        /// </summary>
        /// <returns>The View object for Pirates/Create</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Pirate Create
        /// HttpPost to validate and create a new pirate
        /// </summary>
        /// <param name="pirate">The pirate to validate, create, and add to database</param>
        /// <returns>A redirect to Pirates/Index if successful or back to create page with validation errors</returns>
        [HttpPost]
        public ActionResult Create(Pirate pirate)
        {
            if (ModelState.IsValid && pirate.ConscriptionDate < DateTime.Now)
            {
                db.Pirates.Add(pirate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Check if the Conscription Date is in the future
            if (pirate.ConscriptionDate > DateTime.Now)
            {
                ViewBag.Error = 1;
                ViewBag.ErrorMessage = "Conscription Date cannot be in the future";
            }

            return View(pirate);
        }

        /// <summary>
        /// GET: Pirate Edit
        /// HttpGet for the view to Edit a pirate's details
        /// </summary>
        /// <param name="id">The ID of the pirate to edit</param>
        /// <returns>The View object for Pirates/Edit/{id}</returns>
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null) // id not entered
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if (pirate == null) // pirate doesn't exist
            {
                return HttpNotFound();
            }

            return View(pirate);
        }

        /// <summary>
        /// POST: Pirate Edit
        /// HttpPost to validate and update a Pirate's information
        /// </summary>
        /// <param name="newPirate">The pirate model to use for updating</param>
        /// <returns>A redirect back to the edited pirate'd details page if successful
        /// or back to edit page with validation errors</returns>
        [HttpPost]
        public ActionResult Edit(Pirate newPirate)
        {
            if (ModelState.IsValid && newPirate.ConscriptionDate < DateTime.Now)
            {
                var oldPirate = db.Pirates.Find(newPirate.ID);
                UpdateModel(oldPirate);
                db.SaveChanges();
                return RedirectToAction("Details", new { id = oldPirate.ID });
            }
            // Check if the Conscription Date is in the future
            if (newPirate.ConscriptionDate > DateTime.Now)
            {
                ViewBag.Error = 1;
                ViewBag.ErrorMessage = "Conscription Date cannot be in the future";
            }

            return View(newPirate);
        }

        /// <summary>
        /// GET: Pirate Delete
        /// HttpGet to retrieve the view for confirming whether or not the desired
        /// pirate should be deleted
        /// </summary>
        /// <param name="id">The ID of the pirate to be deleted</param>
        /// <returns>The View object for Pirates/Delete/{id}</returns>
        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null) // id not entered
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pirate = db.Pirates.Find(id);

            if (pirate == null) // pirate doesn't exist
            {
                return HttpNotFound();
            }

            return View(pirate);
        }

        /// <summary>
        /// POST: Pirate Delete
        /// HttpPost to delete the desired pirate
        /// </summary>
        /// <param name="id">The ID of the pirate to be deleted</param>
        /// <returns>A redirect to Pirates/Index</returns>
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