using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MedifyMe.Models
{
    public partial class MedifydbContext : DbContext
    {
        public MedifydbContext()
        {
        }

        public MedifydbContext(DbContextOptions<MedifydbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<Diagnosis> Diagnoses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.DrId).HasColumnName("Dr_ID");

                entity.Property(e => e.PatientId).HasColumnName("Patient_ID");
            });

            modelBuilder.Entity<Diagnosis>(entity =>
            {
                entity.ToTable("Diagnosis");

                entity.Property(e => e.DiagnosisId).HasColumnName("Diagnosis_Id");

                entity.Property(e => e.AppointmentId).HasColumnName("Appointment_ID");

                entity.Property(e => e.Diagnosis1)
                    .HasMaxLength(200)
                    .HasColumnName("Diagnosis")
                    .IsFixedLength();

                entity.Property(e => e.PatientId).HasColumnName("Patient_Id");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.NewUserId)
                    .HasName("PK__NewUser__0514143063597FE9");

                entity.ToTable("User");

                entity.Property(e => e.NewUserId).HasColumnName("NewUserID");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsFixedLength();

                entity.Property(e => e.Password)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
