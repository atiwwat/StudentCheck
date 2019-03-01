using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class Register
    {
        public int RegisterId { get; set; }
        public string StudentId { get; set; }
        public int? ScheduleClassId { get; set; }
    }
}
