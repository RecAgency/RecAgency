using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Entities
{
    public class SummaryAndVacancy
    {
        public int Id { get; set; }
        public int VacancyId { get; set; }
        public int SummaryId { get; set; }
        public Vacancy vac { get; set; }
        public Summary summary { get; set; }
    }
}