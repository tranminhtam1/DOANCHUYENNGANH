﻿using System;

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;
using WebApplication1.Services;
namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class ContactController : Controller
    {
        mydbcontext db = new mydbcontext();
        // GET: Admin/Contact
        // GET: Admin/Contact
        EmailService emailService = new EmailService();
        public ActionResult listContact()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var listContact = db.Contacts.ToList();
            return View(listContact);
        }

        public ActionResult contactDetails(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var contact = db.Contacts.Find(id);
            contact.status = true;
            db.SaveChanges();
            return View(contact);
        }

        public ActionResult deleteContact(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
            db.SaveChanges();
            return RedirectToAction("listContact", "Contact");
        }

        [HttpGet]
        public ActionResult feedback(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var contact = db.Contacts.Find(id);
            return View(contact);
        }

        [HttpPost]
        public ActionResult feedback(FormCollection frm)
        {
            string Address = frm["address"];
            string Title = frm["title"];
            string Message = frm["message"];
            emailService.sendEmail(Address, Title, Message);

            return RedirectToAction("listContact", "Contact");
        }
    }
}