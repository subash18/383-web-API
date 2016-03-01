using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
   public class Sale
    {

        [Key]
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }

        public decimal TotalAmount { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
