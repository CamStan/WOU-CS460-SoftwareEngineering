using System.Web.Mvc;

/// <summary>
/// Controllers for the home index landing page
/// </summary>
namespace HW6.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GET: Home
        /// HttpGet method for retrieving the View for the home page of HW6
        /// </summary>
        /// <returns>The View object for Home/Index</returns>
        public ActionResult Index()
        {
            return View();
        }
    }
}