using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecAgency.Entities;

namespace RecAgency.Abstract
{
    public interface IVacancyRepository
    {
        IQueryable<Vacancy> Vacancies { get; }
        void SaveVacancy(Vacancy vacancy, int UserId);
        Vacancy DeleteVacancy(int vacancyId);
    }
}
