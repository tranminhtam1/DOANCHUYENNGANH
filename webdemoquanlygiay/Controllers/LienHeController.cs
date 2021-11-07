using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Controllers
{
    public class LienHeController : Controller
    {
        mydbcontext db = new mydbcontext();
        // GET: LienHe
        [HttpPost]
        public ActionResult Index(FormCollection contactForm)
        {

            Contact contact = new Contact();
            var title = contactForm["title"];
            var fullName = contactForm["fullName"];
            var email = contactForm["email"];
            var phone = contactForm["phonenumber"];
            var detail = contactForm["noidung"];
            contact.title = title;
            contact.fullName = fullName;
            contact.email = email;
            contact.detail = detail;
            contact.phone = phone;
            contact.dateCreate = DateTime.Now;
            contact.status = false;
            db.Contacts.Add(contact);
            db.SaveChanges();
            ViewBag.Notice = "<div class='alert alert-success text-center text-dark' role='alert'>Gửi liên hệ thành công</div>";
            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}