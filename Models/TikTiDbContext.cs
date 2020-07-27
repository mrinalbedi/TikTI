﻿using System;
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

        public virtual DbSet<AlternativeWorkLocation> AlternativeWorkLocation { get; set; }
        public virtual DbSet<Benefit> Benefit { get; set; }
        public virtual DbSet<Certification> Certification { get; set; }
        public virtual DbSet<Culture> Culture { get; set; }
        public virtual DbSet<Currency> Currency { get; set; }
        public virtual DbSet<Education> Education { get; set; }
        public virtual DbSet<Experience> Experience { get; set; }
        public virtual DbSet<OrgRegistration> OrgRegistration { get; set; }
        public virtual DbSet<OtherRequirement> OtherRequirement { get; set; }
        public virtual DbSet<RoleBenefit> RoleBenefit { get; set; }
        public virtual DbSet<RoleCulture> RoleCulture { get; set; }
        public virtual DbSet<RoleOpportunity> RoleOpportunity { get; set; }
        public virtual DbSet<RoleWorkLocation> RoleWorkLocation { get; set; }
        public virtual DbSet<WorkCommitment> WorkCommitment { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-7VEJTELJ;Database=TikTi;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlternativeWorkLocation>(entity =>
            {
                entity.HasKey(e => e.WorkLocationId)
                    .HasName("workLocation_pk");

                entity.ToTable("alternativeWorkLocation");

                entity.Property(e => e.WorkLocationId).HasColumnName("workLocationID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city")
                    .HasMaxLength(30);

                entity.Property(e => e.Postal)
                    .IsRequired()
                    .HasColumnName("postal")
                    .HasMaxLength(6);

                entity.Property(e => e.Province)
                    .IsRequired()
                    .HasColumnName("province")
                    .HasMaxLength(30);
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

            modelBuilder.Entity<Culture>(entity =>
            {
                entity.ToTable("culture");

                entity.Property(e => e.CultureId).HasColumnName("cultureID");

                entity.Property(e => e.CultureName)
                    .HasColumnName("cultureName")
                    .HasMaxLength(50)
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

            modelBuilder.Entity<OrgRegistration>(entity =>
            {
                entity.HasKey(e => e.RegistrationId)
                    .HasName("PK__orgRegis__A3DB1415782B61F8");

                entity.ToTable("orgRegistration");

                entity.Property(e => e.RegistrationId).HasColumnName("registrationID");

                entity.Property(e => e.ConfirmPassword)
                    .IsRequired()
                    .HasColumnName("confirmPassword");

                entity.Property(e => e.ContactFirstName)
                    .IsRequired()
                    .HasColumnName("contactFirstName")
                    .HasMaxLength(30);

                entity.Property(e => e.ContactLastName)
                    .IsRequired()
                    .HasColumnName("contactLastName")
                    .HasMaxLength(30);

                entity.Property(e => e.ContactPhoneNumber)
                    .IsRequired()
                    .HasColumnName("contactPhoneNumber")
                    .HasMaxLength(15);

                entity.Property(e => e.ContactTitle)
                    .IsRequired()
                    .HasColumnName("contactTitle")
                    .HasMaxLength(30);

                entity.Property(e => e.Department)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DifferentHr)
                    .HasColumnName("differentHR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.HrDepartment).HasMaxLength(30);

                entity.Property(e => e.HrFirstName).HasMaxLength(30);

                entity.Property(e => e.HrLastName).HasMaxLength(30);

                entity.Property(e => e.HrPhoneNumber).HasMaxLength(15);

                entity.Property(e => e.HrTitle).HasMaxLength(30);

                entity.Property(e => e.OrganizationName)
                    .IsRequired()
                    .HasColumnName("organizationName")
                    .HasMaxLength(30);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasColumnName("pwd");
            });

            modelBuilder.Entity<OtherRequirement>(entity =>
            {
                entity.ToTable("otherRequirement");

                entity.Property(e => e.OtherRequirementId).HasColumnName("otherRequirementID");

                entity.Property(e => e.OtherRequirementName)
                    .HasColumnName("otherRequirementName")
                    .HasMaxLength(255)
                    .IsUnicode(false);
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
                    .HasConstraintName("roleOpportunity_culture_fk");
            });

            modelBuilder.Entity<RoleOpportunity>(entity =>
            {
                entity.ToTable("roleOpportunity");

                entity.Property(e => e.RoleOpportunityId).HasColumnName("roleOpportunityID");

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

                entity.Property(e => e.JobDescription)
                    .IsRequired()
                    .HasColumnName("jobDescription");

                entity.Property(e => e.OtherRequirents).HasColumnName("otherRequirents");

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

                entity.HasOne(d => d.OtherRequirentsNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.OtherRequirents)
                    .HasConstraintName("otherRequirement_fk");

                entity.HasOne(d => d.WorkCommitmentNavigation)
                    .WithMany(p => p.RoleOpportunity)
                    .HasForeignKey(d => d.WorkCommitment)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("workCommitment_fk");
            });

            modelBuilder.Entity<RoleWorkLocation>(entity =>
            {
                entity.ToTable("role_WorkLocation");

                entity.Property(e => e.RoleWorkLocationId).HasColumnName("role_WorkLocationID");

                entity.Property(e => e.AlternativeWorkLocation).HasColumnName("alternativeWorkLocation");

                entity.Property(e => e.RoleOpportunity).HasColumnName("roleOpportunity");

                entity.HasOne(d => d.AlternativeWorkLocationNavigation)
                    .WithMany(p => p.RoleWorkLocation)
                    .HasForeignKey(d => d.AlternativeWorkLocation)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("alternativeWorkLocation_fk");

                entity.HasOne(d => d.RoleOpportunityNavigation)
                    .WithMany(p => p.RoleWorkLocation)
                    .HasForeignKey(d => d.RoleOpportunity)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("roleOpportunity_fk");
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
