using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class AlternateTitles
    {
        public int AlternateTitleId { get; set; }
        public string Name { get; set; }
        public string SocCode { get; set; }

        public virtual SocCode SocCodeNavigation { get; set; }
    }
}
