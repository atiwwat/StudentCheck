using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class StudentList
    {
        public string StudentId { get; set; }
        public string StudentFirstname { get; set; }
        public string StudentLastname { get; set; }
        public string StudentEmail { get; set; }
        public string StudentTel { get; set; }
        public string StudentPrefix { get; set; }
        public string StudentLine { get; set; }
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
        public int PositionId { get; set; }
    }
}
