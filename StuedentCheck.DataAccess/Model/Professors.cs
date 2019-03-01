using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class Professors
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
        public int? FacultyId { get; set; }
    }
}
