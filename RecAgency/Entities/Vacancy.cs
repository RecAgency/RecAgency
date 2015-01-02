using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RecAgency.Entities
{
    public class Vacancy
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Responsibility { get; set; }

        public string Requirements { get; set; }
        public string Conditions { get; set; }

        public int? UserId { get; set; }
    }
}