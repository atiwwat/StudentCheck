using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Admin
    {
        public int AdminId { get; set; }
        public string AdminUsername { get; set; }
        public string AdminPassword { get; set; }
        public string AdminFirstname { get; set; }
        public string AdminLastname { get; set; }
        public string AdminTel { get; set; }
        public string Adminemail { get; set; }
    }
}
