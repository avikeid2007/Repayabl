using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Repayabl.Migrations
{
    public partial class CreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    FloorCount = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zip = table.Column<int>(nullable: true),
                    FamilyMamberCount = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zip = table.Column<int>(nullable: true),
                    TenantId = table.Column<Guid>(nullable: false),
                    Relationship = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_79",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    RoomNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    RoomFloorNo = table.Column<int>(nullable: true),
                    PropertyId = table.Column<Guid>(nullable: false),
                    CurrentTenantId = table.Column<Guid>(nullable: false),
                    MonthlyRent = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    ElectRate = table.Column<decimal>(type: "numeric(2, 2)", nullable: false),
                    LastBillPaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastPaidBillId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_52",
                        column: x => x.CurrentTenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_37",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Payload = table.Column<byte[]>(nullable: false),
                    MimeType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FileExtension = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantDocuments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_117",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TenantOutstandings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    TotalAdvance = table.Column<decimal>(type: "numeric(8, 2)", nullable: true),
                    TotalPending = table.Column<decimal>(type: "numeric(8, 2)", nullable: true),
                    TenantId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TenantOutstandings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_144",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RentTransactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    RoomId = table.Column<Guid>(nullable: false),
                    BillNo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BillYear = table.Column<int>(nullable: false),
                    BillMonth = table.Column<int>(nullable: false),
                    CurrentReading = table.Column<int>(nullable: false),
                    PreviousReading = table.Column<int>(nullable: false),
                    ElectricityBillAmount = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    RentAmount = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    IsPaid = table.Column<bool>(nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaidBy = table.Column<Guid>(nullable: true),
                    PaidAmount = table.Column<decimal>(type: "numeric(8, 2)", nullable: true),
                    TotalPaybleMonth = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentTransactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_100",
                        column: x => x.PaidBy,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_103",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Created = table.Column<DateTime>(nullable: true, defaultValueSql: "getdate()"),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modifed = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false),
                    IsAuth = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    RoomId = table.Column<Guid>(nullable: true),
                    PropertyId = table.Column<Guid>(nullable: true),
                    Otp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_122",
                        column: x => x.PropertyId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_28",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FamilyDetails_TenantId",
                table: "FamilyDetails",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_100",
                table: "RentTransactions",
                column: "PaidBy");

            migrationBuilder.CreateIndex(
                name: "fkIdx_103",
                table: "RentTransactions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_CurrentTenantId",
                table: "Rooms",
                column: "CurrentTenantId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_134",
                table: "Rooms",
                column: "LastPaidBillId");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PropertyId",
                table: "Rooms",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_TenantDocuments_TenantId",
                table: "TenantDocuments",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_144",
                table: "TenantOutstandings",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_122",
                table: "Users",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_28",
                table: "Users",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "RentTransactions");

            migrationBuilder.DropTable(
                name: "TenantDocuments");

            migrationBuilder.DropTable(
                name: "TenantOutstandings");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Properties");
        }
    }
}
