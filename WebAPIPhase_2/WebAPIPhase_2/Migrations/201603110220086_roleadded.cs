namespace WebAPIPhase_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class roleadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "Role", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Role");
        }
    }
}
