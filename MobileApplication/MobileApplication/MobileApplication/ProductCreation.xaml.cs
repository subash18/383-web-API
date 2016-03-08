using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace MobileApplication
{
    public partial class ProductCreation : ContentPage
    {

        public ProductCreation()
        {
            var product = new Product();
            var header = new Label() { Text = "Add a Product", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)) };
            var tableView = new TableView
            {
                Intent = TableIntent.Form,

                Root = new TableRoot
                {
                    new TableSection
                    {
                        new EntryCell() {Label = "Product Name", Placeholder = "your item name here"},
                        new EntryCell() {Label = "Inventory Count: ", Placeholder = "5" },
                        new EntryCell() {Label = "Price: $", Placeholder = "5.00"}
                    }
                }
            };

            var add = new Button() { Text = "Add Product", WidthRequest = 50, HeightRequest = 80, FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)), BackgroundColor = Color.FromHex("77D065") };

            add.Clicked += AddOnClicked;

            this.Content = new StackLayout()
            {
                Spacing = 10,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                   header,
                   tableView,
                   add
                }
            };
        }

        async void AddOnClicked(object sender, EventArgs eventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
