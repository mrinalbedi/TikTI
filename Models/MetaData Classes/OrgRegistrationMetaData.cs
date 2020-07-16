using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(OrgRegistrationMetaData))]
    public partial class OrgRegistration
    { }
        public class OrgRegistrationMetaData
        {
            public int RegistrationId { get; set; }

            //--------------------
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            [DataType(DataType.EmailAddress,ErrorMessage ="Please enter a valid E-mail Address")]

            public string Email { get; set; }


            [Required]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "The password should contain the following:"+"\n"+
            "An uppercase Letter,\n"+"A lowercase letter,\n" + "A special Character,\n" + " A number \n")]
            public string Pwd { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Pwd", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The First name should be minimum 5 characters and maximum 50 characters",MinimumLength =5)]
            [Display(Name = "Contact Person First Name")]
            public string ContactFirstName { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The Last name should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
            [Display(Name = "Contact Person Last Name")]
            public string ContactLastName { get; set; }

            [Required]
            [StringLength(50, ErrorMessage = "The Title should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
            [Display(Name = "Contact Person Title")]
            public string ContactTitle { get; set; }


            [Required]
            [StringLength(50, ErrorMessage = "The Department should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
            [Display(Name = "Department")]
            public string Department { get; set; }
    }
}
