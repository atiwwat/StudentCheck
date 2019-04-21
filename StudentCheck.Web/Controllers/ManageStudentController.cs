using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OfficeOpenXml;
using StudentCheck.DataAccess;
using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using StudentCheck.DataAccess.Repository;


namespace StudentCheck.Web.Controllers
{
    public class ManageStudentController : Controller
    {
        private readonly StudentCheckDbContext _context;

        public ManageStudentController(StudentCheckDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ManageStudentViewModel model = new ManageStudentViewModel();
            model.modelCreatStudent = new CreateStudentModel();

            model.StudentList = ManageStudentRepository.GetStudentList(_context);

            return View(model);
        }

        [HttpPost]
        public JsonResult SaveStudent(ManageStudentViewModel modelToSave)
        {
            bool result;

            try
            {
                ManageStudentRepository.SaveStudent(_context, modelToSave.modelCreatStudent);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateStudent(ManageStudentViewModel modelToUpdate)
        {
            bool result;

            try
            {
                ManageStudentRepository.UpdateStudent(_context, modelToUpdate.modelCreatStudent);
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeleteStudent(string StudentId)
        {
            bool result;

            try
            {
                ManageStudentRepository.DeleteStudent(_context, StudentId);
                result = true;
            }
            catch (Exception ex)
            {

                result = false;
            }

            return Json(result);
        }

        public PartialViewResult UpdateStudentTable()
        {
            ManageStudentViewModel model = new ManageStudentViewModel();
            model.modelCreatStudent = new CreateStudentModel();

            model.StudentList = ManageStudentRepository.GetStudentList(_context);

            return PartialView("_DatatableOfStudent", model);
        }

        [HttpPost]
        public PartialViewResult UploadStudentDataFile(IFormFile studentDataFile)
        {
            List<StudentList> studentLists = new List<StudentList>();
            using (ExcelPackage package = new ExcelPackage(studentDataFile.OpenReadStream()))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
                int rowCount = worksheet.Dimension.Rows;
                int ColCount = worksheet.Dimension.Columns;

                for (int row = 2; row <= rowCount; row++)
                {
                    studentLists.Add(new StudentList
                    {
                        StudentId = worksheet.Cells["A" + row.ToString()].Value == null ? null : worksheet.Cells["A" + row.ToString()].Value.ToString(),
                        StudentFirstname = worksheet.Cells["B" + row.ToString()].Value == null ? null : worksheet.Cells["B" + row.ToString()].Value.ToString(),
                        StudentLastname = worksheet.Cells["C" + row.ToString()].Value == null ? null : worksheet.Cells["C" + row.ToString()].Value.ToString(),
                        StudentEmail = worksheet.Cells["D" + row.ToString()].Value == null ? null : worksheet.Cells["D" + row.ToString()].Value.ToString(),
                        StudentTel = worksheet.Cells["E" + row.ToString()].Value == null ? null : worksheet.Cells["E" + row.ToString()].Value.ToString(),
                        StudentPrefix = worksheet.Cells["F" + row.ToString()].Value == null ? null : worksheet.Cells["F" + row.ToString()].Value.ToString(),
                        StudentLine = worksheet.Cells["G" + row.ToString()].Value == null ? null : worksheet.Cells["G" + row.ToString()].Value.ToString(),
                        StudentEducationStatus = worksheet.Cells["H" + row.ToString()].Value == null ? null : worksheet.Cells["H" + row.ToString()].Value.ToString(),
                        StudentParentName = worksheet.Cells["I" + row.ToString()].Value == null ? null : worksheet.Cells["I" + row.ToString()].Value.ToString(),
                        StudentParentLastName = worksheet.Cells["J" + row.ToString()].Value == null ? null : worksheet.Cells["J" + row.ToString()].Value.ToString(),
                        StudentParentNumber = worksheet.Cells["K" + row.ToString()].Value == null ? null : worksheet.Cells["K" + row.ToString()].Value.ToString(),
                        StudentParentEmail = worksheet.Cells["L" + row.ToString()].Value == null ? null : worksheet.Cells["L" + row.ToString()].Value.ToString(),
                        StudentAddress = worksheet.Cells["M" + row.ToString()].Value == null ? null : worksheet.Cells["M" + row.ToString()].Value.ToString(),
                        StudentFacebook = worksheet.Cells["N" + row.ToString()].Value == null ? null : worksheet.Cells["N" + row.ToString()].Value.ToString(),
                        StudentlineParent = worksheet.Cells["O" + row.ToString()].Value == null ? null : worksheet.Cells["O" + row.ToString()].Value.ToString(),
                        FacultyId = worksheet.Cells["P" + row.ToString()].Value == null ? 0 : Convert.ToInt16(worksheet.Cells["P" + row.ToString()].Value),
                        BranchId = worksheet.Cells["Q" + row.ToString()].Value == null ? 0 : Convert.ToInt16(worksheet.Cells["Q" + row.ToString()].Value),
                        PositionId = worksheet.Cells["R" + row.ToString()].Value == null ? 0 : Convert.ToInt16(worksheet.Cells["R" + row.ToString()].Value),
                    });
                }
            }

            studentLists.RemoveAll(w => w.StudentId == null);
            ManageStudentRepository.SaveStudentList(_context, studentLists);

            ManageStudentViewModel model = new ManageStudentViewModel();
            model.modelCreatStudent = new CreateStudentModel();

            model.StudentList = ManageStudentRepository.GetStudentList(_context);

            return PartialView("_DatatableOfStudent", model);
        }

    }
}
