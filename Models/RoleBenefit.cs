using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleBenefit
    {
        public int RoleBenefitId { get; set; }
        public int RoleOpportunity { get; set; }
        public int Benefit { get; set; }

        public virtual Benefit BenefitNavigation { get; set; }
        public virtual RoleOpportunity RoleOpportunityNavigation { get; set; }
    }
}
