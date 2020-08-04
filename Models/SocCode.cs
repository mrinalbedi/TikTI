using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class SocCode
    {
        public SocCode()
        {
            AlternateTitles = new HashSet<AlternateTitles>();
        }

        public string SocCode1 { get; set; }
        public string Description { get; set; }

        public virtual ICollection<AlternateTitles> AlternateTitles { get; set; }
    }
}
