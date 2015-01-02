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
    [Authorize(Roles = "Applicant")]
    public class ApplicantController : Controller
    {
        private ISummaryRepository repository;
        public ApplicantController(ISummaryRepository repo)
        {
            this.repository = repo;
        }

        public ActionResult Index()
        {
            return View(repository.Summaries.Where(s => s.UserId == WebMatrix.WebData.WebSecurity.CurrentUserId));
        }

        public ActionResult Edit(int summaryId)
        {
            Summary summary = repository.Summaries.FirstOrDefault(s => s.Id == summaryId);
            return View(summary);
        }

        [HttpPost]
        public ActionResult Edit(Summary summmary)
        {
            if (ModelState.IsValid)
            {
                summmary.UserId = WebMatrix.WebData.WebSecurity.CurrentUserId;
                repository.SaveSummary(summmary, WebMatrix.WebData.WebSecurity.CurrentUserId);
                return RedirectToAction("Index");
            }
            else
            {
                return View(summmary);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Summary());
        }

        [HttpPost]
        public ActionResult Delete(int summaryId)
        {
            Summary deleteSummary = repository.DeleteSummary(summaryId);
            return RedirectToAction("Index");
        }
    }
}
