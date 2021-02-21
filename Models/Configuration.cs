using System;
using System.Collections.Generic;

#nullable disable

namespace melodeon_api_v2.Models
{
    public partial class Configuration
    {
        public Configuration()
        {
            Users = new HashSet<User>();
        }

        public int ConfigurationId { get; set; }
        public DateTime? ConfigurationLastLogin { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
