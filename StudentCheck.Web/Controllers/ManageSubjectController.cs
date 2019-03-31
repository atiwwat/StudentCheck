using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StudentCheck.DataAccess;
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

    }
}

    