using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Abstract;
using RecAgency.Concrete;
using RecAgency.Entities;
using System.Web.Security;
using DotNetOpenAuth.AspNet;
using Microsoft.Web.WebPages.OAuth;

namespace RecAgency.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            /*if (User.IsInRole("Applicant"))
            {
                return RedirectToAction("Index", "Applicant");
            }
            else if (User.IsInRole("Employer"))
            {
                return RedirectToAction("Index", "Employer");
            }
            else*/ if (User.IsInRole("Meneger"))
            {
                return RedirectToAction("Index", "Meneger");
            }
                return View();
        }












        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
