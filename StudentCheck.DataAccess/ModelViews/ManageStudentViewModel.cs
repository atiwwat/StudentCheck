using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCheck.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCheck.DataAccess.ModelViews
{
    public class ManageStudentViewModel
    {
        public CreateStudentModel modelCreatStudent { get; set; }
        public List<StudentList> StudentList { get; set; }
    }

    public class CreateStudentModel
    {
        public string StudentId { get; set; }
        public string StudentFirstname { get; set; }
        public string StudentLastname { get; set; }
        public string StudentEmail { get; set; }
        public string StudentTel { get; set; }
        public string StudentPrefix { get; set; }
        public string StudentLine { get; set; }
        //public string StudentImg { get; set; }
        public string StudentEducationStatus { get; set; }
        public string StudentParentName { get; set; }
        public string StudentParentLastName { get; set; }
        public string StudentParentNumber { get; set; }
        public string StudentParentEmail { get; set; }
        public string StudentAddress { get; set; }
        public string StudentFacebook { get; set; }
        public string StudentlineParent { get; set; }
        public int FacultyId { get; set; }
        public int BranchId { get; set; }
        //public int PositionId { get; set; }
        public IEnumerable<SelectListItem> FacultySelectList { get; set; }
        public IEnumerable<SelectListItem> BranchSelectList { get; set; }
    }
}
