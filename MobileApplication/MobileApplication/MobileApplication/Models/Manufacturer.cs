using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileApplication.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }

        public string ManufacturerName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; } 
    }
}
