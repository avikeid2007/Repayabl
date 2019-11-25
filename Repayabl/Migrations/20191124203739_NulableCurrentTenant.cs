using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class NulableCurrentTenant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyRent",
                table: "Rooms",
                type: "numeric(15, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(8, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectRate",
                table: "Rooms",
                type: "numeric(10, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(2, 2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentTenantId",
                table: "Rooms",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "MonthlyRent",
                table: "Rooms",
                type: "numeric(8, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(15, 2)");

            migrationBuilder.AlterColumn<decimal>(
                name: "ElectRate",
                table: "Rooms",
                type: "numeric(2, 2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric(10, 2)");

            migrationBuilder.AlterColumn<Guid>(
                name: "CurrentTenantId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);
        }
    }
}
