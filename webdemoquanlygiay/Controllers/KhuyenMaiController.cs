using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Controllers
{
    public class KhuyenMaiController : Controller
    {
        // GET: KhuyenMai
        mydbcontext db = new mydbcontext();
        public ActionResult discountPage()
        {
            return View(db.Discounts.ToList());
        }
    }
    
}