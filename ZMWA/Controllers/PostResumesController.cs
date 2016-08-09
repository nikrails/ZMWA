using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZMWA.Models;

namespace ZMWA.Controllers
{
    public class PostResumesController : Controller
    {
        private ContactDBContext db = new ContactDBContext();

        // GET: PostResumes
        public ActionResult Index()
        {
            return View(db.PostResumes.ToList());
        }

        // GET: PostResumes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostResume postResume = db.PostResumes.Include(i => i.FilePaths).SingleOrDefault(i => i.ID == id);
            if (postResume == null)
            {
                return HttpNotFound();
            }
            return View(postResume);
        }

        // GET: PostResumes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PostResumes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Dob,PhoneNumber,Country,State,City,PinCode,LastEmployer,Experience,Source")] PostResume postResume, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    var photo = new FilePath
                    {
                        FileName = Guid.NewGuid().ToString() + System.IO.Path.GetExtension(upload.FileName),
                        FileType = FileType.Photo
                    };
                    postResume.FilePaths = new List<FilePath>();
                    postResume.FilePaths.Add(photo);
                    upload.SaveAs(Path.Combine(Server.MapPath("~/Images"), photo.FileName));
                }

                db.PostResumes.Add(postResume);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(postResume);
        }

        // GET: PostResumes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostResume postResume = db.PostResumes.Find(id);
            if (postResume == null)
            {
                return HttpNotFound();
            }
            return View(postResume);
        }

        // POST: PostResumes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Dob,PhoneNumber,Country,State,City,PinCode,LastEmployer,Experience,Source")] PostResume postResume)
        {
            if (ModelState.IsValid)
            {
                db.Entry(postResume).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(postResume);
        }

        // GET: PostResumes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PostResume postResume = db.PostResumes.Find(id);
            if (postResume == null)
            {
                return HttpNotFound();
            }
            return View(postResume);
        }

        // POST: PostResumes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PostResume postResume = db.PostResumes.Find(id);
            db.PostResumes.Remove(postResume);
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
