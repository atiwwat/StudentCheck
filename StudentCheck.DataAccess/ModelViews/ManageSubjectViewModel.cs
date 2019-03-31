using StudentCheck.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentCheck.DataAccess.ModelViews
{
   public class ManageSubjectViewModel
    {
        public CreateSubjectModel modelCreateSubject { get; set; }
        public List<Subjects> Subjects { get; set; }
    }
    public class CreateSubjectModel
    {
        public string SubjectId { get; set; }
        public string SubjectNameThai { get; set; }
        public string SubjectNameEng { get; set; }
        public int SubjectCredit { get; set; }
        public int FacultyID { get; set; }
    }
}
