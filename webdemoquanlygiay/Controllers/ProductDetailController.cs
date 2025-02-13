﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        mydbcontext db = new mydbcontext();
        public ActionResult ProductDetailPage(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var selectedProduct = db.Products.Find(id);
            ViewBag.relativeProducts = getRelativeProducts(selectedProduct.categoryID);
            var request = HttpContext.Request.Url.AbsoluteUri;
            ViewBag.Url = request;
            return View(selectedProduct);
        }
        private List<Product> getRelativeProducts(int categoryID)
        {
            return db.Products.Where(p => p.categoryID == categoryID).Take(4).ToList();
        }
    }
}