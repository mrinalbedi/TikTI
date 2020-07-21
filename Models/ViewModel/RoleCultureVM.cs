using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tikti.Models
{
    public class RoleCultureVM
    {
        public RoleCultureVM()
        {
            cultures = new List<Culture>();
        }
        public int RoleCultureId { get; set; }
        public int RoleOpportunity { get; set; }
        public List<Culture> cultures { get; set; }
    }
}
