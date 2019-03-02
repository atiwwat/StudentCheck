using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Homework
    {
        public int HomeworkId { get; set; }
        public string Homeworkname { get; set; }
        public string Homeworkdescription { get; set; }
        public string Homeworkubmit { get; set; }
    }
}
