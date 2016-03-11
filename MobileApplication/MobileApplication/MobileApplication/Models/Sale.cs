using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class Sale
    {
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }

        public decimal TotalAmount { get; set; }

        public string Email { get; set; }

        public virtual IEnumerable<ProductPurchased> ProductPurchased  { get; set; }
    }
}
