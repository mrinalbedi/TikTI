using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tikti.Models
{
    public class RoleCompetencyA_VM
    {
        public RoleCompetencyA_VM()
        {
            competencyA = new List<CompetencyA>();
        }
        public int RoleCompetencyAid { get; set; }
        public int RoleOpportunity { get; set; }

        public List<CompetencyA> competencyA { get; set; }
    }
}
