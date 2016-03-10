using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
    [DataContract]
    [KnownType(typeof(Product))]
    [KnownType(typeof(Category))]
    public  class Product
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [DataMember]
        public int ProductId { get; set; }
        [Index(IsUnique = true)]
        [MaxLength(100)]
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public DateTime CreatedDate { get; set; }

        [DataMember]
        public DateTime LastModifiedDate { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public int InventoryCount { get; set; }

        public int CategoryId { get; set; }

   
        public virtual Category Category { get; set; }

        public int ManufacturerId { get; set; }

   
        public virtual Manufacturer Manufacturer { get; set; }

        [JsonIgnore]
        public virtual IEnumerable<ProductPurchased> ProductPurchased { get; set; }

        //   public int ManufacturerId { get; set; }

        //  public virtual Manufacturer manufacturer { get; set; }
        //  public int CategoryId { get; set; }

        //  public virtual Category category { get; set; }

        // public int SaleId { get; set; }
        // public virtual Sale sale { get; set; }

    }
}
