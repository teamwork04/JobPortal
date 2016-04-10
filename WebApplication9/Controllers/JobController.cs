using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication9.ie.jobs.www;
using WebApplication9.Models.DatabaseEntity;
namespace Job.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        [Authorize(Roles = "Employer")]
        public ActionResult Index(JobModel _mm, int? pnumber, int? psize)
        {
            int recordCount = 0;
            JobModel _model = new JobModel();
            JobWS objJob = new JobWS();
            SearchJobs obj = new SearchJobs();
            obj.startRecord = 0;
            obj.pageSize = 20;
            if (pnumber.HasValue)
            {
                obj.pageSize = psize.Value;
            }
            if (pnumber.HasValue)
            {
                pnumber = pnumber.Value;
                obj.startRecord = (pnumber.Value - 1) * psize.Value;
            }
            else
            {
                pnumber = 1;
                obj.startRecord = 0;
            }


            obj.jobCategoryIds = new int[] { Convert.ToInt32(Session["SectorId"]) };
            obj.regionIds = new int[] { Convert.ToInt32(Session["LocationId"]) };
            obj.keywords = Convert.ToString(Session["Keyword"]);
            if (Convert.ToInt32(Session["SectorId"]) == 0)
            {
                obj.jobCategoryIds = null;
            }
            if (Convert.ToInt32(Session["LocationId"]) == 0)
            {
                obj.regionIds = null;
            }
            _model.JobList = objJob.SearchJobs(obj.employeeIds, obj.jobCategoryIds, obj.regionIds, obj.excludeAgencies, obj.industryIds, JobDuration.Any, JobHours.Any, obj.keywords, obj.fromDate, obj.toDate, obj.startRecord, obj.pageSize, obj.key, out recordCount).ToList();
            _model.LocationList = BindCountry();
            _model.SectorList = BindSector();
            _model.LocationId = Convert.ToString(Session["LocationId"]);
            _model.SectorId = Convert.ToString(Session["SectorId"]);
            _model.Keyword = Convert.ToString(Session["Keyword"]);
            ViewBag.PageNumber = pnumber;
            ViewBag.RecordCount = recordCount;
            int mod = recordCount % obj.pageSize;
            int pagecount = recordCount / obj.pageSize;
            if (mod > 0)
            {
                pagecount = pagecount + 1;
            }

            ViewBag.PageCount = pagecount;
            ViewBag.PageSize = obj.pageSize;
            return View(_model);
        }

        public ActionResult SearchJob(JobModel _mm)
        {
            Session["SectorId"] = _mm.SectorId;
            Session["LocationId"] = _mm.LocationId;
            Session["Keyword"] = _mm.Keyword;
            return RedirectToAction("Index");
        }
        public static IEnumerable<SelectListItem> BindCountry()
        {

            JobWS objJob = new JobWS();

            List<JobRegion> country = objJob.GetJobRegions().ToList();

            IEnumerable<SelectListItem> myCollection = country
                                             .Select(i => new SelectListItem()
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             });

            return myCollection;
        }

        public static IEnumerable<SelectListItem> BindSector()
        {

            JobWS objJob = new JobWS();

            List<JobCategory> region = objJob.GetJobCategories().ToList();

            IEnumerable<SelectListItem> myCollection = region
                                             .Select(i => new SelectListItem()
                                             {
                                                 Text = i.Name,
                                                 Value = i.Id.ToString()
                                             });

            return myCollection;
        }
    }
}