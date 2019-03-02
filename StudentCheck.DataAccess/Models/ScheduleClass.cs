using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class ScheduleClass
    {
        public int ScheduleClassId { get; set; }
        public string SubjectId { get; set; }
        public string ProfessorsId { get; set; }
        public string SubjectGroup { get; set; }
        public int DayId { get; set; }
        public string YearStudy { get; set; }
        public string Semester { get; set; }
        public string RoomId { get; set; }
        public TimeSpan? StudyHour { get; set; }
    }
}
