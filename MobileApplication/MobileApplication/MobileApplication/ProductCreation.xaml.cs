using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace MobileApplication
{
    public partial class ProductCreation : ContentPage
    {
        private Product product = new Product();

        public ProductCreation()
        {
            var header = new Label()
            {
                Text = "Create A New Product",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            var nameCell = new EntryCell
            {
                Label = "Product Name",
                Placeholder = "Name",
                Text = product.Name,
                BindingContext = product.Name
            };
            nameCell.SetBinding(EntryCell.TextProperty, "Name");
            nameCell.Completed += NameCellOnCompleted;

            var table = new TableView();
            table.Intent = TableIntent.Form;
            var layout = new StackLayout() {Orientation = StackOrientation.Horizontal, HorizontalOptions = LayoutOptions.Center};
            layout.Children.Add(header);
            table.Root = new TableRoot()
            {
                new TableSection("I'm Here")
                {
                    new ViewCell() {View = layout},
                    nameCell
                 }
            };
            Content = table;
        }

        private void NameCellOnCompleted(object sender, EventArgs eventArgs)
        {
            var x = product.Name;
            var y = 1;
        }
    }
}