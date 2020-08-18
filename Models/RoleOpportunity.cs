using System;
using System.Collections.Generic;

namespace Tikti.Models
{
    public partial class RoleOpportunity
    {
        public RoleOpportunity()
        {
            AlterWorkRoleOpportunity = new HashSet<AlterWorkRoleOpportunity>();
            OtherRequirements = new HashSet<OtherRequirements>();
            RoleBenefit = new HashSet<RoleBenefit>();
            RoleCompetencyA = new HashSet<RoleCompetencyA>();
            RoleCompetencyB = new HashSet<RoleCompetencyB>();
            RoleCulture = new HashSet<RoleCulture>();
        }

        public int RoleOpportunityId { get; set; }
        public int RegistrationId { get; set; }
        public int AlternateTitleId { get; set; }
        public byte[] JobDescription { get; set; }
        public int? HiringManagerId { get; set; }
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

        public virtual AlternateTitles AlternateTitle { get; set; }
        public virtual Certification CertificationNavigation { get; set; }
        public virtual Currency CurrencyNavigation { get; set; }
        public virtual Education EducationNavigation { get; set; }
        public virtual Experience ExperienceNavigation { get; set; }
        public virtual HiringManager HiringManager { get; set; }
        public virtual OrgRegister Registration { get; set; }
        public virtual WorkCommitment WorkCommitmentNavigation { get; set; }
        public virtual ICollection<AlterWorkRoleOpportunity> AlterWorkRoleOpportunity { get; set; }
        public virtual ICollection<OtherRequirements> OtherRequirements { get; set; }
        public virtual ICollection<RoleBenefit> RoleBenefit { get; set; }
        public virtual ICollection<RoleCompetencyA> RoleCompetencyA { get; set; }
        public virtual ICollection<RoleCompetencyB> RoleCompetencyB { get; set; }
        public virtual ICollection<RoleCulture> RoleCulture { get; set; }
    }
}
