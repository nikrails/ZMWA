using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
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
            PostResume postResume = db.PostResumes.Include(s => s.Files).SingleOrDefault(s => s.ID == id);
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
        public ActionResult Create([Bind(Include = "ID,Name,Dob,Email,PhoneNumber,Country,State,City,PinCode,LastEmployer,Experience,Source")] PostResume postResume, HttpPostedFileBase upload)
        { /*public async Task<ActionResult>*/
            if (ModelState.IsValid)
            {

                if (upload != null && upload.ContentLength > 0)
                {
                    var avatar = new Models.File
                    {
                        FileName = System.IO.Path.GetFileName(upload.FileName),
                        FileType = FileType.Avatar,
                        ContentType = upload.ContentType
                    };
                    using (var reader = new System.IO.BinaryReader(upload.InputStream))
                    {
                        avatar.Content = reader.ReadBytes(upload.ContentLength);
                    }
                    postResume.Files = new List<Models.File> { avatar };
                }

                if (this.IsCaptchaValid("Captcha is not valid"))
                    {
                        db.PostResumes.Add(postResume);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                ViewBag.ErrMessage = "Error:Invalid captcha";
                    return View(postResume);

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
        public ActionResult Edit([Bind(Include = "ID,Name,Dob,Email,PhoneNumber,Country,State,City,PinCode,LastEmployer,Experience,Source")] PostResume postResume)
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
