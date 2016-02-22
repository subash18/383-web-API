using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models.DTOs
{
   public class ProductDTO
    {
        public string Url { get; set; }
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }
    }
}
