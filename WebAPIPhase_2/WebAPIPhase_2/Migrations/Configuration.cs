namespace WebAPIPhase_2.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Security.Cryptography;
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
            
            context.Products.AddOrUpdate(x => x.ProductId, new Product {Name = "Tongs", InventoryCount = 5, Price = 5, ProductId = 1, CreatedDate = DateTime.Today, LastModifiedDate = DateTime.Today});

           
        }
    }
}
