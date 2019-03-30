using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Professors
    {
        public string ProfessorsId { get; set; }
        public string ProfessorsFirstname { get; set; }
        public string ProfessorsLastname { get; set; }
        public string ProfessorsEmail { get; set; }
        public string ProfessorsTel { get; set; }
        public int PositionId { get; set; }
        public string ProfessorslineId { get; set; }
        public string ProfessorsFacebookId { get; set; }
        public int? FacultyIdP { get; set; }
        public int? BranchIdP { get; set; }
    }
}
