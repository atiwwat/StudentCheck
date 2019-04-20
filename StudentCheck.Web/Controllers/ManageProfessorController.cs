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

namespace StudentCheck.Web.Controllers
{
    public class ManageProfessorController : Controller
    {
        private readonly StudentCheckDbContext _context;

        public ManageProfessorController(StudentCheckDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ManageProfessorViewModel model = new ManageProfessorViewModel();
            model.modelCreatProfessor = new CreateProfessorModel();

            model.ProfessorList = ManageProfessorRepository.GetProfessorList(_context);
            model.modelCreatProfessor.PositionSelectList = ManageProfessorRepository.GetPositionList(_context).Select(s => new SelectListItem { Value = s.PositionId.ToString(), Text = s.PositionName });

            return View(model);
        }

        [HttpPost]
        public JsonResult SaveProfessor(ManageProfessorViewModel modelToSave)
        {
            bool result;

            try
            {
                ManageProfessorRepository.SaveProfessor(_context, modelToSave.modelCreatProfessor);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult UpdateProfessor(ManageProfessorViewModel modelToUpdate)
        {
            bool result;

            try
            {
                ManageProfessorRepository.UpdateProfessor(_context, modelToUpdate.modelCreatProfessor);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return Json(result);
        }

        [HttpPost]
        public JsonResult DeletePrefessor(string ProfessorId)
        {
            bool result;

            try
            {
                ManageProfessorRepository.DeleteProfessor(_context, ProfessorId);
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
            ManageProfessorViewModel model = new ManageProfessorViewModel();
            model.modelCreatProfessor = new CreateProfessorModel();

            model.ProfessorList = ManageProfessorRepository.GetProfessorList(_context);
            model.modelCreatProfessor.PositionSelectList = ManageProfessorRepository.GetPositionList(_context).Select(s => new SelectListItem { Value = s.PositionId.ToString(), Text = s.PositionName });

            return PartialView("_DatatableOfProfessor", model);
        }

    }
}
