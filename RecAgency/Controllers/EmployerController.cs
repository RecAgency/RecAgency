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
    [Authorize(Roles = "Employer")]
    public class EmployerController : Controller
    {
        private IVacancyRepository repository;
        private ISummaryAndVacancyRepository savrepository;

        public EmployerController(IVacancyRepository repo,ISummaryAndVacancyRepository savrepo)
        {
            this.repository = repo;
            this.savrepository = savrepo;
        }

        //
        // GET: /Employer/

        public ActionResult Index()
        {
            return View(repository.Vacancies.Where(s => s.UserId == WebMatrix.WebData.WebSecurity.CurrentUserId));
        }

        public ActionResult getApplicant(int VacancyId)
        {

            return View(savrepository.SummaryAndVacancy.Where(x=>x.VacancyId == VacancyId));
        }

        [HttpPost]
        public ActionResult DeleteResume(int Id)
        {
            SummaryAndVacancy deleteSummary = savrepository.DeleteSaV(Id);

            return RedirectToAction("Index", new { Controller = "Employer" });
        }

        public ActionResult Edit(int vacancyId)
        {
            Vacancy vacancy = repository.Vacancies.FirstOrDefault(s => s.Id == vacancyId);
            return View(vacancy);
        }

        [HttpPost]
        public ActionResult Edit(Vacancy vacancy)
        {
            if (ModelState.IsValid)
            {
                vacancy.UserId = WebMatrix.WebData.WebSecurity.CurrentUserId;
                repository.SaveVacancy(vacancy, WebMatrix.WebData.WebSecurity.CurrentUserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(vacancy);
            }
        }


        public ViewResult Create()
        {
            return View("Edit", new Vacancy());
        }

        [HttpPost]
        public ActionResult Delete(int vacancyId)
        {
            Vacancy deleteVacancy = repository.DeleteVacancy(vacancyId);
            return RedirectToAction("Index");
        }

    }
}
