using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW6.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: Products
        public ActionResult Index(int? id)
        {
            //var categories = db.ProductCategories.ToList();
            //var cat = db.ProductCategories.Where(p => p.ProductCategoryID == 1).ToList();
            // var sc = cat[0].ProductSubcategories.ToList()[0];
            //var prod = sc.Products;

            //ViewBag.Categories = db.ProductCategories.Select(p => p.Name ).ToList();
            //ViewBag.SubcategoryList = new SelectList(new string[] { });

            var cat = db.ProductCategories;
            if (id != null)
            {
                //ViewBag.Hello = "hello world";
                //ViewBag.Subcategories = db.ProductSubcategories.Where(p => p.ProductCategoryID == id).ToList();
                ViewBag.ID = id;
            }

            return View(cat);
        }

        public ActionResult Products(int? id)
        {
            var products = db.ProductSubcategories.Find(id).Products.ToList();
            var p = products.First();
            var pic = p.ProductProductPhotoes;
            return View(products);
        }
      
    }
}