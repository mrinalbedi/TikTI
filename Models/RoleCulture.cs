using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleCulture
    {
        public int RoleCultureId { get; set; }
        public int RoleOpportunity { get; set; }
        public int Culture { get; set; }

        public virtual Culture CultureNavigation { get; set; }
        public virtual RoleOpportunity RoleOpportunityNavigation { get; set; }
    }
}
