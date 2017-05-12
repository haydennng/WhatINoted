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
    public class UserGroupsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: UserGroups
        public ActionResult Index()
        {
            var userGroups = db.UserGroups.Include(u => u.Group);
            return View(userGroups.ToList());
        }

        // GET: UserGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // GET: UserGroups/Create
        public ActionResult Create()
        {
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName");
            return View();
        }

        // POST: UserGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ApplicationUserID,GroupID")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.UserGroups.Add(userGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userGroup.GroupID);
            return View(userGroup);
        }

        // GET: UserGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userGroup.GroupID);
            return View(userGroup);
        }

        // POST: UserGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ApplicationUserID,GroupID")] UserGroup userGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GroupID = new SelectList(db.Groups, "GroupID", "GroupName", userGroup.GroupID);
            return View(userGroup);
        }

        // GET: UserGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserGroup userGroup = db.UserGroups.Find(id);
            if (userGroup == null)
            {
                return HttpNotFound();
            }
            return View(userGroup);
        }

        // POST: UserGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserGroup userGroup = db.UserGroups.Find(id);
            db.UserGroups.Remove(userGroup);
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
