using System.ComponentModel.DataAnnotations;

namespace Tikti.Models
{
    public partial class OrgRegistration
    {
        public int RegistrationId { get; set; }

        //--------------------
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "The password must be strong")]
        public string Pwd { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Pwd", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The First name should be of max 50 characters")]
        [Display(Name = "Contact First Name")]
        public string ContactFirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Last name should be of max 50 characters")]
        [Display(Name = "Contact Last Name")]
        public string ContactLastName { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Title should be of max 50 characters")]
        [Display(Name = "Contact Title")]
        public string ContactTitle { get; set; }


        [Required]
        [MaxLength(50, ErrorMessage = "The Department should be of max 50 characters")]
        [Display(Name = "Department")]
        public string Department { get; set; }
    }
}
