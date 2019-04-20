using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCheck.DataAccess.ModelViews
{
    public class ReportViewModel
    {
        public List<CreateReport> modelReport { get; set; }
        public List<PageReport> modelPageReport { get; set; }
    }

    public class CreateReport
    {
        public int ScheduleClassId { get; set; }
        public string SubjectId { get; set; }
        public string SubjectGroup { get; set; }
        public string SubjectNameThai { get; set; }
        public int SubjectCredit { get; set; }
        public string Day { get; set; }
    }

    public class PageReport
    {
        public string ScheduleClassId { get; set; }
        public string SubjectId { get; set; }
        public string SubjectGroup { get; set; }
        public string SubjectNameThai { get; set; }
        public int SubjectCredit { get; set; }
        public string Day { get; set; }
        public string ProfessorsId { get; set; }
        public string ProfessorsFirstname { get; set; }
        public string ProfessorsLastname { get; set; }
        public string ProfessorsTel { get; set; }
        public string ProfessorsEmail { get; set; }
        public string StudentId { get; set; }
        public string StudentFirstname { get; set; }
        public string StudentLastname { get; set; }
        public string StudentPrefix { get; set; }
        public string FacultyProfessors { get; set; }
        public string BranchProfessors { get; set; }
        public string FacultyName { get; set; }
        public string BranchName { get; set; }
        public int AttendClass { get; set; }
        public int Absent { get; set; }
        public int Satatus { get; set; }
        public string YearStudy { get; set; }
        public string Semester { get; set; }
    }
}
