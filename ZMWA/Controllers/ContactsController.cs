using CaptchaMvc.HtmlHelpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ZMWA.Models;

namespace ZMWA.Controllers
{
    public class ContactsController : Controller
    {
        private ContactDBContext db = new ContactDBContext();

        // GET: Contacts
        public ActionResult Index()
        {
            return View(db.Contacts.ToList());
        }

        // GET: Contacts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // GET: Contacts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Email,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {

                //var body = "<p>Message:</p><p>Thank you.</p>";
                //var message = new MailMessage();
                //message.From = new MailAddress("nikhil.kumrawat@zestixtech.com");
                //message.To.Add(new MailAddress("nikhil.kumrawat@zestixtech.com")); //replace with valid value
                //message.Subject = "Your email subject";
                //message.Body = string.Format(body);
                //message.IsBodyHtml = true;

                //using (var smtp = new SmtpClient())
                //{
                //    var credential = new NetworkCredential
                //    {
                //        UserName = "nikhil.kumrawat@zestixtech.com",  // replace with valid value
                //        Password = "Password!"  // replace with valid value
                //    };
                //    smtp.Credentials = credential;
                //    smtp.UseDefaultCredentials = false;
                //    smtp.Host = "smtp.zestixtech.com";
                //    smtp.Port = 25;
                //    smtp.EnableSsl = false;
                //  smtp.Send(message);
                if (this.IsCaptchaValid("Captcha is not valid"))
                {
                    db.Contacts.Add(contact);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.ErrMessage = "Error:Captcha is not valid";
            }
            return View(contact);
        }

        // GET: Contacts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Email,Phone,Message")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contact).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Contact contact = db.Contacts.Find(id);
            if (contact == null)
            {
                return HttpNotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Contact contact = db.Contacts.Find(id);
            db.Contacts.Remove(contact);
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
