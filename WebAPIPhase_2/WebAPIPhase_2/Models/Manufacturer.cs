using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIPhase_2.Models
{
   
   public class Manufacturer
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int ManufacturerId { get; set; }

        public string ManfacturerName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}
