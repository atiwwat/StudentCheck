using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class Checkname
    {
        public int ChecknameId { get; set; }
        public string Checknameinout { get; set; }
        public string Checknamestatus { get; set; }
        public int ScheduleClassId { get; set; }
    }
}
