using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class WorkCommitment
    {
        public WorkCommitment()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int WorkCommitmentId { get; set; }
        public string Commitment { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
