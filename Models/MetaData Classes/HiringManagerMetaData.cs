using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Tikti.Models
{
    [ModelMetadataTypeAttribute(typeof(HiringManagerMetaData))]
    public partial class HiringManager : IValidatableObject
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
            if (FirstName == string.Empty || string.IsNullOrWhiteSpace(FirstName))
            {
                yield return new ValidationResult("First name cannot be blank or just empty spaces", new[] { nameof(FirstName) });
            }
            else
            {
                FirstName = FirstName.Trim();
                FirstName = Capitalize(FirstName);
            }
            if (LastName == string.Empty || string.IsNullOrWhiteSpace(LastName))
            {
                yield return new ValidationResult("Last name cannot be blank or just empty spaces", new[] { nameof(LastName) });
            }
            else
            {
                LastName = LastName.Trim();
                LastName = Capitalize(LastName);
            }
            if (Title == string.Empty || string.IsNullOrWhiteSpace(Title))
            {
                yield return new ValidationResult("Title of the hiring manager cannot be blank or just empty spaces", new[] { nameof(Title) });
            }
            else
            {
                Title = Title.Trim();
                Title = Capitalize(Title);
            }
            if (Department == string.Empty || string.IsNullOrWhiteSpace(Department))
            {
                yield return new ValidationResult("Organization name cannot be blank or just empty spaces", new[] { nameof(Department) });
            }
            else
            {
                Department = Department.Trim();
                Department = Capitalize(Department);
            }
            if (PhoneNumber == string.Empty || string.IsNullOrWhiteSpace(PhoneNumber))
            {
                yield return new ValidationResult("Phone number cannot be blank or just empty spaces", new[] { nameof(PhoneNumber) });
            }
            else
            {
                PhoneNumber = PhoneNumber.Trim();
               
            }
            yield return ValidationResult.Success;
        }
    }
    public class HiringManagerMetaData
    {
        [Required(ErrorMessage = "First name of the hiring manager is required")]
        [StringLength(30, ErrorMessage = "The First name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name of the hiring manager is required")]
        [StringLength(30, ErrorMessage = "The Last name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Role title of the hiring manager is required")]
        [StringLength(30, ErrorMessage = "The Title should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Title")]
        public string Title { get; set; }


        [Required(ErrorMessage = "Department name is required")]
        [StringLength(30, ErrorMessage = "The Department name should be minimum 2 characters and maximum 30 characters", MinimumLength = 2)]
        [Display(Name = "Department Name")]
        public string Department { get; set; }

        [Required(ErrorMessage = "Email address of the hiring manager is required")]
        [EmailAddress]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid E-mail Address")]

        public string Email { get; set; }

        [Required(ErrorMessage ="Phone number of the hiring manager is required")]
        [Display(Name = "Hiring Manager Phone Number")]
        [StringLength(15, ErrorMessage = "Phone number should be minimum 10 characters long", MinimumLength = 10)]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Please enter a valid phone number")]
        public string PhoneNumber { get; set; }
    }
}
