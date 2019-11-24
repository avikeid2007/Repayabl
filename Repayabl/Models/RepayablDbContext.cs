﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repayabl.Models
{
    public partial class RepayablDbContext : DbContext
    {
        public RepayablDbContext()
        {
        }

        public RepayablDbContext(DbContextOptions<RepayablDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<FamilyDetails> FamilyDetails { get; set; }
        public virtual DbSet<Properties> Properties { get; set; }
        public virtual DbSet<RentTransactions> RentTransactions { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<TenantDocuments> TenantDocuments { get; set; }
        public virtual DbSet<TenantOutstandings> TenantOutstandings { get; set; }
        public virtual DbSet<Tenants> Tenants { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

                optionsBuilder.UseSqlServer("Server=(local);Database=Repayabl;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FamilyDetails>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Relationship)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.FamilyDetails)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_79");
            });

            modelBuilder.Entity<Properties>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).IsRequired();

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remarks)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RentTransactions>(entity =>
            {
                entity.HasIndex(e => e.PaidBy)
                    .HasName("fkIdx_100");

                entity.HasIndex(e => e.RoomId)
                    .HasName("fkIdx_103");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BillDate).HasColumnType("datetime");

                entity.Property(e => e.BillNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ElectricityBillAmount).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.PaidAmount).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.RentAmount).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.TotalAmount).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.PaidByNavigation)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.PaidBy)
                    .HasConstraintName("FK_100");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.RentTransactions)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_103");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasIndex(e => e.LastPaidBillId)
                    .HasName("fkIdx_134");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ElectRate).HasColumnType("numeric(2, 2)");

                entity.Property(e => e.LastBillPaidDate).HasColumnType("datetime");

                entity.Property(e => e.MonthlyRent).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.RoomNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.CurrentTenant)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CurrentTenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_52");

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_37");
            });

            modelBuilder.Entity<TenantDocuments>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.FileExtension)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MimeType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Payload).IsRequired();

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantDocuments)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_117");
            });

            modelBuilder.Entity<TenantOutstandings>(entity =>
            {
                entity.HasIndex(e => e.TenantId)
                    .HasName("fkIdx_144");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.TotalAdvance).HasColumnType("numeric(8, 2)");

                entity.Property(e => e.TotalPending).HasColumnType("numeric(8, 2)");

                entity.HasOne(d => d.Tenant)
                    .WithMany(p => p.TenantOutstandings)
                    .HasForeignKey(d => d.TenantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_144");
            });

            modelBuilder.Entity<Tenants>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.PropertyId)
                    .HasName("fkIdx_122");

                entity.HasIndex(e => e.RoomId)
                    .HasName("fkIdx_28");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Property)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PropertyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_122");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_28");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
