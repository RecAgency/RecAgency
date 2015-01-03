using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecAgency.Entities;
using RecAgency.Abstract;

namespace RecAgency.Concrete
{
    public class EFSummaryAndVacancyRepository : ISummaryAndVacancyRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<SummaryAndVacancy> SummaryAndVacancy
        {
            get { return context.SummaryAndVacancy; }
        }

        public void SaveSaV(SummaryAndVacancy SaV)
        {
            //Поскольку редактирования нет, то только чистое добавление
            context.SummaryAndVacancy.Add(SaV);
            context.SaveChanges();
        }

        public SummaryAndVacancy DeleteSaV(int SaVId)
        {
            SummaryAndVacancy dbEntry = context.SummaryAndVacancy.Where(x=>x.Id == SaVId).FirstOrDefault();
            if (dbEntry != null)
            {
                context.SummaryAndVacancy.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}