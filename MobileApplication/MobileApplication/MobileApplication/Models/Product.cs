using System;

namespace MobileApplication.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

    }
}