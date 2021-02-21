using System;
using System.Collections.Generic;

#nullable disable

namespace melodeon_api_v2.Models
{
    public partial class Log
    {
        public int LogsId { get; set; }
        public string LogMsg { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
