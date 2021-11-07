using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace webdemoquanlygiay.Controllers
{
    public class GioithieuController : Controller
    {
        // GET: Gioithieu
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Policy()
        {
            return View();
        }

        public ActionResult Warranty()
        {
            return View();
        }

        public ActionResult Condition()
        {
            return View();
        }
    }
}