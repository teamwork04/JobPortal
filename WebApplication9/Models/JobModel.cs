using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.ie.jobs.www;
namespace WebApplication9.Models.DatabaseEntity
{
    public class JobModel
    {
        public List<WebApplication9.ie.jobs.www.JobListItem> JobList { get; set; }
        public IEnumerable<SelectListItem> SectorList { get; set; }
        public IEnumerable<SelectListItem> LocationList { get; set; }
        public string SectorId { get; set; }
        public string LocationId { get; set; }
        public string Keyword { get; set; }
    }
}