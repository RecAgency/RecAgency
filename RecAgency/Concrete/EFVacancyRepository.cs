using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RecAgency.Entities;
using RecAgency.Abstract;

namespace RecAgency.Concrete
{
    public class EFVacancyRepository: IVacancyRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Vacancy> Vacancies
        {
            get { return context.Vacancies; }
        }

        public void SaveVacancy(Vacancy vacancy, int UserId) 
        {
            if (vacancy.Id == 0)
            {
                context.Vacancies.Add(vacancy);
            }
            else
            {
                Vacancy dbEntry = context.Vacancies.Find(vacancy.Id);
                if (dbEntry != null)
                {
                    dbEntry.Title = vacancy.Title;
                    dbEntry.Responsibility = vacancy.Responsibility;
                    dbEntry.Requirements = vacancy.Requirements;
                    dbEntry.Conditions = vacancy.Conditions;
                }
            }
            context.SaveChanges();
        }

        public Vacancy DeleteVacancy(int vacancyId)
        {
            Vacancy dbEntry = context.Vacancies.Find(vacancyId);
            if (dbEntry != null)
            {
                context.Vacancies.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}