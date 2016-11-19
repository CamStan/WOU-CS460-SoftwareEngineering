using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            var cat = db.ProductCategories;
            if (id != null && db.ProductCategories.Find(id) != null) // validate id
            {
                ViewBag.ID = id;
            }

            return View(cat);
        }

        public ActionResult Products(int? id/*, int? page*/)
        {
            if (id == null || db.ProductSubcategories.Find(id) == null)
                return RedirectToAction("Index");
            var products = db.ProductSubcategories.Find(id).Products.ToList();
           // ViewBag.NumberOfProducts = products.Count;
           // int pageSize = 6;
            //int pageNumber = page ?? 1;
           // var productsPaged = products.Skip(pageSize * (pageNumber-1)).Take(pageSize);
           // look at Bootstrap pagination
            return View(products);
        }

        public ActionResult Product(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            ViewBag.NumOfReviews = product.ProductReviews.Count;
            ViewBag.Rating = ViewBag.NumOfReviews == 0 ? "N/A" : product.ProductReviews.Average(p => p.Rating).ToString() + "/5";

            var sizeUnit = product.SizeUnitMeasureCode;
            ViewBag.SizeUnit = sizeUnit == null ? "N/A" : product.SizeUnitMeasureCode.ToLower();

            var weightUnit = product.WeightUnitMeasureCode;
            ViewBag.WeightUnit = weightUnit == null ? "N/A" : product.WeightUnitMeasureCode.ToLower();

            return View(product);
        }

        public ActionResult ProductImage(int? id, bool? thumbnail)
        {
            //validate id
            var image = (thumbnail ?? false) ?
                db.ProductProductPhotoes.Where(p => p.ProductID == (int)id).FirstOrDefault().ProductPhoto.ThumbNailPhoto :
                db.ProductProductPhotoes.Where(p => p.ProductID == (int)id).FirstOrDefault().ProductPhoto.LargePhoto;
            
            return File(image, "image/gif");
        }

        [HttpGet]
        public ActionResult Review(int? id)
        {
            int pid = id ?? -1;
            if (id == -1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var product = db.Products.Find(id);

            if (product == null)
                return HttpNotFound();

            ProductReview review = db.ProductReviews.Create();
            review.ProductID = pid;
            review.Product = product;
            review.ReviewDate = review.ModifiedDate = DateTime.Now;

            return View(review);
        }

        [HttpPost]
        public ActionResult Review(ProductReview review)
        {
            if(ModelState.IsValid)
            {
                db.ProductReviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Product", new { id = review.ProductID });
            }
            review.Product = db.Products.Find(review.ProductID);
            return View(review);
        }

    }
}