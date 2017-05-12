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
    public class UserContentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserContents
        public ActionResult Index()
        {
            var userContents = db.UserContents.Include(u => u.Content);
            return View(userContents.ToList());
        }

        // GET: UserContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContents.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            return View(userContent);
        }

        // GET: UserContents/Create
        public ActionResult Create()
        {
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note");
            return View();
        }

        // POST: UserContents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationUserID,ContentID")] UserContent userContent)
        {
            if (ModelState.IsValid)
            {
                db.UserContents.Add(userContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", userContent.ContentID);
            return View(userContent);
        }

        // GET: UserContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContents.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", userContent.ContentID);
            return View(userContent);
        }

        // POST: UserContents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationUserID,ContentID")] UserContent userContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ContentID = new SelectList(db.Contents, "ContentID", "Note", userContent.ContentID);
            return View(userContent);
        }

        // GET: UserContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserContent userContent = db.UserContents.Find(id);
            if (userContent == null)
            {
                return HttpNotFound();
            }
            return View(userContent);
        }

        // POST: UserContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserContent userContent = db.UserContents.Find(id);
            db.UserContents.Remove(userContent);
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
