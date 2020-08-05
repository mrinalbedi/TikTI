using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class CompetencyB
    {
        public int CompetencyId { get; set; }
        public string CompetencyName { get; set; }
        public string Description { get; set; }
        public bool IsSelected { get; set; }
    }
}
