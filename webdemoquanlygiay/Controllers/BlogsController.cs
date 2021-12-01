using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using webdemoquanlygiay.Models;


namespace webdemoquanlygiay.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        mydbcontext db = new mydbcontext();
        public ActionResult Index(int? IDTopic)
        {
            ViewBag.Topics = db.Topics.ToList();
            List<Blog> listBlog = new List<Blog>();
            listBlog = db.Blogs.ToList();


            if (IDTopic != null)
            {
                listBlog = db.Blogs.Where(p => p.IDTopic == IDTopic).ToList();
            }
            else
            {
                listBlog = db.Blogs.ToList();
            }
            return View(listBlog);
        }
        public ActionResult filterByTopic(int id)
        {
            return RedirectToAction("Index", "Blogs", new { IDTopic = id });
        }

        // GET: Product
        public ActionResult TopicBlog()
        {
            List<Topic> Topic_Blog = new List<Topic>();
            Topic_Blog = db.Topics.ToList();
            return View(Topic_Blog);
        }

        public ActionResult BlogDetail(int id)
        {
            Blog blog = new Blog();
            blog = db.Blogs.Where(p => p.IDBlog == id).SingleOrDefault();

            return View(blog);
        }
    }
}