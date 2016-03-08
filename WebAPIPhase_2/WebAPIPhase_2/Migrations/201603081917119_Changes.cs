namespace WebAPIPhase_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "Email" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Users", "Email", unique: true);
            CreateIndex("dbo.Products", "Name", unique: true);
        }
    }
}
