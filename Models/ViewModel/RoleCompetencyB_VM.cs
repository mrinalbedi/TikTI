using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tikti.Models
{
    public class RoleCompetencyB_VM
    {
        public RoleCompetencyB_VM()
        {
            competencyB = new List<CompetencyB>();
        }
        public int RoleCompetencyBid { get; set; }
        public int RoleOpportunity { get; set; }

        public List<CompetencyB> competencyB { get; set; }
    }
}
