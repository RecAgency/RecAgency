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
    public class MenegerController : Controller
    {
        //
        // GET: /Meneger/

        private IVacancyRepository Vrepository;
        private ISummaryRepository Srepository;
        public MenegerController(IVacancyRepository vrepo, ISummaryRepository srepo)
        {
            this.Vrepository = vrepo;
            this.Srepository = srepo;
        }
        public ActionResult Index()
        {
            return View();
        }

        //=================================================================================================Vacancy:

        public ActionResult EditVacancy(int vacancyId)
        {
            Vacancy vacancy = Vrepository.Vacancies.FirstOrDefault(s => s.Id == vacancyId);
            return View(vacancy);
        }

        [HttpPost]
        public ActionResult EditVacancy(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                Vrepository.SaveVacancy(vacancy, WebMatrix.WebData.WebSecurity.CurrentUserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vacancy);
            }
        }


        public ViewResult CreateVacancy()
        {
            return View("Edit", new Vacancy());
        }

        [HttpPost]
        public ActionResult DeleteVacancy(int vacancyId)
        {
            Vacancy deleteVacancy = Vrepository.DeleteVacancy(vacancyId);
            return RedirectToAction("Index");
        }

        //=========================== ================================================================RESUME:

        public ActionResult EditResume(int summaryId)
        {
            Summary summary = Srepository.Summaries.FirstOrDefault(s => s.Id == summaryId);
            return View(summary);
        }

        [HttpPost]
        public ActionResult EditResume(Summary summmary)
        {
            if (ModelState.IsValid)
            {
                Srepository.SaveSummary(summmary, WebMatrix.WebData.WebSecurity.CurrentUserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(summmary);
            }
        }

        public ViewResult CreateResume()
        {
            return View("Edit", new Summary());
        }

        [HttpPost]
        public ActionResult DeleteResume(int summaryId)
        {
            Summary deleteSummary = Srepository.DeleteSummary(summaryId);
            return RedirectToAction("Index");
        }

        //===================================================================================================
        public ActionResult ListResume()
        {
            return View(Srepository.Summaries.ToList());
        }

        public ActionResult ListVacancy()
        {
            return View(Vrepository.Vacancies.ToList());
        }
    }
}