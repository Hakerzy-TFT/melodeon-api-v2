using System;
using System.Collections.Generic;

#nullable disable

namespace melodeon_api_v2.Models
{
    public partial class ServiceStatus
    {
        public int ServiceStatusId { get; set; }
        public bool WebApp { get; set; }
        public bool Api { get; set; }
        public bool Db { get; set; }
    }
}
