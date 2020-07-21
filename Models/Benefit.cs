using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Benefit
    {
        public Benefit()
        {
            RoleBenefit = new HashSet<RoleBenefit>();
        }

        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public bool IsSelected { get; set; }

        public virtual ICollection<RoleBenefit> RoleBenefit { get; set; }
    }
}
