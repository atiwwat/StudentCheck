using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using StudentCheck.DataAccess;
using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using StudentCheck.DataAccess.Repository;

namespace StudentCheck.Web.Controllers
{
    public class ManageSubjectController : Controller
    {
         private readonly StudentCheckDbContext _context;

        public ManageSubjectController(StudentCheckDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            ManageSubjectViewModel model = new ManageSubjectViewModel();
            model.modelCreateSubject = new CreateSubjectModel();

            model.Subjects = ManageSubjectRepository.GetSubjects(_context);

            return View(model);
        }

        [HttpPost]
        public JsonResult SaveSubject(ManageSubjectViewModel modelToSave)
        {
            bool result;

            try
            {
                ManageSubjectRepository.SaveSubject(_context, modelToSave.modelCreateSubject);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateSubject(ManageSubjectViewModel modelToUpdate)
        {
            bool result;

            try
            {
                ManageSubjectRepository.UpdateSubject(_context, modelToUpdate.modelCreateSubject);
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteSubject(string SubjectId)
        {
            bool result;

            try
            {
                ManageSubjectRepository.DeleteSubject(_context, SubjectId);
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return Json(result);
        }

        public PartialViewResult UpdateSubjectTable()
        {
            ManageSubjectViewModel model = new ManageSubjectViewModel();
            model.modelCreateSubject = new CreateSubjectModel();

            model.Subjects = ManageSubjectRepository.GetSubjects(_context);

            return PartialView("_DatatableOfSubject", model);
        }
        [HttpPost]
        public PartialViewResult UploadSubjectDataFile(IFormFile subjectdatafile)
        {
            List<Subjects> subjects = new List<Subjects>();
            using (ExcelPackage package = new ExcelPackage(subjectdatafile.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    subjects.Add(new Subjects
                    {
                        SubjectId = worksheet.Cells["A" + row.ToString()].Value == null ? null : worksheet.Cells["A" + row.ToString()].Value.ToString(),
                        SubjectNameThai = worksheet.Cells["B" + row.ToString()].Value == null ? null : worksheet.Cells["B" + row.ToString()].Value.ToString(),
                        SubjectNameEng = worksheet.Cells["C" + row.ToString()].Value == null ? null : worksheet.Cells["C" + row.ToString()].Value.ToString(),
                        SubjectCredit = worksheet.Cells["D" + row.ToString()].Value == null ? 0 : Convert.ToUInt16(worksheet.Cells["D" + row.ToString()].Value),

                    });
                }

            }
            subjects.RemoveAll(w => w.SubjectId == null);
            ManageSubjectRepository.SaveSubjectList(_context, subjects);
            ManageSubjectViewModel model = new ManageSubjectViewModel();
            model.modelCreateSubject = new CreateSubjectModel();

            model.Subjects = ManageSubjectRepository.GetSubjects(_context);


            return PartialView("_DatatableOfSubject", model);
        }
    }
}

    