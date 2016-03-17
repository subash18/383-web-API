using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace MobileApplication.Models
{
	[DataContract]
	[KnownType(typeof(Product))]
	[KnownType(typeof(Manufacturer))]
	[KnownType(typeof(Category))]
	public class Product : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;
		private string _name;
		[DataMember]
		public int ProductId { get; set; }

		[DataMember]
		public string Name
		{
			get { return _name; }
			set
			{
				if (value.Equals(_name, StringComparison.Ordinal))
				{
					return;
				}
				_name = value;
				OnPropertyChanged();
			}
		}

		[DataMember]
		public DateTime CreatedDate { get; set; }

		[DataMember]
		public DateTime LastModifiedDate { get; set; }

		[DataMember]
		public decimal Price { get; set; }

		[DataMember]
		public int InventoryCount { get; set; }

		[DataMember]
		public int CategoryId { get; set; }

		public Category Category { get; set; }

		[DataMember]
		public int ManufacturerId { get; set; }

		public Manufacturer Manufacturer { get; set; }

		[JsonIgnore]
		public virtual IEnumerable<ProductPurchased> ProductPurchased { get; set; }

		void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			handler?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

	}
}