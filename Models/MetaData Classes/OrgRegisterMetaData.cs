using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;


namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(OrgRegisterMetaData))]
    public partial class OrgRegister : IValidatableObject
    {
        public static string Capitalize(string input)
        {
            if (input == null)
            {
                return string.Empty;
            }
            string x = input.ToLower().Trim();
            x = Regex.Replace(x, @"(^\w)|(\s\w)", m => m.Value.ToUpper());

            return x;
        }
       
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(OrganizationName==string.Empty||string.IsNullOrWhiteSpace(OrganizationName))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(OrganizationName) });
            }
            else
            {
                OrganizationName = OrganizationName.Trim();
                OrganizationName = Capitalize(OrganizationName);
            }
            if (ContactPhoneNumber == string.Empty || string.IsNullOrWhiteSpace(ContactPhoneNumber))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(ContactPhoneNumber) });
            }
            else
            {
                ContactPhoneNumber = ContactPhoneNumber.Trim();
                
            }

            if (ContactFirstName == string.Empty || string.IsNullOrWhiteSpace(ContactFirstName))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(ContactFirstName) });
            }
            else
            {
                ContactFirstName = ContactFirstName.Trim();
                ContactFirstName = Capitalize(ContactFirstName);
            }
            if (ContactLastName == string.Empty || string.IsNullOrWhiteSpace(ContactLastName))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(ContactLastName) });
            }
            else
            {
                ContactLastName = ContactLastName.Trim();
                ContactLastName = Capitalize(ContactLastName);
            }
            if (Department == string.Empty || string.IsNullOrWhiteSpace(Department))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(ContactLastName) });
            }
            else
            {
                Department = Department.Trim();
                Department = Capitalize(Department);
            }
            if (ContactTitle == string.Empty || string.IsNullOrWhiteSpace(ContactTitle))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(ContactLastName) });
            }
            else
            {
                ContactTitle = ContactTitle.Trim();
                ContactTitle = Capitalize(ContactTitle);
            }
            
            yield return ValidationResult.Success;
        }
    }
    public class OrgRegisterMetaData
    {

        public int RegistrationId { get; set; }

        //--------------------

        [Required(ErrorMessage ="The name of the Organization is required")]
        [StringLength(50, ErrorMessage = "Organization name should be of maximum 50 characters", MinimumLength = 2)]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Required(ErrorMessage ="The Email address is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid E-mail Address")]

        public string Email { get; set; }

        [Required(ErrorMessage ="The Contact Phone Number is required")]
        [Phone]
        [StringLength(15,ErrorMessage ="Phone number should be minimum 10 characters long",MinimumLength =10)]
        [Display(Name = "Contact Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]

        public string ContactPhoneNumber { get; set; }


        [Required(ErrorMessage ="The Password field is Required")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "The password should contain the following:" + "\n" +
        "An uppercase Letter,\n" + "A lowercase letter,\n" + "A special Character,\n" + " and A number \n")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Confirm Password field is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The Password and Confirm Password fields do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = " The Contact person First Name is required")]
        [StringLength(30, ErrorMessage = "The First name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Contact Person First Name")]
        public string ContactFirstName { get; set; }

        [Required(ErrorMessage = "The Contact person Last Name is required")]
        [StringLength(30, ErrorMessage = "The Last name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Contact Person Last Name")]
        public string ContactLastName { get; set; }

        [Required(ErrorMessage = "The Job Title of the Contact person is required")]
        [StringLength(30, ErrorMessage = "The Title should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Contact Person Title")]
        public string ContactTitle { get; set; }


        [Required(ErrorMessage = "The Department Name is Required")]
        [StringLength(30, ErrorMessage = "The Department name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Department Name")]
        public string Department { get; set; }

        
    }
}
