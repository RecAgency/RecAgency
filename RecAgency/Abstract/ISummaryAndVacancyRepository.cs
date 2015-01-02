using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RecAgency.Entities;

namespace RecAgency.Abstract
{
    public interface ISummaryAndVacancyRepository
    {
        IQueryable<SummaryAndVacancy> SummaryAndVacancy { get; }
        void SaveSaV(SummaryAndVacancy SaV);
        SummaryAndVacancy DeleteSaV(int SaVId);
    }
}