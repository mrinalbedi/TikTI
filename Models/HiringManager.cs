using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class HiringManager
    {
        public HiringManager()
        {
            OrgRegisterHr = new HashSet<OrgRegisterHr>();
            RoleOpportunity = new HashSet<RoleOpportunity>();
        }

        public int HiringManagerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Department { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual ICollection<OrgRegisterHr> OrgRegisterHr { get; set; }
        public virtual ICollection<RoleOpportunity> RoleOpportunity { get; set; }
    }
}
