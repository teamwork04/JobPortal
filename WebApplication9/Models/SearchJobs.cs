using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication9.Models.DatabaseEntity
{
    public class SearchJobs
    {
        public int[] employeeIds { get; set; }
        public int[] jobCategoryIds { get; set; }
        public int[] regionIds { get; set; }
        public bool excludeAgencies { get; set; }
        public int[] industryIds { get; set; }
        public string jobType { get; set; }
        public string jobHours { get; set; }
        public string keywords { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int startRecord { get; set; }
        public int pageSize { get; set; }
        public string key { get; set; }
    }

}
