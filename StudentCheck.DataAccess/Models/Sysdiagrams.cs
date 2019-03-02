using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Sysdiagrams
    {
        public int Seq { get; set; }
        public string Name { get; set; }
        public int PrincipalId { get; set; }
        public int DiagramId { get; set; }
        public int? Version { get; set; }
        public byte[] Definition { get; set; }
    }
}
