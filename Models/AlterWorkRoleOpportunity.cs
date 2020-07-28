using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class AlterWorkRoleOpportunity
    {
        public int AlterWorkRoleOpportunityId { get; set; }
        public int? RoleOpportunityId { get; set; }
        public int? WorkLocationId { get; set; }

        public virtual RoleOpportunity RoleOpportunity { get; set; }
        public virtual AlternativeWorkLocation WorkLocation { get; set; }
    }
}
