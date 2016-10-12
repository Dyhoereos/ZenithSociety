namespace ZenithSociety.Migrations.Zenith
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        ActivityId = c.Int(nullable: false, identity: true),
                        ActivityDesc = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ActivityId);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        EventId = c.Int(nullable: false, identity: true),
                        EventFrom = c.DateTime(nullable: false),
                        EventTo = c.DateTime(nullable: false),
                        Creator = c.String(),
                        ActivityDesc = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Activity_ActivityId = c.Int(),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Activities", t => t.Activity_ActivityId)
                .Index(t => t.Activity_ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "Activity_ActivityId", "dbo.Activities");
            DropIndex("dbo.Events", new[] { "Activity_ActivityId" });
            DropTable("dbo.Events");
            DropTable("dbo.Activities");
        }
    }
}
