using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIPhase_2.Models.DTOs
{
    public class ManufacturerDTO
    {
        public string ManfacturerName { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }
    }
}