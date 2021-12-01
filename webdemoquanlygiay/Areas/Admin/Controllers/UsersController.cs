using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
using WebApplication1.Services;

namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private mydbcontext db = new mydbcontext();

        public ActionResult Employee()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var allEmployee = db.Users.Where(u => u.roleID != 1 && u.roleID != 2).ToList();
            return View(allEmployee);
        }


        public ActionResult insertEmployee()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Roles = db.Roles.Where(e => e.roleID != 1 && e.roleID != 2).ToList();
            return View();
        }

        [HttpPost]
        public ActionResult insertEmployee(FormCollection frm, HttpPostedFileBase ImageUpload)
        {
            var emp = new User();
            emp.roleID = Int32.Parse(frm["roleID"]);
            emp.fullName = frm["fullName"];
            emp.userName = frm["userName"];
            emp.password = MD5.MD5Hash(frm["password"].ToString());
            emp.email = frm["email"];
            emp.phoneNumber = frm["phoneNumber"];
            emp.address = frm["address"];
            emp.gender = bool.Parse(frm["gender"]);
            emp.dateOfBirth = DateTime.Parse(frm["dateOfBirth"]);
            if (ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName += extension;
                fileName += extension;
                emp.image = "~/Public/images/user/employee/" + fileName;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/user/employee"), fileName));


                db.Users.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Employee");
            }
            else
            {
                emp.image = "~/Public/images/user/employee/default-employee.jpg";
                db.Users.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Employee");
            }
        }

        [HttpGet]
        public ActionResult editEmployee(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.Roles = db.Roles.Where(e => e.roleID != 1 && e.roleID != 2).ToList();
            return View(db.Users.Find(id));
        }

        [HttpPost]
        public ActionResult editEmployee(FormCollection frm)
        {
            var emp = db.Users.Find(Int32.Parse(frm["userID"]));
            emp.roleID = Int32.Parse(frm["roleID"]);
            emp.fullName = frm["fullName"];
            emp.userName = frm["userName"];
            emp.password = frm["password"];
            emp.email = frm["email"];
            emp.phoneNumber = frm["phoneNumber"];
            emp.address = frm["address"];
            emp.gender = bool.Parse(frm["gender"]);
            emp.dateOfBirth = DateTime.Parse(frm["dateOfBirth"]);
            db.SaveChanges();
            return RedirectToAction("Employee");
        }

        public ActionResult deleteEmployee(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var selectedEmp = db.Users.Find(id);
            db.Users.Remove(selectedEmp);
            db.SaveChanges();
            return RedirectToAction("Employee", "Users");
        }

        public ActionResult employeeDetails(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var selectedEmp = db.Users.Find(id);
            return View(selectedEmp);
        }

        public ActionResult uploadImage(FormCollection frm, HttpPostedFileBase ImageUpload)
        {
            var user = db.Users.Find(Int32.Parse(frm["userID"]));
            if (ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                string extension = Path.GetExtension(ImageUpload.FileName);
                fileName += extension;
                user.image = "~/Public/images/user/employee/" + fileName; ;
                ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Public/images/user/employee"), fileName));
                db.SaveChanges();

                return RedirectToAction("editEmployee", "Users", new { id = Int32.Parse(frm["userID"]) });
            }
            else
            {
                user.image = "~/Public/images/user/employee/default-employee.jpg";
                db.SaveChanges();
                return RedirectToAction("editEmployee", "Users", new { id = Int32.Parse(frm["userID"]) });
            }
        }
    }
}