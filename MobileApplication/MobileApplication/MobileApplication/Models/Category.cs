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
    public class Category
    {
		[DataMember]
        public int CategoryId { get; set; }
		[DataMember]
        public string CategoryName { get; set; }
		[JsonIgnore]
        public virtual IEnumerable<Product> Products { get; set; }
		[DataMember]
		public DateTime CreatedDate { get; set; }
		[DataMember]
		public DateTime LastModifiedDate { get; set; }
    }
}
