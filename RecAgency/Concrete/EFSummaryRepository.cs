using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using RecAgency.Entities;
using RecAgency.Abstract;

namespace RecAgency.Concrete
{
    public class EFSummaryRepository:ISummaryRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Summary> Summaries
        {
            get { return context.Summaries; }
        }

        public void SaveSummary(Summary summary, int userId)
        {
            if (summary.Id == 0)
            {
                context.Summaries.Add(summary);
            }
            else
            {
                Summary dbEntry = context.Summaries.Find(summary.Id);
                if (dbEntry != null)
                {
                    dbEntry.City = summary.City;
                    dbEntry.Date = summary.Date;
                    dbEntry.Education = summary.Education;
                    dbEntry.Salary = summary.Salary;
                    dbEntry.ScopeOfWork = summary.ScopeOfWork;
                    dbEntry.Speciality = summary.Speciality;
                }
            }

            context.SaveChanges();
        }

        public Summary DeleteSummary(int summaryId)
        {
            Summary dbEntry = context.Summaries.Find(summaryId);
            if (dbEntry != null)
            {
                context.Summaries.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }


    }
}