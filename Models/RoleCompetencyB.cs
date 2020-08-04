using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleCompetencyB
    {
        public int RoleCompetencyBid { get; set; }
        public int RoleOpportunity { get; set; }
        public int ComptencyB { get; set; }

        public virtual CompetencyA ComptencyBNavigation { get; set; }
        public virtual RoleOpportunity RoleOpportunityNavigation { get; set; }
    }
}
