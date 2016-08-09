using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZMWA.Models;

namespace ZMWA.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ImageSource index = new ImageSource();
            if(Request.Browser.IsMobileDevice)
                index.ImagePath = "~/Content/Images/ConferenceRoom.jpg";
            else
                index.ImagePath = "~/Content/Images/ConferenceRoom.jpg";
            return View(index);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ImageSource contact = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                contact.ImagePath = "~/Content/Images/contact.jpg";
            else
                contact.ImagePath = "~/Content/Images/contact.jpg";
            return View(contact);

        }
        public ActionResult Job()
        {
            ImageSource job = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                job.ImagePath = "~/Content/Images/Career.jpg";
            else
                job.ImagePath = "~/Content/Images/Career.jpg";
            return View(job);
        }

        public ActionResult AgileDevelopment()
        {
            ImageSource agileDevelopment = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                agileDevelopment.ImagePath = "~/Content/Images/AgileDevelopment.jpg";
            else
                agileDevelopment.ImagePath = "~/Content/Images/AgileDevelopment.jpg";
            return View(agileDevelopment);
        }
        public ActionResult MobileDevelopment()
        {
            ImageSource mobileDevelopment = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                mobileDevelopment.ImagePath = "~/Content/Images/MobileDevelopment.jpg";
            else
                mobileDevelopment.ImagePath = "~/Content/Images/MobileDevelopment.jpg";
            return View(mobileDevelopment);
        }
        public ActionResult ApplicationDevelopment()
        {
            ImageSource applicationDevelopment = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                applicationDevelopment.ImagePath = "~/Content/Images/ApplicationDevelopment.jpg";
            else
                applicationDevelopment.ImagePath = "~/Content/Images/ApplicationDevelopment.jpg";
            return View(applicationDevelopment);
        }
        public ActionResult Testing()
        {
            ImageSource testing = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                testing.ImagePath = "~/Content/Images/Testing.jpg";
            else
                testing.ImagePath = "~/Content/Images/Testing.jpg";
            return View(testing);
        }
        public ActionResult BankingFinancial()
        {
            ImageSource bankingFinancial = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                bankingFinancial.ImagePath = "~/Content/Images/BankingFinancial.jpg";
            else
                bankingFinancial.ImagePath = "~/Content/Images/BankingFinancial.jpg";
            return View(bankingFinancial);
        }
        public ActionResult Insurance()
        {
            ImageSource insurance = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                insurance.ImagePath = "~/Content/Images/Insurance.jpg";
            else
                insurance.ImagePath = "~/Content/Images/Insurance.jpg";
            return View(insurance);
        }
        public ActionResult HealthCare()
        {
            ImageSource healthCare = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                healthCare.ImagePath = "~/Content/Images/HealthCare.jpg";
            else
                healthCare.ImagePath = "~/Content/Images/HealthCare.jpg";
            return View(healthCare);
        }
        public ActionResult TravelLogistics()
        {
            ImageSource travelLogistics = new ImageSource();
            if (Request.Browser.IsMobileDevice)
                travelLogistics.ImagePath = "~/Content/Images/TravelLogistics.jpg";
            else
                travelLogistics.ImagePath = "~/Content/Images/TravelLogistics.jpg";
            return View(travelLogistics);
        }
    }
}