using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class AddIsActiveColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Modifed",
                table: "FamilyDetails");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Tenants",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TenantOutstandings",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "TenantOutstandings",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TenantDocuments",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "TenantDocuments",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Rooms",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Rooms",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "RentTransactions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "RentTransactions",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Properties",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Properties",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "FamilyDetails",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "FamilyDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TenantOutstandings");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "TenantDocuments");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "RentTransactions");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "FamilyDetails");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "FamilyDetails");

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Tenants",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "TenantOutstandings",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "TenantDocuments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Rooms",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "RentTransactions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "Properties",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modifed",
                table: "FamilyDetails",
                type: "datetime2",
                nullable: true);
        }
    }
}
