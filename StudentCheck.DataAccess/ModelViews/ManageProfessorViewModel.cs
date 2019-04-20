using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCheck.DataAccess.Models;
//using StudentCheck.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentCheck.DataAccess.ModelViews
{
    public class ManageProfessorViewModel
    {
        public CreateProfessorModel modelCreatProfessor { get; set; }

        public List<Professors> ProfessorList { get; set; }
    }

    public class CreateProfessorModel
    {
        [Required]
        public string ProfessorsId { get; set; }
        [Required]
        public string ProfessorsFirstname { get; set; }
        [Required]
        public string ProfessorsLastname { get; set; }
        [Required]
        public string ProfessorsEmail { get; set; }
        [Required]
        public string ProfessorsTel { get; set; }
        [Required]
        public int PositionId { get; set; }
        public string ProfessorslineId { get; set; }
        public string ProfessorsFacebookId { get; set; }
        public int FacultyID_P { get; set; }
        public int BarnchID_P { get; set; }
        public IEnumerable<SelectListItem> FacultyProfessorsSelectList { get; set; }
        public IEnumerable<SelectListItem> BarnchProfessorsSelectList { get; set; }
        public IEnumerable<SelectListItem> PositionSelectList { get; set; }
    }
}
