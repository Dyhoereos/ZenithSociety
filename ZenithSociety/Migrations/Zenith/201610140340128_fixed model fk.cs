namespace ZenithSociety.Migrations.Zenith
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedmodelfk : DbMigration
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
                        ActivityId = c.Int(nullable: false),
                        CreationDate = c.DateTime(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.EventId)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "ActivityId", "dbo.Activities");
            DropIndex("dbo.Events", new[] { "ActivityId" });
            DropTable("dbo.Events");
            DropTable("dbo.Activities");
        }
    }
}
