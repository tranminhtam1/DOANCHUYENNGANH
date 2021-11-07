using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private mydbcontext db = new mydbcontext();

        // GET: Admin/Products
        private List<Product> Laygiaymoi(int count)
        {
            return db.Products.OrderByDescending(a => a.dateCreate).Take(count).ToList();
        }
        public ActionResult Index(int ?page)
        {
            //if (Session["userID"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //var productList = db.Products.ToList();
            //return View(productList);
            int pageSize=10;
            int pageNum = (page ?? 1);

            var giaymoi = Laygiaymoi(15);
            return View(giaymoi.ToPagedList(pageNum, pageSize));
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Admin/Products/Create
        public ActionResult Create()
        {
            ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName");
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "productID,categoryID,brandID,productName,productPrice,productDetail,image,dateCreate,amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName", product.brandID);
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", product.categoryID);
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName", product.brandID);
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", product.categoryID);
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "productID,categoryID,brandID,productName,productPrice,productDetail,image,dateCreate,amount")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName", product.brandID);
            ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", product.categoryID);
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
