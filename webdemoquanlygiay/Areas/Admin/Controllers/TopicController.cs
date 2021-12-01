using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;

namespace webdemoquanlygiay.Areas.Admin.Controllers
{
    public class TopicController : Controller
    {
        // GET: Admin/Topic
        mydbcontext db = new mydbcontext();

        public ActionResult TopicList()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Topics.ToList());
        }

        public ActionResult insertTopic()
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpPost]
        public ActionResult insertTopic(Topic topic)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            db.Topics.Add(topic);
            db.SaveChanges();
            return RedirectToAction("TopicList");
        }

        public ActionResult editTopic(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View(db.Topics.Find(id));
        }

        [HttpPost]
        public ActionResult editTopic(Topic topic)
        {
            if (Session["userID"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            db.Entry(topic).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("TopicList");
        }

        public ActionResult deleteTopic(int? id)
        {
            if (Session["userID"] == null || id == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var topic = db.Topics.Find(id);
            db.Topics.Remove(topic);
            db.SaveChanges();
            return RedirectToAction("TopicList");
        }
    }
}