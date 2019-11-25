﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repayabl.Models;

namespace Repayabl.Migrations
{
    [DbContext(typeof(RepayablDbContext))]
    [Migration("20191124185318_CreateDb")]
    partial class CreateDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Repayabl.Models.FamilyDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relationship")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("FamilyDetails");
                });

            modelBuilder.Entity("Repayabl.Models.Property", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FloorCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Remarks")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("Repayabl.Models.RentTransaction", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BillDate")
                        .HasColumnType("datetime");

                    b.Property<int>("BillMonth")
                        .HasColumnType("int");

                    b.Property<string>("BillNo")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("BillYear")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CurrentReading")
                        .HasColumnType("int");

                    b.Property<decimal>("ElectricityBillAmount")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<bool?>("IsPaid")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("PaidAmount")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<Guid?>("PaidBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime");

                    b.Property<int>("PreviousReading")
                        .HasColumnType("int");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<Guid>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<int>("TotalPaybleMonth")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaidBy")
                        .HasName("fkIdx_100");

                    b.HasIndex("RoomId")
                        .HasName("fkIdx_103");

                    b.ToTable("RentTransactions");
                });

            modelBuilder.Entity("Repayabl.Models.Room", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CurrentTenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("ElectRate")
                        .HasColumnType("numeric(2, 2)");

                    b.Property<DateTime?>("LastBillPaidDate")
                        .HasColumnType("datetime");

                    b.Property<Guid?>("LastPaidBillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MonthlyRent")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<Guid>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("RoomFloorNo")
                        .HasColumnType("int");

                    b.Property<string>("RoomNo")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("CurrentTenantId");

                    b.HasIndex("LastPaidBillId")
                        .HasName("fkIdx_134");

                    b.HasIndex("PropertyId");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Repayabl.Models.Tenant", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime");

                    b.Property<string>("City")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FamilyMamberCount")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("varchar(10)")
                        .HasMaxLength(10)
                        .IsUnicode(false);

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int?>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tenants");
                });

            modelBuilder.Entity("Repayabl.Models.TenantDocument", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Payload")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("TenantId");

                    b.ToTable("TenantDocuments");
                });

            modelBuilder.Entity("Repayabl.Models.TenantOutstanding", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TenantId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("TotalAdvance")
                        .HasColumnType("numeric(8, 2)");

                    b.Property<decimal?>("TotalPending")
                        .HasColumnType("numeric(8, 2)");

                    b.HasKey("Id");

                    b.HasIndex("TenantId")
                        .HasName("fkIdx_144");

                    b.ToTable("TenantOutstandings");
                });

            modelBuilder.Entity("Repayabl.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("getdate()");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAuth")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modifed")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Otp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<Guid?>("PropertyId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("RoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("PropertyId")
                        .HasName("fkIdx_122");

                    b.HasIndex("RoomId")
                        .HasName("fkIdx_28");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Repayabl.Models.FamilyDetail", b =>
                {
                    b.HasOne("Repayabl.Models.Tenant", "Tenant")
                        .WithMany("FamilyDetails")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_79")
                        .IsRequired();
                });

            modelBuilder.Entity("Repayabl.Models.RentTransaction", b =>
                {
                    b.HasOne("Repayabl.Models.Tenant", "PaidByNavigation")
                        .WithMany("RentTransactions")
                        .HasForeignKey("PaidBy")
                        .HasConstraintName("FK_100");

                    b.HasOne("Repayabl.Models.Room", "Room")
                        .WithMany("RentTransactions")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_103")
                        .IsRequired();
                });

            modelBuilder.Entity("Repayabl.Models.Room", b =>
                {
                    b.HasOne("Repayabl.Models.Tenant", "CurrentTenant")
                        .WithMany("Rooms")
                        .HasForeignKey("CurrentTenantId")
                        .HasConstraintName("FK_52")
                        .IsRequired();

                    b.HasOne("Repayabl.Models.Property", "Property")
                        .WithMany("Rooms")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_37")
                        .IsRequired();
                });

            modelBuilder.Entity("Repayabl.Models.TenantDocument", b =>
                {
                    b.HasOne("Repayabl.Models.Tenant", "Tenant")
                        .WithMany("TenantDocuments")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_117")
                        .IsRequired();
                });

            modelBuilder.Entity("Repayabl.Models.TenantOutstanding", b =>
                {
                    b.HasOne("Repayabl.Models.Tenant", "Tenant")
                        .WithMany("TenantOutstandings")
                        .HasForeignKey("TenantId")
                        .HasConstraintName("FK_144")
                        .IsRequired();
                });

            modelBuilder.Entity("Repayabl.Models.User", b =>
                {
                    b.HasOne("Repayabl.Models.Property", "Property")
                        .WithMany("Users")
                        .HasForeignKey("PropertyId")
                        .HasConstraintName("FK_122");

                    b.HasOne("Repayabl.Models.Room", "Room")
                        .WithMany("Users")
                        .HasForeignKey("RoomId")
                        .HasConstraintName("FK_28");
                });
#pragma warning restore 612, 618
        }
    }
}
