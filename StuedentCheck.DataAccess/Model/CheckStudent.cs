using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
{
    public partial class CheckStudent
    {
        public int Seq { get; set; }
        public int IdQr { get; set; }
        public string StudentId { get; set; }
        public int StatusId { get; set; }
    }
}
