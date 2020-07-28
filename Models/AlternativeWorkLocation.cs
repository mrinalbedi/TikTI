using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class AlternativeWorkLocation
    {
        public AlternativeWorkLocation()
        {
            AlterWorkRoleOpportunity = new HashSet<AlterWorkRoleOpportunity>();
        }

        public int WorkLocationId { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }

        public virtual ICollection<AlterWorkRoleOpportunity> AlterWorkRoleOpportunity { get; set; }
    }
}
