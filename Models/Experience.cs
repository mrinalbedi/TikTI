using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Experience
    {
        public Experience()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int ExperienceId { get; set; }
        public string Experience1 { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
