namespace WebAPIPhase_2.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Web.Helpers;
    internal sealed class Configuration : DbMigrationsConfiguration<WebAPIPhase_2.Models.WebAPIPhase_2Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        private static string GetApiKey()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var bytes = new byte[16];
                rng.GetBytes(bytes);
                return Convert.ToBase64String(bytes);
            }
        }
        protected override void Seed(WebAPIPhase_2.Models.WebAPIPhase_2Context context)
        {
            context.Users.AddOrUpdate(x => x.UserId, new User { ApiKey = GetApiKey(), Email = "sa@383.com", Password =Crypto.HashPassword( "password"), UserId = 1 , Role= "Admin" });

            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "Nvidia Titan X", InventoryCount = 500, Price = 500, ProductId = 1, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 1, ManufacturerId = 1 });
            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "AMD 5GHz 8-Core Processor", InventoryCount = 500, Price = 250, ProductId = 2, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 2, ManufacturerId = 2 });
            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "Nvidia Geforce 980GTX", InventoryCount = 500, Price = 300, ProductId = 3, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 1, ManufacturerId = 1 });
            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "AMD 4GHz 6-Core Processor", InventoryCount = 500, Price = 150, ProductId = 4, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 2, ManufacturerId = 2 });
            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "Kingston HyperX 8GB Memory x 1", InventoryCount = 500, Price = 39, ProductId = 5, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 3, ManufacturerId = 3 });
            context.Products.AddOrUpdate(x => x.ProductId, new Product { Name = "Seagate 6TB STD", InventoryCount = 500, Price = 89, ProductId = 6, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today, CategoryId = 4, ManufacturerId = 4 });

            context.Category.AddOrUpdate(x => x.CategoryId, new Category { CategoryName = "Graphics Cards", CategoryId = 1 });
            context.Category.AddOrUpdate(x => x.CategoryId, new Category { CategoryName = "CPU", CategoryId = 2 });
            context.Category.AddOrUpdate(x => x.CategoryId, new Category { CategoryName = "RAM", CategoryId = 3 });
            context.Category.AddOrUpdate(x => x.CategoryId, new Category { CategoryName = "Hard Drive", CategoryId = 4 });

            context.Manufacturer.AddOrUpdate(x => x.ManufacturerId, new Manufacturer { ManfacturerName = "Nvidia", ManufacturerId = 1 });
            context.Manufacturer.AddOrUpdate(x => x.ManufacturerId, new Manufacturer { ManfacturerName = "AMD", ManufacturerId = 2 });
            context.Manufacturer.AddOrUpdate(x => x.ManufacturerId, new Manufacturer { ManfacturerName = "Kingston", ManufacturerId = 3 });
            context.Manufacturer.AddOrUpdate(x => x.ManufacturerId, new Manufacturer { ManfacturerName = "Seagate", ManufacturerId = 4 });

            context.Sales.AddOrUpdate(x => x.SaleId, new Sale { SaleId = 1, SaleDate = DateTime.Today, TotalAmount = 750, Email = "test@test.com" });

            context.ProductPurchased.AddOrUpdate(x => x.ProductPurchasedId, new ProductPurchased { ProductId = 1, Quantity = 1, SaleId = 1 });
            context.ProductPurchased.AddOrUpdate(x => x.ProductPurchasedId, new ProductPurchased { ProductId = 2, Quantity = 1, SaleId = 1 });
        }
    }
}