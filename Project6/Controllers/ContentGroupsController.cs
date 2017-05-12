using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project6.Models;

namespace Project6.Controllers
{
    public class ContentGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ContentGroups
        public ActionResult Index()
        {
            var contentGroups = db.ContentGroups.Include(c => c.Content).Include(c => c.Group);
            return View(contentGroups.ToList());
        }

        // GET: ContentGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentGroup contentGroup = db.ContentGroups.Find(id);
            if (contentGroup == null)
            {
                return HttpNotFound();
            }
            return View(contentGroup);
        }

        // GET: ContentGroups/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note");
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: ContentGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentID,GroupID")] ContentGroup contentGroup)
        {
            if (ModelState.IsValid)
            {
                db.ContentGroups.Add(contentGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", contentGroup.ContentID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", contentGroup.GroupID);
            return View(contentGroup);
        }

        // GET: ContentGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentGroup contentGroup = db.ContentGroups.Find(id);
            if (contentGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", contentGroup.ContentID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", contentGroup.GroupID);
            return View(contentGroup);
        }

        // POST: ContentGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentID,GroupID")] ContentGroup contentGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contentGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", contentGroup.ContentID);
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", contentGroup.GroupID);
            return View(contentGroup);
        }

        // GET: ContentGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContentGroup contentGroup = db.ContentGroups.Find(id);
            if (contentGroup == null)
            {
                return HttpNotFound();
            }
            return View(contentGroup);
        }

        // POST: ContentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContentGroup contentGroup = db.ContentGroups.Find(id);
            db.ContentGroups.Remove(contentGroup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
