using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Model
{
    public partial class StudentList
    {
        public string StudentId { get; set; }
        public string StudentFirstname { get; set; }
        public string StudentLastname { get; set; }
        public string StudentEmail { get; set; }
        public string StudentTel { get; set; }
        public string StudentPrefix { get; set; }
        public string StudentLineStudent { get; set; }
        public string StudentImg { get; set; }
        public string StudentParentName { get; set; }
        public string StudentEducationStatus { get; set; }
        public string StudentAddressParent { get; set; }
        public string StudentParentNumber { get; set; }
        public string StudentParentEmail { get; set; }
        public string StudentAddress { get; set; }
        public string StudentFacebookParent { get; set; }
        public string StudentFacebook { get; set; }
        public string StudentlineParent { get; set; }
        public int? FacultyId { get; set; }
        public string ProfessorsId { get; set; }
        public string StudentFacultys { get; set; }
        public string StudentBranch { get; set; }
        public int? PositionId { get; set; }
    }
}
