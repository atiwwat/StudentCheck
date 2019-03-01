using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class Year
    {
        public string YearId { get; set; }
        public string Semester { get; set; }
        public string Education { get; set; }
        public string Sector { get; set; }
    }
}
