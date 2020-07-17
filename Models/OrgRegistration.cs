using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class OrgRegistration
    {
        public int RegistrationId { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public string Pwd { get; set; }
        public string ConfirmPassword { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Department { get; set; }
        public bool DifferentHr { get; set; }
        public string HrFirstName { get; set; }
        public string HrLastName { get; set; }
        public string HrTitle { get; set; }
        public string HrDepartment { get; set; }
        public string HrPhoneNumber { get; set; }
        public string HrEmail { get; set; }
    }
}
