using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecAgency.Entities
{
    public class Vacancy
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Responsibility { get; set; }

        public string Requirements { get; set; }
        public string Conditions { get; set; }

        public int? UserId { get; set; }
    }
}