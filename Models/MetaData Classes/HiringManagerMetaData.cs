using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(HiringManagerMetaData))]
    public partial class HiringManager
    { }
    public class HiringManagerMetaData
    {
        [Required]
        [StringLength(50, ErrorMessage = "The First name should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
        [Display(Name = "Contact Person First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Last name should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
        [Display(Name = "Contact Person Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The Title should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
        [Display(Name = "Contact Person Title")]
        public string Title { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "The Department should be minimum 5 characters and maximum 50 characters", MinimumLength = 5)]
        [Display(Name = "Department")]
        public string Department { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid E-mail Address")]

        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Contact Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}
