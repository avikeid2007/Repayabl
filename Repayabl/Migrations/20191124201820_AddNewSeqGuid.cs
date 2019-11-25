using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class AddNewSeqGuid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "Properties");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tenants",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TenantOutstandings",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TenantDocuments",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Rooms",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RentTransactions",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Properties",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FamilyDetails",
                nullable: false,
                defaultValueSql: "NEWSEQUENTIALID( )",
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Users",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Tenants",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TenantOutstandings",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "TenantDocuments",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "RentTransactions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");

            migrationBuilder.AddColumn<Guid>(
                name: "PropertyId",
                table: "Properties",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "FamilyDetails",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldDefaultValueSql: "NEWSEQUENTIALID( )");
        }
    }
}
