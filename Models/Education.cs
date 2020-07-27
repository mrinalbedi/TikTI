using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Education
    {
        public Education()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int EducationId { get; set; }
        public string Education1 { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
