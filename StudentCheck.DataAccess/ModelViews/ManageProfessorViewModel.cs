using Microsoft.AspNetCore.Mvc.Rendering;
using StudentCheck.DataAccess.Models;
using System;
using System.Collections.Generic;
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
        public string ProfessorsId { get; set; }
        public string ProfessorsFirstname { get; set; }
        public string ProfessorsLastname { get; set; }
        public string ProfessorsEmail { get; set; }
        public string ProfessorsTel { get; set; }
        public string ProfessorsFacultys { get; set; }
        public string ProfessorsBranch { get; set; }
        public int PositionId { get; set; }
        public string ProfessorslineId { get; set; }
        public string ProfessorsFacebookId { get; set; }
        public IEnumerable<SelectListItem> PositionSelectList { get; set; }
    }
}
