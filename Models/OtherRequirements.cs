using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class OtherRequirements
    {
        public int RequirementId { get; set; }
        public int RoleOpportunityId { get; set; }
        public bool Sponsorship { get; set; }
        public bool OverseasTravel { get; set; }
        public bool DrugTesting { get; set; }
        public bool Age18 { get; set; }
        public bool Travel { get; set; }
        public string TravelDistance { get; set; }
        public bool DriverLicense { get; set; }
        public string LicenseProvince { get; set; }
        public bool WeekendWork { get; set; }
        public bool Overnight { get; set; }

        public virtual RoleOpportunity RoleOpportunity { get; set; }
    }
}
