using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RecAgency.Entities
{
    public class Summary
    {
        [HiddenInput (DisplayValue = false)]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Speciality { get; set; }
        public string Education { get; set; }
        public int ScopeOfWork { get; set; }
        public string Salary { get; set; }
        public string City { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int UserId { get; set; }

        public Summary()
        {
            this.Date = DateTime.Now;
        }

    }
}