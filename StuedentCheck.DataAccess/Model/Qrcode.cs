using System;
using System.Collections.Generic;

namespace StuedentCheck.DataAccess.Model
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
