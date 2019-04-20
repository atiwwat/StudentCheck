using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Register
    {
        public int RegisterId { get; set; }
        public string StudentId { get; set; }
        public int? ScheduleClassId { get; set; }
        public int AttendClass { get; set; }
        public int Absent { get; set; }
    }
}
