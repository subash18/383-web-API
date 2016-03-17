using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MobileApplication.Models
{
	[DataContract]
    public class Manufacturer
    {
		[DataMember]
        public int ManufacturerId { get; set; }

		[DataMember]
        public string ManufacturerName { get; set; }

		[JsonIgnore]
        public virtual IEnumerable<Product> Products { get; set; } 
    }
}
