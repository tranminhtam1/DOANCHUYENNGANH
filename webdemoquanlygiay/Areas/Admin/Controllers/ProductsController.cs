using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
        public ActionResult Index(int? page)
        {
            if (Session["admin"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            //if (Session["userID"] == null)
            //{
            //    return RedirectToAction("Login", "Account");
            //}
            //var productList = db.Products.ToList();
            //return View(productList);

            //int pageSize=10;
            //int pageNum = (page ?? 1);

            //var giaymoi = Laygiaymoi(15);
            //return View(giaymoi.ToPagedList(pageNum, pageSize));
            var productList = db.Products.ToList();
            return View(productList);
        }

        // GET: Admin/Products/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            //Product product = db.Products.Find(id);
            //if (product == null)
            //{
            //    return HttpNotFound();
            //}
            //return View(product);
            if (id == null || Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Product pro = db.Products.Find(id);
            return View(pro);
        }

        // GET: Admin/Products/Create
        //public ActionResult Create()
        //{
        //    ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName");
        //    ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName");
        //    return View();
        //}

        //// POST: Admin/Products/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "productID,categoryID,brandID,productName,productPrice,productDetail,image,dateCreate,amount")] Product product)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Products.Add(product);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    ViewBag.brandID = new SelectList(db.Brands, "brandID", "brandName", product.brandID);
        //    ViewBag.categoryID = new SelectList(db.Categories, "categoryID", "categoryName", product.categoryID);
        //    return View(product);
        //}
        public ActionResult Create()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult createProduct(Product productInfo, HttpPostedFileBase ImageUpload)
        {
            productInfo.dateCreate = DateTime.Now;
            if (ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName += extension;
                productInfo.image = "~/Public/images/sanpham/" + fileName;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/sanpham"), fileName));
                db.Products.Add(productInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                productInfo.image = "~/Public/images/sanpham/none.png";
                db.Products.Add(productInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        // GET: Admin/Products/Edit/5
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            Product prod = db.Products.Find(id);
            ViewBag.Category = db.Categories.ToList();
            ViewBag.Brand = db.Brands.ToList();
            return View(prod);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(FormCollection frm)
        {
            var editedProd = db.Products.Find(Int32.Parse(frm["productID"]));
            editedProd.productName = frm["productName"];
            editedProd.categoryID = Int32.Parse(frm["categoryID"]);
            editedProd.brandID = Int32.Parse(frm["brandID"]);
            editedProd.productPrice = Int32.Parse(frm["productPrice"]);
            editedProd.amount = Int32.Parse(frm["amount"]);
            editedProd.productDetail = frm["productDetail"];
            editedProd.dateCreate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");

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
        public ActionResult uploadImage(FormCollection frm, HttpPostedFileBase ImageUpload)
        {
            var prod = db.Products.Find(Int32.Parse(frm["productID"]));
            if (ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName += extension;
                prod.image = "~/Public/images/sanpham/" + fileName; ;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/sanpham"), fileName));

                db.SaveChanges();

                return RedirectToAction("Edit", "Products", new { id = Int32.Parse(frm["productID"]) });
            }
            else
            {
                prod.image = "~/Public/images/sanpham/none.png";
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
    }
}   
