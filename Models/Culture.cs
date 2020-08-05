using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class Culture
    {
        public Culture()
        {
            RoleCulture = new HashSet<RoleCulture>();
        }

        public int CultureId { get; set; }
        public string CultureName { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }

        public virtual ICollection<RoleCulture> RoleCulture { get; set; }
    }
}
