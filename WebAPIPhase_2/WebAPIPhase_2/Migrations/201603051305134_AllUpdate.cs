namespace WebAPIPhase_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllUpdate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Manufacturers",
                c => new
                    {
                        ManufacturerId = c.Int(nullable: false, identity: true),
                        ManfacturerName = c.String(),
                    })
                .PrimaryKey(t => t.ManufacturerId);
            
            CreateTable(
                "dbo.ProductPurchaseds",
                c => new
                    {
                        ProductPurchasedId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        SaleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductPurchasedId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Sales", t => t.SaleId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.SaleId);
            
            CreateTable(
                "dbo.Sales",
                c => new
                    {
                        SaleId = c.Int(nullable: false, identity: true),
                        SaleDate = c.DateTime(nullable: false),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SaleId);
            
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "ManufacturerId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "ManufacturerId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
            AddForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers", "ManufacturerId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPurchaseds", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.ProductPurchaseds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.ProductPurchaseds", new[] { "SaleId" });
            DropIndex("dbo.ProductPurchaseds", new[] { "ProductId" });
            DropColumn("dbo.Products", "ManufacturerId");
            DropColumn("dbo.Products", "CategoryId");
            DropTable("dbo.Sales");
            DropTable("dbo.ProductPurchaseds");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
        }
    }
}
