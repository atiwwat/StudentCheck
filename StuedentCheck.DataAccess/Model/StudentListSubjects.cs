using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class StudentListSubjects
    {
        public int Seq { get; set; }
        public string StudentId { get; set; }
        public string SubjectId { get; set; }
    }
}
