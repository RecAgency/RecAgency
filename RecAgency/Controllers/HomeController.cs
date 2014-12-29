using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Abstract;
using RecAgency.Concrete;
using RecAgency.Entities;

namespace RecAgency.Controllers
{
    public class HomeController : Controller
    {
              //  private IVacancyRepository Vrepository;
              //  private ISummaryRepository Srepository;
        public HomeController()//IVacancyRepository vrepo, ISummaryRepository srepo)
        {
           // this.Vrepository = vrepo;
           // this.Srepository = srepo;
        }


        public ActionResult Index()
        {
            ViewBag.Message = "RecAgency";
            return View();
        }


        public ActionResult ListResume()
        {
            return View();//Srepository.Summaries.ToList());
        }

        public ActionResult ListVacancy()
        {
            return View();//Vrepository.Vacancies.ToList());
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
