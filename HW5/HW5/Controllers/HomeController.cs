using System.Web.Mvc;

namespace HW5.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home
        /// Gets the View for the home page of HW5
        /// </summary>
        /// <returns>The View object for Home/Index</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}