using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Currency
    {
        public Currency()
        {
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int CurrencyId { get; set; }
        public string Currency1 { get; set; }

        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
