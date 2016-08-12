using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZMWA.Models;

namespace ZMWA.Controllers
{
    public class FileController : Controller
    { 

        private ContactDBContext db = new ContactDBContext();
        //
        // GET: /File/
        public ActionResult Index(int id)
        {
            var fileToRetrieve = db.Files.Find(id);
            return File(fileToRetrieve.Content, fileToRetrieve.ContentType);
        }

     
    }
    
}