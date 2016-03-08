namespace WebAPIPhase_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Name : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 100));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 200));
            CreateIndex("dbo.Products", "Name", unique: true);
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Products", new[] { "Name" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String());
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Products", "Name", unique: true);
        }
    }
}
