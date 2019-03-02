using System;
using System.Collections.Generic;

namespace StudentCheck.DataAccess.Models
{
    public partial class Qrcode
    {
        public int IdQr { get; set; }
        public string QrcodeId { get; set; }
        public int ScheduleClassId { get; set; }
        public int NumberClass { get; set; }
        public DateTime? GenTime { get; set; }
    }
}
