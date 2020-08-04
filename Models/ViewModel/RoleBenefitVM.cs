using System.Collections.Generic;

namespace Tikti.Models
{
    public class RoleBenefitVM
    {
        public RoleBenefitVM()
        {
            benefits = new List<Benefit>();
        }
        public int RoleBenefitId { get; set; }
        public int RoleOpportunity { get; set; }

        public List<Benefit> benefits { get; set; }
    }
}
