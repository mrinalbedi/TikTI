using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(RoleOpportunityMetaData))]
    public partial class RoleOpportunity
    { }
    public class RoleOpportunityMetaData
    {
        public int RoleOpportunityId { get; set; }
        [Display(Name = "Job Description:")]
        public byte[] JobDescription { get; set; }

        [Display(Name ="Hiring Manager")]
        public string  HiringManager { get; set; }
        [Display(Name = "Desired Start Date:")]
        [Required]
        //[DisplayFormat(DataFormatString= "{0: dddd d MMMM, yyyy, h:mm:ss tt}")]
        public DateTime DesiredStartDate { get; set; }


        [Display(Name = "Work Commitment:")]
        [Required]
        public int WorkCommitment { get; set; }

        [Display(Name = "Contract Duration(If Applicable):")]
        public string ContractDuration { get; set; }

        [Display(Name = "Currency Selection:")]
        [Required]
        public int Currency { get; set; }

        [Required]
        [Display(Name = "Salary For Position:")]
        public string Salary { get; set; }

        [Required]
        [Display(Name = "Work Location(City)")]
        public string City { get; set; }

        [Required]
        [Display(Name = "Work Location(Province)")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Work Location(Postal Code)")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$",ErrorMessage ="Enter the valid Postal Code")]
        public string Postal { get; set; }

        [Required]
        [Display(Name = "TeleCommuting Role")]
        public bool TelecommutingRoles { get; set; }

        [Display(Name = "Organization Link")]
        public string Weblink { get; set; }

        [Required]
        [Display(Name = "Certification Required")]
        public int Certification { get; set; }

        [Required]
        [Display(Name = "Need Extra Certification?")]
        public bool ExtraCertificationRequired { get; set; }

        [Display(Name = "Names of Extra Certification")]
        public string ExtraCertification { get; set; }

        [Required]
        [Display(Name = "Desired Experience")]
        public int Experience { get; set; }

        [Required]
        [Display(Name = "Desired Education")]
        public int Education { get; set; }

        [Required]
        [Display(Name = "Other Requirements")]
        public int OtherRequirents { get; set; }
    }
}
