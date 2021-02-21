using System;
using System.Collections.Generic;

#nullable disable

namespace melodeon_api_v2.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserUsername { get; set; }
        public string UserPassword { get; set; }
        public int? UserConfigurationId { get; set; }

        public virtual Configuration UserConfiguration { get; set; }
    }
}
