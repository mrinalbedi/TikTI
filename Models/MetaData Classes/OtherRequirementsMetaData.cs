using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(OtherRequirementsMetaData))]
    public partial class OtherRequirements
    { }
    public class OtherRequirementsMetaData
    {
        public int RequirementId { get; set; }
        public int RoleOpportunityId { get; set; }

        [Display(Name ="Sponsorship Required?")]
        public bool Sponsorship { get; set; }

        [Display(Name = "Overseas Travel Required?")]
        public bool OverseasTravel { get; set; }

        [Display(Name = "Drug Testing Required?")]
        public bool DrugTesting { get; set; }

        [Display(Name = "Applicant should be 18 years or more in age?")]
        public bool Age18 { get; set; }

        [Display(Name = "Travel Required?")]
        public bool Travel { get; set; }

        [Display(Name = "Percentage of travel required")]
        public string TravelDistance { get; set; }

        [Display(Name = "Drivers License Mandatory?")]
        public bool DriverLicense { get; set; }

         [Display(Name = "Province/State on license")]
        public string LicenseProvince { get; set; }

        [Display(Name = "Working on weekends Required?")]
        public bool WeekendWork { get; set; }

        [Display(Name = "Overnight shifts")]
        public bool Overnight { get; set; }
    }
}
