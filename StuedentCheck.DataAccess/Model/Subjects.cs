using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class Subjects
    {
        public string SubjectId { get; set; }
        public string SubjectNameThai { get; set; }
        public string SubjectNameEng { get; set; }
        public int SubjectCredit { get; set; }
        public int? FacultyId { get; set; }
    }
}
