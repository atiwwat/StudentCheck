using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Rotativa.AspNetCore;
using Rotativa.AspNetCore.Options;
using StudentCheck.DataAccess;
using StudentCheck.DataAccess.ModelViews;
using StudentCheck.DataAccess.Repository;

namespace StudentCheck.Web.Controllers
{
    public class ReportController : Controller
    {

        private readonly IConfiguration _configuration;

        private readonly StudentCheckDbContext _context;

        public ReportController(IConfiguration configuration, StudentCheckDbContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PrintReport()
        {
            //ReportViewModel model = new ReportViewModel();

            //model.modelReport = new List<CreateReport>();
            List<PageReport> reportList = ReportRepository.GetPageReportDataNew(_configuration, _context);

            return new ViewAsPdf("PrintReport", reportList)
            {
                PageMargins = new Margins(4, 4, 4, 4)
            };
        //var result = ReportRepository.GetPageReportDataNew(_configuration, _context);
            //return View(reportList);
        }
    }
}