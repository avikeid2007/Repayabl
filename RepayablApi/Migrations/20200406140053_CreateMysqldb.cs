using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RepayablApi.Migrations
{
    public partial class CreateMysqldb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zip = table.Column<int>(nullable: true),
                    FamilyMamberCount = table.Column<int>(nullable: true),
                    MobileNo = table.Column<string>(maxLength: 13, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Qualification = table.Column<string>(nullable: true),
                    FacebookUrl = table.Column<string>(nullable: true),
                    TwitterUrl = table.Column<string>(nullable: true),
                    linkedinUrl = table.Column<string>(nullable: true),
                    InstagramUrl = table.Column<string>(nullable: true),
                    Occupation = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(unicode: false, nullable: false),
                    IsAuth = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FamilyDetails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    FirstName = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    LastName = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Gender = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Zip = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: false),
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
                name: "TenantDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Title = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    Type = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Payload = table.Column<byte[]>(nullable: false),
                    MimeType = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    FileExtension = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    TenantId = table.Column<int>(nullable: false)
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    TotalAdvance = table.Column<decimal>(type: "numeric(15, 2)", nullable: true),
                    TotalPending = table.Column<decimal>(type: "numeric(15, 2)", nullable: true),
                    TenantId = table.Column<int>(nullable: false)
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
                name: "Properties",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Address = table.Column<string>(nullable: false),
                    City = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    State = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Country = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    Zip = table.Column<int>(nullable: false),
                    FloorCount = table.Column<int>(nullable: false),
                    Remarks = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_137",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoomNo = table.Column<string>(unicode: false, maxLength: 10, nullable: false),
                    RoomFloorNo = table.Column<int>(nullable: true),
                    PropertyId = table.Column<int>(nullable: false),
                    CurrentTenantId = table.Column<int>(nullable: true),
                    MonthlyRent = table.Column<decimal>(type: "numeric(15, 2)", nullable: false),
                    ElectRate = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    LastBillPaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    LastPaidBillId = table.Column<int>(nullable: true)
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
                name: "RentTransactions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    BillNo = table.Column<string>(unicode: false, maxLength: 50, nullable: false),
                    BillDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    BillYear = table.Column<int>(nullable: false),
                    BillMonth = table.Column<int>(nullable: false),
                    CurrentReading = table.Column<int>(nullable: false),
                    PreviousReading = table.Column<int>(nullable: false),
                    ElectricityBillAmount = table.Column<decimal>(type: "numeric(8, 2)", nullable: false),
                    RentAmount = table.Column<decimal>(type: "numeric(15, 2)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric(15, 2)", nullable: false),
                    IsPaid = table.Column<bool>(nullable: true),
                    PaidDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    PaidBy = table.Column<int>(nullable: true),
                    PaidAmount = table.Column<decimal>(type: "numeric(15, 2)", nullable: true),
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
                name: "RoomAllotments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Created = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Modified = table.Column<DateTime>(type: "datetime", nullable: true),
                    ModifiedBy = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    RoomId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: false),
                    AllotmentDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime", nullable: true)
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
                name: "IX_FamilyDetails_TenantId",
                table: "FamilyDetails",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_UserId",
                table: "Properties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "fkIdx_100",
                table: "RentTransactions",
                column: "PaidBy");

            migrationBuilder.CreateIndex(
                name: "fkIdx_103",
                table: "RentTransactions",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotments_RoomId",
                table: "RoomAllotments",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAllotments_TenantId",
                table: "RoomAllotments",
                column: "TenantId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FamilyDetails");

            migrationBuilder.DropTable(
                name: "RentTransactions");

            migrationBuilder.DropTable(
                name: "RoomAllotments");

            migrationBuilder.DropTable(
                name: "TenantDocuments");

            migrationBuilder.DropTable(
                name: "TenantOutstandings");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Properties");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
