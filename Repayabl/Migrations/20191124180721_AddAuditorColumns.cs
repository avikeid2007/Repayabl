using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class AddAuditorColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Users",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tenants",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TenantOutstandings",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TenantOutstandings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "TenantOutstandings",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TenantOutstandings",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "TenantDocuments",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "TenantDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "TenantDocuments",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "TenantDocuments",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Rooms",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "RentTransactions",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "RentTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "RentTransactions",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "RentTransactions",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Properties",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "FamilyDetails",
                nullable: true,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "FamilyDetails",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "FamilyDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "FamilyDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Created",
                table: "FamilyDetails");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "FamilyDetails");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "FamilyDetails");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "FamilyDetails");
        }
    }
}
