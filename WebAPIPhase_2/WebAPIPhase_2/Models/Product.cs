using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
  public  class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual IEnumerable<ProductPurchased> ProductPurchased { get; set; }

        //   public int ManufacturerId { get; set; }

        //  public virtual Manufacturer manufacturer { get; set; }
        //  public int CategoryId { get; set; }

        //  public virtual Category category { get; set; }

        // public int SaleId { get; set; }
        // public virtual Sale sale { get; set; }

    }
}
