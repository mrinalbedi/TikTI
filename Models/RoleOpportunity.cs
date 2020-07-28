﻿using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleOpportunity
    {
        public RoleOpportunity()
        {
            RoleBenefit = new HashSet<RoleBenefit>();
            RoleCulture = new HashSet<RoleCulture>();
        }

        public int RoleOpportunityId { get; set; }
        public byte[] JobDescription { get; set; }
        public DateTime DesiredStartDate { get; set; }
        public int WorkCommitment { get; set; }
        public string ContractDuration { get; set; }
        public int Currency { get; set; }
        public string Salary { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postal { get; set; }
        public bool TelecommutingRoles { get; set; }
        public string Weblink { get; set; }
        public int Certification { get; set; }
        public bool ExtraCertificationRequired { get; set; }
        public string ExtraCertification { get; set; }
        public int Experience { get; set; }
        public int Education { get; set; }
        public int OtherRequirents { get; set; }
        public int? HiringManagerId { get; set; }

        public virtual Certification CertificationNavigation { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual Education EducationNavigation { get; set; }
        public virtual Experience ExperienceNavigation { get; set; }
        public virtual HiringManager HiringManager { get; set; }
        public virtual OtherRequirement OtherRequirentsNavigation { get; set; }
        public virtual WorkCommitment WorkCommitmentNavigation { get; set; }
        public virtual ICollection<RoleBenefit> RoleBenefit { get; set; }
        public virtual ICollection<RoleCulture> RoleCulture { get; set; }
    }
}
