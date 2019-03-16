using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Branch
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public int FacultyId { get; set; }
    }
}
