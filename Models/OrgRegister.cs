using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class OrgRegister
    {
        public OrgRegister()
        {
            OrgRegisterHr = new HashSet<OrgRegisterHr>();
        }

        public int RegistrationId { get; set; }
        public string OrganizationName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string ContactPhoneNumber { get; set; }
        public string Department { get; set; }

        public virtual ICollection<OrgRegisterHr> OrgRegisterHr { get; set; }
    }
}
