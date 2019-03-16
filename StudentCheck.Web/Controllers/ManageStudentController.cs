using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCheck.DataAccess;
using StudentCheck.DataAccess.Models;
using StudentCheck.DataAccess.ModelViews;
using StudentCheck.DataAccess.Repository;
using StudentCheck.Web.Models;

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
        public JsonResult UpdateProfessor(ManageStudentViewModel modelToUpdate)
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
        public JsonResult DeleteStudent(string ProfessorId)
        {
            bool result;

            try
            {
                ManageStudentRepository.DeleteStudent(_context, ProfessorId);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(result);
        }

        public PartialViewResult UpdateProfessorTable()
        {
            ManageStudentViewModel model = new ManageStudentViewModel();
            model.modelCreatStudent = new CreateStudentModel();

            model.StudentList = ManageStudentRepository.GetStudentList(_context);

            return PartialView("_DatatableOfStudent", model);
        }

    }
}
