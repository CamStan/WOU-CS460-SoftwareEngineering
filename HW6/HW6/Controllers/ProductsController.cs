﻿using HW6.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace HW6.Controllers
{
    public class ProductsController : Controller
    {
        private AdventureWorksContext db = new AdventureWorksContext();

        // GET: Products
        public ActionResult Index(int? id)
        {
            var cat = db.ProductCategories;
            if (id != null) // validate id
            {
                ViewBag.ID = id;
            }

            return View(cat);
        }

        public ActionResult Products(int? id/*, int? page*/)
        {
            var products = db.ProductSubcategories.Find(id).Products.ToList();
           // ViewBag.NumberOfProducts = products.Count;
           // int pageSize = 6;
            //int pageNumber = page ?? 1;
           // var productsPaged = products.Skip(pageSize * (pageNumber-1)).Take(pageSize);
           // look at Bootstrap pagination
            return View(products);
        }

        public ActionResult ProductImage(int? id, bool? thumbnail)
        {
            //validate id
            // create case for bool
            var image = db.ProductProductPhotoes.Where(p => p.ProductID == (int)id).FirstOrDefault().ProductPhoto.ThumbNailPhoto;
            return File(image, "image/gif");
        }

    }
}