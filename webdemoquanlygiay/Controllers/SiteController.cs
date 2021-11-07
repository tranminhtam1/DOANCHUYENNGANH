using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
using webdemoquanlygiay.Controllers;
using MyClass.DAO;
using webdemoquanlygiay.DAO;
using PagedList;

namespace webdemoquanlygiay.Controllers
{
    public class SiteController : Controller

    {
        int pageSize = 6;
        CategoryDAO categoryDAO = new CategoryDAO();
        ProductDAO productDAO = new ProductDAO();
        
        // GET: Site
        mydbcontext db = new mydbcontext();
        private List<Product> newProducts(int count)
        {
            return db.Products.OrderByDescending(a => a.dateCreate).Take(count).ToList();
        }
        private List<Product> Laygiaymoi(int count)
        {
            return db.Products.OrderByDescending(a => a.productName).Take(count).ToList();

        }
        public ActionResult Index(int? page)
        {

            int pageSize = 8;
            int pageNum = (page ?? 1);
            var Lm = newProducts(32);
            return View(Lm.ToPagedList(pageNum, pageSize));
            //return View();
            //int pageSize = 8;
            //int pageNum = (page ?? 1);
            //var Lm = newProducts(32);
            //return View(Lm.ToPagedList(pageNum, pageSize));

        }
        public ActionResult Product(int? page)
        {

            int pageSize = 8;
            int pageNum = (page ?? 1);
            var Lm = newProducts(32);
            return View(Lm.ToPagedList(pageNum, pageSize));
        }


        public ActionResult ProductCategory()
        {
            return View();
        }
        public ActionResult HomeProduct(int catid)
        {
            int pagesize = 5;
            List<Product> list = productDAO.getList(catid, pagesize);
            return View(list);
        }
        public ActionResult Loaigiay()
        {
            var loaigiay = from lg in db.Products select lg;
            return View(loaigiay);
        }
        public ActionResult Thuonghieu()
        {
            var thuonghieu = from lg in db.Products select lg;
            return View(thuonghieu);
        }
        public ActionResult SPTheoloaigiay(int id, int? page)
        {
            int pageNum = (page ?? 1);
            var giay = db.Products.Where(p => p.categoryID == id).ToList();

            return View("Product", giay.ToPagedList(pageNum, pageSize));
        }
      
        public ActionResult SPTheothuonghieu(int id, int? page)
        {
            int pageNum = (page ?? 1);
            var giay = db.Products.Where(p => p.brandID == id).ToList();

            return View("Product", giay.ToPagedList(pageNum, pageSize));
        }
    }
}