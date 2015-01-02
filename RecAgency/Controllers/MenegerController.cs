﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RecAgency.Abstract;
using RecAgency.Concrete;
using RecAgency.Entities;
namespace RecAgency.Controllers
{
    [Authorize(Roles = "Meneger")]
    public class MenegerController : Controller
    {
        //
        // GET: /Meneger/

        private IVacancyRepository Vrepository;
        private ISummaryRepository Srepository;
        private ISummaryAndVacancyRepository savrepository;
        public MenegerController(IVacancyRepository vrepo, ISummaryRepository srepo, ISummaryAndVacancyRepository savrepo)
        {
            this.Vrepository = vrepo;
            this.Srepository = srepo;
            this.savrepository = savrepo;
        }

        public ViewResult Index()
        {
                        
                ViewBag.Vacancy = new SelectList(Vrepository.Vacancies.ToList(), "Id", "Id");
                ViewBag.Resume = new SelectList(Srepository.Summaries, "Id", "Id");
            return View();
        }

        [HttpPost]
        public ViewResult Index(string Vacancy, string Resume)
        {
            SummaryAndVacancy SaV = new SummaryAndVacancy();
            SaV.VacancyId = Convert.ToInt32(Vacancy);
            SaV.SummaryId = Convert.ToInt32(Resume);
            savrepository.SaveSaV(SaV);
            return View();

        }
        public ViewResult CreateVacancy()
        {
            return View("EditVacancy", new Vacancy());
        }

        public ViewResult CreateResume()
        {
            return View("EditResume", new Summary());
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
            return View(Srepository.Summaries);
        }

        public ActionResult ListVacancy()
        {
            return View(Vrepository.Vacancies);
        }
    }
}