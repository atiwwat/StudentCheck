﻿using System;
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
        public int ScheduleClassId { get; set; }
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
        public int FacultyID { get; set; }
        public int BranchID { get; set; }
        public int NumberClass { get; set; }
        public int Checkname { get; set; }
        public int Satatus { get; set; }
    }
}
