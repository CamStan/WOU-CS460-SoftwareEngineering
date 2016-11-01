using HW5.DAL;
using HW5.Models;
using System.Linq;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestController : Controller
    {
        private RequestContext db = new RequestContext();


        /// <summary>
        /// GET: Request/Index
        /// Displays all of the current change of major requests.
        /// </summary>
        /// <returns>The View object for Request/Index</returns>
        public ActionResult Index()
        {
            return View(db.Requests.ToList());
        }

        /// <summary>
        /// GET: Request/Create
        /// Gets the create form page for creating a new change of major request
        /// </summary>
        /// <returns>The View object for Request/Create</returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Request/Create
        /// Validates and Posts the new request object input by the user.
        /// </summary>
        /// <param name="request">The new Request object created by user input</param>
        /// <returns>If successful, a redirect view object to Request/Index, otherwise 
        /// a view object for Request/Create with previous inputs still populated</returns>
        [HttpPost]
        public ActionResult Create(Request request)
        {
            if(ModelState.IsValid)
            {
                db.Requests.Add(request);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}