using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Certification
    {
        public Certification()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int CertificationId { get; set; }
        public string CertificationName { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
