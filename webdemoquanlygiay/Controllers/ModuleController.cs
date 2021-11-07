using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
using MyClass.DAO;


namespace webdemoquanlygiay.Controllers
{
    public class ModuleController : Controller
    {
        
        public ActionResult ListCategory()
        {
            CategoryDAO categoryDAO = new CategoryDAO();
            List<Category> list = categoryDAO.getList(1);
            return View("ListCategory", list);
        }
        public ActionResult ListThuonghieu()
        {
            ThuonghieuDAO thuonghieuDAO = new ThuonghieuDAO();
            List<Brand> list = thuonghieuDAO.getList(1);
            return View("ListThuonghieu", list);
        }
    }
}