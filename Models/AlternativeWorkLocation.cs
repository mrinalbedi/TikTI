using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class AlternativeWorkLocation
    {
        public int WorkLocationId { get; set; }
        public byte[] City { get; set; }
        public byte[] Province { get; set; }
        public byte[] Postal { get; set; }
    }
}
