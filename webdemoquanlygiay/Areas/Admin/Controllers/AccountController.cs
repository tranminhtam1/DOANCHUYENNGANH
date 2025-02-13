﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
using WebApplication1.Services;
namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        mydbcontext db = new mydbcontext();
        // GET: Admin/Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection frm)
        {
            var username = frm["userName"];
            var password = MD5.MD5Hash(frm["password"]);
            User user = db.Users.SingleOrDefault(u => u.userName == username &&
                                                 u.password == password &&
                                                 u.Role.roleName != "Khách hàng");
            if (user != null)
            {
                Session["admin"] = user;
                Session["userID"] = user.userID;
                Session["fullname"] = user.fullName;
                Session["image"] = user.image;
                return RedirectToAction("Index", "Products");
            }
            ViewBag.Notice = "Sai tài khoản hoặc mật khẩu";
            return View();
        }

        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
    }
}