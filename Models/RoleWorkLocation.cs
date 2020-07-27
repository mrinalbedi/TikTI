using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleWorkLocation
    {
        public int RoleWorkLocationId { get; set; }
        public int RoleOpportunity { get; set; }
        public int AlternativeWorkLocation { get; set; }

        public virtual AlternativeWorkLocation AlternativeWorkLocationNavigation { get; set; }
        public virtual RoleOpportunity RoleOpportunityNavigation { get; set; }
    }
}
