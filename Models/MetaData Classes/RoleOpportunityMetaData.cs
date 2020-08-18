using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(RoleOpportunityMetaData))]
    public partial class RoleOpportunity : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(DesiredStartDate!=null)
            {
                if(DesiredStartDate<DateTime.Now)
                {
                    yield return new ValidationResult("The desired start date cannot be smaller than the current date", new[] { nameof(DesiredStartDate) });

                }
            }
            yield return ValidationResult.Success;
        }
    }
    public class RoleOpportunityMetaData
    {
        public int RoleOpportunityId { get; set; }

        [Display(Name ="Role Title")]
        public int AlternateTitleId { get; set; }

        //[Required(ErrorMessage ="The job description is a required field")]
        [Display(Name = "Job Description (pdf format only)")]
        public byte[] JobDescription { get; set; }



        [Display(Name ="Hiring Manager")]
        public string  HiringManager { get; set; }


        [Display(Name = "Desired Start Date:")]
        [Required(ErrorMessage ="The desired start date is required")]
        [DisplayFormat(DataFormatString= "{0: dddd d MMMM, yyyy}")]
        public DateTime DesiredStartDate { get; set; }


        [Display(Name = "Work Commitment:")]
        [Required]
        public int WorkCommitment { get; set; }

        [Display(Name = "Contract Duration(If Contract):")]
        public string ContractDuration { get; set; }

        [Display(Name = "Currency Selection:")]
        [Required]
        public int Currency { get; set; }

        [Required(ErrorMessage ="The salary field is required")]
        [Display(Name = "Salary For Position:")]
        public string Salary { get; set; }

        [Required(ErrorMessage ="The work location(City) is required")]
        [Display(Name = "Work Location(City)")]
        public string City { get; set; }

        [Required(ErrorMessage ="The Province/State is required")]
        [Display(Name = "Work Location(Province/State)")]
        public string Province { get; set; }

        [Required]
        [Display(Name = "Work Location(Postal Code)")]
        [RegularExpression(@"^[A-Za-z]\d[A-Za-z] ?\d[A-Za-z]\d$",ErrorMessage ="Please enter a valid Postal Code")]
        public string Postal { get; set; }

       
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

        [Display(Name = "Name of Extra Certification")]
        public string ExtraCertification { get; set; }

        [Required(ErrorMessage = "Please select the desired experience level for the role opportunity")]
        [Display(Name = "Desired Experience")]
        public int Experience { get; set; }

        [Required(ErrorMessage ="Please select the desired education level for the role opportunity")]
        [Display(Name = "Desired Education")]
        public int Education { get; set; }



        [Required]
        [Display(Name = "Other Requirements")]
        public int OtherRequirents { get; set; }
    }
}
