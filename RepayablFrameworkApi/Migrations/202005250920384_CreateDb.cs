namespace RepayablFrameworkApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FamilyDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 10),
                        BirthDate = c.DateTime(),
                        Address = c.String(),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Zip = c.Int(),
                        TenantId = c.Guid(nullable: false),
                        Relationship = c.String(maxLength: 50),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.Tenants",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(maxLength: 50),
                        Gender = c.String(nullable: false, maxLength: 10),
                        BirthDate = c.DateTime(),
                        Address = c.String(),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Zip = c.Int(),
                        FamilyMamberCount = c.Int(),
                        MobileNo = c.String(maxLength: 13),
                        Email = c.String(),
                        Qualification = c.String(),
                        FacebookUrl = c.String(),
                        TwitterUrl = c.String(),
                        linkedinUrl = c.String(),
                        InstagramUrl = c.String(),
                        Occupation = c.String(),
                        Designation = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RentTransactions",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                        BillNo = c.String(nullable: false, maxLength: 50),
                        BillDate = c.DateTime(nullable: false),
                        BillYear = c.Int(nullable: false),
                        BillMonth = c.Int(nullable: false),
                        CurrentReading = c.Int(nullable: false),
                        PreviousReading = c.Int(nullable: false),
                        ElectricityBillAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsPaid = c.Boolean(),
                        PaidDate = c.DateTime(),
                        PaidBy = c.Guid(),
                        PaidAmount = c.Decimal(precision: 18, scale: 2),
                        TotalPaybleMonth = c.Int(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.PaidBy)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.PaidBy);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoomNo = c.String(nullable: false, maxLength: 10),
                        RoomFloorNo = c.Int(),
                        PropertyId = c.Guid(nullable: false),
                        CurrentTenantId = c.Guid(),
                        MonthlyRent = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ElectRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LastBillPaidDate = c.DateTime(),
                        LastPaidBillId = c.Guid(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.CurrentTenantId)
                .ForeignKey("dbo.Properties", t => t.PropertyId, cascadeDelete: true)
                .Index(t => t.PropertyId)
                .Index(t => t.CurrentTenantId);
            
            CreateTable(
                "dbo.Properties",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false),
                        City = c.String(nullable: false, maxLength: 50),
                        State = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        Zip = c.Int(nullable: false),
                        FloorCount = c.Int(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 50),
                        UserId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false),
                        IsAuth = c.Boolean(nullable: false),
                        IsAdmin = c.Boolean(nullable: false),
                        Context = c.String(),
                        AzureId = c.String(),
                        DisplayName = c.String(),
                        GivenName = c.String(),
                        Surname = c.String(),
                        UserPrincipalName = c.String(),
                        JobTitle = c.String(),
                        Mail = c.String(),
                        MobilePhone = c.String(),
                        OfficeLocation = c.String(),
                        PreferredLanguage = c.String(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomAllotments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        RoomId = c.Guid(nullable: false),
                        TenantId = c.Guid(nullable: false),
                        AllotmentDate = c.DateTime(nullable: false),
                        ReleaseDate = c.DateTime(),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.TenantDocuments",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Title = c.String(maxLength: 50),
                        Type = c.String(nullable: false, maxLength: 50),
                        Payload = c.Binary(nullable: false),
                        MimeType = c.String(nullable: false, maxLength: 50),
                        FileExtension = c.String(nullable: false, maxLength: 50),
                        TenantId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
            CreateTable(
                "dbo.TenantOutstandings",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        TotalAdvance = c.Decimal(precision: 18, scale: 2),
                        TotalPending = c.Decimal(precision: 18, scale: 2),
                        TenantId = c.Guid(nullable: false),
                        Created = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                        Modified = c.DateTime(),
                        ModifiedBy = c.String(),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tenants", t => t.TenantId, cascadeDelete: true)
                .Index(t => t.TenantId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FamilyDetails", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.TenantOutstandings", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.TenantDocuments", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.RentTransactions", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAllotments", "TenantId", "dbo.Tenants");
            DropForeignKey("dbo.RoomAllotments", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Properties", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rooms", "PropertyId", "dbo.Properties");
            DropForeignKey("dbo.Rooms", "CurrentTenantId", "dbo.Tenants");
            DropForeignKey("dbo.RentTransactions", "PaidBy", "dbo.Tenants");
            DropIndex("dbo.TenantOutstandings", new[] { "TenantId" });
            DropIndex("dbo.TenantDocuments", new[] { "TenantId" });
            DropIndex("dbo.RoomAllotments", new[] { "TenantId" });
            DropIndex("dbo.RoomAllotments", new[] { "RoomId" });
            DropIndex("dbo.Properties", new[] { "UserId" });
            DropIndex("dbo.Rooms", new[] { "CurrentTenantId" });
            DropIndex("dbo.Rooms", new[] { "PropertyId" });
            DropIndex("dbo.RentTransactions", new[] { "PaidBy" });
            DropIndex("dbo.RentTransactions", new[] { "RoomId" });
            DropIndex("dbo.FamilyDetails", new[] { "TenantId" });
            DropTable("dbo.TenantOutstandings");
            DropTable("dbo.TenantDocuments");
            DropTable("dbo.RoomAllotments");
            DropTable("dbo.Users");
            DropTable("dbo.Properties");
            DropTable("dbo.Rooms");
            DropTable("dbo.RentTransactions");
            DropTable("dbo.Tenants");
            DropTable("dbo.FamilyDetails");
        }
    }
}
