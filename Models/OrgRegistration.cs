
=======
﻿using System.ComponentModel.DataAnnotations;

namespace Tikti.Models
{
    public partial class OrgRegistration
    {
        public int RegistrationId { get; set; }

        public string Email { get; set; }


     
        public string Pwd { get; set; }
        public string ConfirmPassword { get; set; }

        public string ContactFirstName { get; set; }
        public string ContactLastName { get; set; }
        public string ContactTitle { get; set; }
        public string Department { get; set; }
    }
}
