namespace RepayablFrameworkApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterPropertyColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Properties", "Society", c => c.String(maxLength: 50));
            AddColumn("dbo.Properties", "Images", c => c.String());
            AddColumn("dbo.Properties", "Type", c => c.String(maxLength: 50));
            AlterColumn("dbo.Properties", "Address", c => c.String());
            AlterColumn("dbo.Properties", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Properties", "State", c => c.String(maxLength: 50));
            AlterColumn("dbo.Properties", "Country", c => c.String(maxLength: 50));
            AlterColumn("dbo.Properties", "Remarks", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Properties", "Remarks", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "Country", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "State", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "City", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Properties", "Address", c => c.String(nullable: false));
            DropColumn("dbo.Properties", "Type");
            DropColumn("dbo.Properties", "Images");
            DropColumn("dbo.Properties", "Society");
        }
    }
}
