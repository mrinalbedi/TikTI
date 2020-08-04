using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class CompetencyA
    {
        public CompetencyA()
        {
            RoleCompetencyA = new HashSet<RoleCompetencyA>();
            RoleCompetencyB = new HashSet<RoleCompetencyB>();
        }

        public int CompetencyId { get; set; }
        public string CompetencyName { get; set; }
        public bool IsSelected { get; set; }

        public virtual ICollection<RoleCompetencyA> RoleCompetencyA { get; set; }
        public virtual ICollection<RoleCompetencyB> RoleCompetencyB { get; set; }
    }
}
