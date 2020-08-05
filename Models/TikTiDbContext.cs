using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Tikti.Models
{
    public partial class TikTiDbContext : DbContext
    {
        public TikTiDbContext()
        {
        }

        public TikTiDbContext(DbContextOptions<TikTiDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AlterWorkRoleOpportunity> AlterWorkRoleOpportunity { get; set; }
        public virtual DbSet<AlternateTitles> AlternateTitles { get; set; }
        public virtual DbSet<AlternativeWorkLocation> AlternativeWorkLocation { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<CompetencyA> CompetencyA { get; set; }
        public virtual DbSet<CompetencyB> CompetencyB { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<HiringManager> HiringManager { get; set; }
        public virtual DbSet<OrgRegister> OrgRegister { get; set; }
        public virtual DbSet<OrgRegisterHr> OrgRegisterHr { get; set; }
        public virtual DbSet<OtherRequirements> OtherRequirements { get; set; }
        public virtual DbSet<RoleBenefit> RoleBenefit { get; set; }
        public virtual DbSet<RoleCompetencyA> RoleCompetencyA { get; set; }
        public virtual DbSet<RoleCompetencyB> RoleCompetencyB { get; set; }
        public virtual DbSet<RoleCulture> RoleCulture { get; set; }
        public virtual DbSet<RoleOpportunity> RoleOpportunity { get; set; }
        public virtual DbSet<SocCode> SocCode { get; set; }
        public virtual DbSet<WorkCommitment> WorkCommitment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-370U335S\\SQLEXPRESS;Database=TikTi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlterWorkRoleOpportunity>(entity =>
            {
                entity.ToTable("alterWorkRoleOpportunity");

                entity.Property(e => e.AlterWorkRoleOpportunityId).HasColumnName("alterWorkRoleOpportunityId");

                entity.Property(e => e.RoleOpportunityId).HasColumnName("roleOpportunityID");

                entity.Property(e => e.WorkLocationId).HasColumnName("workLocationID");

                entity.HasOne(d => d.RoleOpportunity)
                    .WithMany(p => p.AlterWorkRoleOpportunity)
                    .HasForeignKey(d => d.RoleOpportunityId)
                    .HasConstraintName("FK__alterWork__roleO__6C190EBB");

                entity.HasOne(d => d.WorkLocation)
                    .WithMany(p => p.AlterWorkRoleOpportunity)
                    .HasForeignKey(d => d.WorkLocationId)
                    .HasConstraintName("FK__alterWork__workL__6D0D32F4");
            });

            modelBuilder.Entity<AlternateTitles>(entity =>
            {
                entity.HasKey(e => e.AlternateTitleId)
                    .HasName("PK__alternat__1FAF7D5FF304B1A3");

                entity.ToTable("alternateTitles");

                entity.Property(e => e.AlternateTitleId).HasColumnName("alternateTitleID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.SocCode)
                    .IsRequired()
                    .HasColumnName("socCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.SocCodeNavigation)
                    .WithMany(p => p.AlternateTitles)
                    .HasForeignKey(d => d.SocCode)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__alternate__socCo__571DF1D5");
            });

            modelBuilder.Entity<AlternativeWorkLocation>(entity =>
            {
                entity.HasKey(e => e.WorkLocationId)
                    .HasName("workLocation_pk");

                entity.ToTable("alternativeWorkLocation");

                entity.Property(e => e.WorkLocationId).HasColumnName("workLocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .IsUnicode(false);

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasColumnName("postal")
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.ToTable("benefit");

                entity.Property(e => e.BenefitId).HasColumnName("benefitID");

                entity.Property(e => e.BenefitName)
                    .HasColumnName("benefitName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");
            });

            modelBuilder.Entity<Certification>(entity =>
            {
                entity.ToTable("certification");

                entity.Property(e => e.CertificationId).HasColumnName("certificationID");

                entity.Property(e => e.CertificationName)
                    .HasColumnName("certificationName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CompetencyA>(entity =>
            {
                entity.HasKey(e => e.CompetencyId)
                    .HasName("competency_pk");

                entity.ToTable("competencyA");

                entity.Property(e => e.CompetencyId).HasColumnName("competencyID");

                entity.Property(e => e.CompetencyName)
                    .HasColumnName("competencyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");
            });

            modelBuilder.Entity<CompetencyB>(entity =>
            {
                entity.HasKey(e => e.CompetencyId)
                    .HasName("competencyB_pk");

                entity.ToTable("competencyB");

                entity.Property(e => e.CompetencyId).HasColumnName("competencyID");

                entity.Property(e => e.CompetencyName)
                    .HasColumnName("competencyName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");
            });

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("culture");

                entity.Property(e => e.CultureId).HasColumnName("cultureID");

                entity.Property(e => e.CultureName)
                    .HasColumnName("cultureName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .IsUnicode(false);

                entity.Property(e => e.IsSelected).HasColumnName("isSelected");
            });

            modelBuilder.Entity<Currency>(entity =>
            {
                entity.ToTable("currency");

                entity.Property(e => e.CurrencyId).HasColumnName("currencyID");

                entity.Property(e => e.Currency1)
                    .HasColumnName("currency")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Education>(entity =>
            {
                entity.ToTable("education");

                entity.Property(e => e.EducationId).HasColumnName("educationID");

                entity.Property(e => e.Education1)
                    .HasColumnName("education")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Experience>(entity =>
            {
                entity.ToTable("experience");

                entity.Property(e => e.ExperienceId).HasColumnName("experienceID");

                entity.Property(e => e.Experience1)
                    .HasColumnName("experience")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HiringManager>(entity =>
            {
                entity.Property(e => e.HiringManagerId).HasColumnName("hiringManagerID");

                entity.Property(e => e.Department).IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber).IsUnicode(false);

                entity.Property(e => e.Title).IsUnicode(false);
            });

            modelBuilder.Entity<OrgRegister>(entity =>
            {
                entity.HasKey(e => e.RegistrationId)
                    .HasName("PK__orgRegis__A3DB14153B2F4CE1");

                entity.ToTable("orgRegister");

                entity.Property(e => e.RegistrationId).HasColumnName("registrationID");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirmPassword")
                    .IsUnicode(false);

                entity.Property(e => e.ContactFirstName)
                    .IsRequired()
                    .HasColumnName("contactFirstName")
                    .IsUnicode(false);

                entity.Property(e => e.ContactLastName)
                    .IsRequired()
                    .HasColumnName("contactLastName")
                    .IsUnicode(false);

                entity.Property(e => e.ContactPhoneNumber)
                    .IsRequired()
                    .HasColumnName("contactPhoneNumber")
                    .IsUnicode(false);

                entity.Property(e => e.ContactTitle)
                    .IsRequired()
                    .HasColumnName("contactTitle")
                    .IsUnicode(false);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .IsUnicode(false);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnName("organizationName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrgRegisterHr>(entity =>
            {
                entity.ToTable("orgRegisterHR");

                entity.Property(e => e.OrgRegisterHrid).HasColumnName("orgRegisterHRID");

                entity.Property(e => e.HiringManagerId).HasColumnName("hiringManagerID");

                entity.Property(e => e.RegistrationId).HasColumnName("registrationID");

                entity.HasOne(d => d.HiringManager)
                    .WithMany(p => p.OrgRegisterHr)
                    .HasForeignKey(d => d.HiringManagerId)
                    .HasConstraintName("FK__orgRegist__hirin__3B75D760");

                entity.HasOne(d => d.Registration)
                    .WithMany(p => p.OrgRegisterHr)
                    .HasForeignKey(d => d.RegistrationId)
                    .HasConstraintName("FK__orgRegist__regis__3A81B327");
            });

            modelBuilder.Entity<OtherRequirements>(entity =>
            {
                entity.HasKey(e => e.RequirementId)
                    .HasName("PK__otherReq__60E29FF219C758FF");

                entity.ToTable("otherRequirements");

                entity.Property(e => e.RequirementId).HasColumnName("requirementID");

                entity.Property(e => e.Age18).HasColumnName("age18");

                entity.Property(e => e.DrugTesting).HasColumnName("drugTesting");

                entity.Property(e => e.LicenseProvince)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OverseasTravel).HasColumnName("overseasTravel");

                entity.Property(e => e.RoleOpportunityId).HasColumnName("roleOpportunityID");

                entity.Property(e => e.Sponsorship).HasColumnName("sponsorship");

                entity.Property(e => e.TravelDistance)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.RoleOpportunity)
                    .WithMany(p => p.OtherRequirements)
                    .HasForeignKey(d => d.RoleOpportunityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__otherRequ__roleO__778AC167");
            });

            modelBuilder.Entity<RoleBenefit>(entity =>
            {
                entity.ToTable("role_benefit");

                entity.Property(e => e.RoleBenefitId).HasColumnName("role_benefitID");

                entity.Property(e => e.Benefit).HasColumnName("benefit");

                entity.Property(e => e.RoleOpportunity).HasColumnName("roleOpportunity");

                entity.HasOne(d => d.BenefitNavigation)
                    .WithMany(p => p.RoleBenefit)
                    .HasForeignKey(d => d.Benefit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("benefit_fk");

                entity.HasOne(d => d.RoleOpportunityNavigation)
                    .WithMany(p => p.RoleBenefit)
                    .HasForeignKey(d => d.RoleOpportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleOpportunity_fkey");
            });

            modelBuilder.Entity<RoleCompetencyA>(entity =>
            {
                entity.ToTable("role_competencyA");

                entity.Property(e => e.RoleCompetencyAid).HasColumnName("role_competencyAID");

                entity.Property(e => e.ComptencyA).HasColumnName("comptencyA");

                entity.Property(e => e.RoleOpportunity).HasColumnName("roleOpportunity");

                entity.HasOne(d => d.ComptencyANavigation)
                    .WithMany(p => p.RoleCompetencyA)
                    .HasForeignKey(d => d.ComptencyA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competencyA_fk");

                entity.HasOne(d => d.RoleOpportunityNavigation)
                    .WithMany(p => p.RoleCompetencyA)
                    .HasForeignKey(d => d.RoleOpportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleOpportunity_frgnkey");
            });

            modelBuilder.Entity<RoleCompetencyB>(entity =>
            {
                entity.ToTable("role_competencyB");

                entity.Property(e => e.RoleCompetencyBid).HasColumnName("role_competencyBID");

                entity.Property(e => e.ComptencyB).HasColumnName("comptencyB");

                entity.Property(e => e.RoleOpportunity).HasColumnName("roleOpportunity");

                entity.HasOne(d => d.ComptencyBNavigation)
                    .WithMany(p => p.RoleCompetencyB)
                    .HasForeignKey(d => d.ComptencyB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("competencyB_fk");

                entity.HasOne(d => d.RoleOpportunityNavigation)
                    .WithMany(p => p.RoleCompetencyB)
                    .HasForeignKey(d => d.RoleOpportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleOpportunity_frnkey");
            });

            modelBuilder.Entity<RoleCulture>(entity =>
            {
                entity.ToTable("role_culture");

                entity.Property(e => e.RoleCultureId).HasColumnName("role_cultureID");

                entity.Property(e => e.Culture).HasColumnName("culture");

                entity.Property(e => e.RoleOpportunity).HasColumnName("roleOpportunity");

                entity.HasOne(d => d.CultureNavigation)
                    .WithMany(p => p.RoleCulture)
                    .HasForeignKey(d => d.Culture)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("culture_fk");

                entity.HasOne(d => d.RoleOpportunityNavigation)
                    .WithMany(p => p.RoleCulture)
                    .HasForeignKey(d => d.RoleOpportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleOpportunity_fk");
            });

            modelBuilder.Entity<RoleOpportunity>(entity =>
            {
                entity.ToTable("roleOpportunity");

                entity.Property(e => e.RoleOpportunityId).HasColumnName("roleOpportunityID");

                entity.Property(e => e.AlternateTitleId).HasColumnName("alternateTitleID");

                entity.Property(e => e.Certification).HasColumnName("certification");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ContractDuration)
                    .HasColumnName("contractDuration")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Currency).HasColumnName("currency");

                entity.Property(e => e.DesiredStartDate)
                    .HasColumnName("desiredStartDate")
                    .HasColumnType("date");

                entity.Property(e => e.Education).HasColumnName("education");

                entity.Property(e => e.Experience).HasColumnName("experience");

                entity.Property(e => e.ExtraCertification)
                    .HasColumnName("extraCertification")
                    .IsUnicode(false);

                entity.Property(e => e.ExtraCertificationRequired).HasColumnName("extraCertificationRequired");

                entity.Property(e => e.HiringManagerId).HasColumnName("hiringManagerID");

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasColumnName("jobDescription");

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasColumnName("postal")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Salary)
                    .IsRequired()
                    .HasColumnName("salary")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.TelecommutingRoles).HasColumnName("telecommutingRoles");

                entity.Property(e => e.Weblink)
                    .HasColumnName("weblink")
                    .IsUnicode(false);

                entity.Property(e => e.WorkCommitment).HasColumnName("workCommitment");

                entity.HasOne(d => d.AlternateTitle)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.AlternateTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alternateTitle_fk");

                entity.HasOne(d => d.CertificationNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.Certification)
                    .HasConstraintName("certification_fk");

                entity.HasOne(d => d.CurrencyNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.Currency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("currency_fk");

                entity.HasOne(d => d.EducationNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.Education)
                    .HasConstraintName("education_fk");

                entity.HasOne(d => d.ExperienceNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.Experience)
                    .HasConstraintName("experience_fk");

                entity.HasOne(d => d.HiringManager)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.HiringManagerId)
                    .HasConstraintName("FK__roleOppor__hirin__5AEE82B9");

                entity.HasOne(d => d.WorkCommitmentNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.WorkCommitment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workCommitment_fk");
            });

            modelBuilder.Entity<SocCode>(entity =>
            {
                entity.HasKey(e => e.SocCode1)
                    .HasName("socCode_pk");

                entity.ToTable("socCode");

                entity.Property(e => e.SocCode1)
                    .HasColumnName("socCode")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<WorkCommitment>(entity =>
            {
                entity.ToTable("workCommitment");

                entity.Property(e => e.WorkCommitmentId).HasColumnName("workCommitmentID");

                entity.Property(e => e.Commitment)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
