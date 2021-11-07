using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Controllers
{
    public class ProductController : Controller
    {
        mydbcontext db = new mydbcontext();
        int pageSize = 6;
        // GET: Product
        public ActionResult ProductPage(int? page)
        {
            int pageNum = (page ?? 1);
            var products = db.Products.ToList();

            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            ViewBag.productTitle = "Tất cả sản phẩm";

            return View(products.ToPagedList(pageNum, pageSize));
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}