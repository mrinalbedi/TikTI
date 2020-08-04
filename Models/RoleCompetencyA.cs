using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleCompetencyA
    {
        public int RoleCompetencyAid { get; set; }
        public int RoleOpportunity { get; set; }
        public int ComptencyA { get; set; }

        public virtual CompetencyA ComptencyANavigation { get; set; }
        public virtual RoleOpportunity RoleOpportunityNavigation { get; set; }
    }
}
