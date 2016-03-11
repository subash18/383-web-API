using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MobileApplication.Models
{
    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string _name;

        public int ProductId { get; set; }

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

        public DateTime CreatedDate { get; set; }

        public DateTime LastModifiedDate { get; set; }

        public decimal Price { get; set; }

        public int InventoryCount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int ManufacturerId { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        public virtual IEnumerable<ProductPurchased> ProductPurchased { get; set; }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}