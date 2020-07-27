using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class OrgRegisterHr
    {
        public int OrgRegisterHrid { get; set; }
        public int? RegistrationId { get; set; }
        public int? HiringManagerId { get; set; }

        public virtual HiringManager HiringManager { get; set; }
        public virtual OrgRegister Registration { get; set; }
    }
}
