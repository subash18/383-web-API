using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
   
   public class Manufacturer
    {
        [Key]
        public int ManufacturerId { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
