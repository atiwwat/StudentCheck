﻿using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class SubjectList
    {
        public int Seq { get; set; }
        public string ProfessorsId { get; set; }
        public string SubjectId { get; set; }
    }
}
