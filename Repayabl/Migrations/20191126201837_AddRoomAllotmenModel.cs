using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class AddRoomAllotmenModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Designation",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FacebookUrl",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MobileNo",
                table: "Tenants",
                maxLength: 13,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Qualification",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TwitterUrl",
                table: "Tenants",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "linkedinUrl",
                table: "Tenants",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "RoomAllotments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false, defaultValueSql: "(newsequentialid())"),
                    Created = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: false),
                    TenantId = table.Column<Guid>(nullable: false),
                    AllotmentDate = table.Column<DateTime>(nullable: false, defaultValueSql: "(getdate())"),
                    ReleaseDate = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAllotments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RoomAllotments_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomAllotments_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotments_RoomId",
                table: "RoomAllotments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotments_TenantId",
                table: "RoomAllotments",
                column: "TenantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomAllotments");

            migrationBuilder.DropColumn(
                name: "Designation",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "FacebookUrl",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "MobileNo",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Occupation",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "Qualification",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "TwitterUrl",
                table: "Tenants");

            migrationBuilder.DropColumn(
                name: "linkedinUrl",
                table: "Tenants");
        }
    }
}
