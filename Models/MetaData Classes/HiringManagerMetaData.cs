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
        [StringLength(30, ErrorMessage = "The First name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Last name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The Title should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required]
        [StringLength(30, ErrorMessage = "The Department name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Department Name")]
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
