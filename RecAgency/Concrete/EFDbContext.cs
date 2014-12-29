using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using RecAgency.Entities;

namespace RecAgency.Concrete
{
    public class EFDbContext: DbContext
    {
        public DbSet<Summary> Summaries { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
    }
}