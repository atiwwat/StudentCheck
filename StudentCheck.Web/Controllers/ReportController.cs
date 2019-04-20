using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentCheck.DataAccess;
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
            var result = ReportRepository.GetPageReportDataNew(_configuration, _context);
            return View(result);
        }
    }
}