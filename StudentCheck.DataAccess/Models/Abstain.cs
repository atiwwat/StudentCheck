using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Abstain
    {
        public int AbstainId { get; set; }
        public string AbstainWeek { get; set; }
        public string AbstainCause { get; set; }
        public string Abstaincompensate { get; set; }
        public string AbstainTime { get; set; }
        public string Abstainroom { get; set; }
        public int ScheduleClassId { get; set; }
    }
}
