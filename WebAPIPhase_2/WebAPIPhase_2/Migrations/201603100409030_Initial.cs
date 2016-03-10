namespace WebAPIPhase_2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
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
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        CreatedDate = c.DateTime(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        InventoryCount = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        ManufacturerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Manufacturers", t => t.ManufacturerId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.CategoryId)
                .Index(t => t.ManufacturerId);
            
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false, maxLength: 200),
                        Password = c.String(nullable: false),
                        ApiKey = c.String(),
                    })
                .PrimaryKey(t => t.UserId)
                .Index(t => t.Email, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductPurchaseds", "SaleId", "dbo.Sales");
            DropForeignKey("dbo.ProductPurchaseds", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ManufacturerId", "dbo.Manufacturers");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Users", new[] { "Email" });
            DropIndex("dbo.Products", new[] { "ManufacturerId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "Name" });
            DropIndex("dbo.ProductPurchaseds", new[] { "SaleId" });
            DropIndex("dbo.ProductPurchaseds", new[] { "ProductId" });
            DropTable("dbo.Users");
            DropTable("dbo.Sales");
            DropTable("dbo.Products");
            DropTable("dbo.ProductPurchaseds");
            DropTable("dbo.Manufacturers");
            DropTable("dbo.Categories");
        }
    }
}
