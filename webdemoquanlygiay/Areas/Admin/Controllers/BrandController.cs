using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class BrandController : Controller
    {
        mydbcontext db = new mydbcontext();
        // GET: Admin/Brand
        public ActionResult listbrand()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var listcate = db.Brands.ToList();
            return View(listcate);
        }
        [HttpGet]
        public ActionResult insertbrand()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult insertbrand(Brand cat)
        {
            db.Brands.Add(cat);
            db.SaveChanges();
            return RedirectToAction("listbrand");
        }

        [HttpGet]
        public ActionResult editbrand(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Brands.Find(id));
        }

        [HttpPost]
        public ActionResult editbrand(Brand cate)
        {
            db.Entry(cate).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("listbrand");
        }

        public ActionResult removebrand(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            try
            {
                var va = db.Brands.Find(id);
                db.Categories.Remove(va);
                db.SaveChanges();
                return RedirectToAction("listbrand");
            }
            catch (Exception)
            {
                ViewBag.Alert = "<div class='alert alert-danger' role='alert'>Không thể xóa loại sản phẩm này</div>";
                return View("listbrand", db.Brands.ToList());
            }
        }
    }
}