using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using COMP4900Project.Models;
using Microsoft.AspNet.Identity;
using System.Drawing;

namespace COMP4900Project.Controllers
{
    public class ContentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Contents
        public ActionResult Index()
        {
            string username = User.Identity.GetUserName();

            if (Request.IsAuthenticated && username == "Admin")
            {
                return View(db.Contents.ToList());
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        
        public string GetOne(int? id)
        {
            if(id == null)
            {
                return null;
            }
            Content contentsmodel = db.Contents.Find(id);
            return contentsmodel.Note;

        }

        // GET: Contents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

      
        // GET: Contents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ContentId,Text,Note,Reference")] Content content)
        {
            content.TimeUpdated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Contents.Add(content);
                db.SaveChanges();
                //return RedirectToAction("Index");
                //return RedirectToAction("Create", "UserContents");

                string userid = User.Identity.GetUserId();
                int contentid = content.ContentId;

                var result = new UserContentsController().Create(new UserContent(userid, contentid));

                return RedirectToAction("Index", "UserContents");
            }

            return View(content);
        }

        // GET: Contents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Contents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ContentId,Text,Note,Reference")] Content content)
        {
            content.TimeUpdated = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                //return RedirectToAction("Index");
                return RedirectToAction("Index", "UserContents");
            }
            return View(content);
        }

        // GET: Contents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Contents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
            db.SaveChanges();
            //return RedirectToAction("Index");
            return RedirectToAction("Index", "UserContents");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }







        private OCRTools.OCR OCR1;

        [HttpPost]
        public string OCR([Bind(Include = "ContentId,Text,Note,Reference")] Content content, HttpPostedFileBase ePic = null)
        {
            OCR1 = new OCRTools.OCR();
            OCR1.DefaultFolder = Server.MapPath("/bin");

            OCR1.BitmapImage = (Bitmap)Image.FromStream(ePic.InputStream, true, true);

            //OCR1.BitmapImageFile = ePic.FileName;
            OCR1.Process();
            content.Note = OCR1.Text;

            return content.Note;
        }
    }
}
