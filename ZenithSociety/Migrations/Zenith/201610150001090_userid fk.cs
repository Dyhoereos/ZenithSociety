namespace ZenithSociety.Migrations.Zenith
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class useridfk : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Events", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Events", "UserId");
            RenameColumn(table: "dbo.Events", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Events", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Events", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Events", new[] { "UserId" });
            AlterColumn("dbo.Events", "UserId", c => c.String());
            RenameColumn(table: "dbo.Events", name: "UserId", newName: "ApplicationUser_Id");
            AddColumn("dbo.Events", "UserId", c => c.String());
            CreateIndex("dbo.Events", "ApplicationUser_Id");
        }
    }
}
