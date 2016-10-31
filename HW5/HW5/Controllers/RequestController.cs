using HW5.DAL;
using HW5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW5.Controllers
{
    public class RequestController : Controller
    {
        static private RequestCollection requests = new RequestCollection();
        //private RequestContext db = new RequestContext();

        // GET: Request
        public ActionResult Index()
        {
            return View(requests.theRequests);
            //return View(db.Requests.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Request request)
        {
            if(ModelState.IsValid)
            {
                requests.theRequests.Add(request);
                //db.Requests.Add(request);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(request);
        }
    }
}