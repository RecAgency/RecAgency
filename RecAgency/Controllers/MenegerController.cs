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

        public ActionResult EditResume(int summaryId)
        {
            Summary summary = Srepository.Summaries.FirstOrDefault(s => s.Id == summaryId);
            return View(summary);
        }

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
                Vrepository.SaveVacancy(vacancy, (int)vacancy.UserId);
                return RedirectToAction("Index", new { Controller = "Home" });
            }
            else
            {
                return View(vacancy);
            }
        }

        [HttpPost]
        public ActionResult DeleteVacancy(int vacancyId)
        {
            Vacancy deleteVacancy = Vrepository.DeleteVacancy(vacancyId);
            return RedirectToAction("Index", new { Controller = "Home"});
        }






        

        [HttpPost]
        public ActionResult EditResume(Summary summmary)
        {
            if (ModelState.IsValid)
            {
                Srepository.SaveSummary(summmary, (int)summmary.UserId);
                return RedirectToAction("Index", new { Controller = "Home"});
            }
            else
            {
                return View(summmary);
            }
        }

        [HttpPost]
        public ActionResult DeleteResume(int summaryId)
        {
            Summary deleteSummary = Srepository.DeleteSummary(summaryId);
            return RedirectToAction("Index", new { Controller = "Home" });
        }
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