using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class OtherRequirement
    {
        public OtherRequirement()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int OtherRequirementId { get; set; }
        public string OtherRequirementName { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
