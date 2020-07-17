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

        public virtual DbSet<OrgRegistration> OrgRegistration { get; set; }

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
            modelBuilder.Entity<OrgRegistration>(entity =>
            {
                entity.HasKey(e => e.RegistrationId)
                    .HasName("PK__orgRegis__A3DB14152181B9D8");

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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
