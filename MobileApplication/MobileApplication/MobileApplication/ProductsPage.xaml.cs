using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Serializers;
using Xamarin.Forms;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace MobileApplication
{
    public partial class ProductsPage : ContentPage
        {
            
            
           
        public ProductsPage(IEnumerable<Product> products )
        {
            var createProduct = new Button()
            { WidthRequest = 50, HeightRequest = 80, BackgroundColor = Color.FromHex("77D065"), Text = "Create New Product", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)) };
            createProduct.Clicked += CreateProductOnClicked;
            Padding = new Thickness(20, Device.OnPlatform(20, 20, 20), 20, 20);

            var header = new Label
            {
                Text = "Product List View",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };
            

        

            var listView = new ListView
            {
                // Source of data items.
                ItemsSource = products,

                // Define template for displaying each item.
                // (Argument of DataTemplate constructor is called for 
                //      each item; it must return a Cell derivative.)
                ItemTemplate = new DataTemplate(() =>
                {
                    // Create views with bindings for displaying each property.
                    var nameLabel = new Label();
                    nameLabel.SetBinding(Label.TextProperty, "Name");
                    nameLabel.GestureRecognizers.Add(new TapGestureRecognizer {Command = new Command<Label>(OnLabelClicked), CommandParameter = nameLabel, NumberOfTapsRequired = 1}); 

                    var inventoryCountLabel = new Label();
                    inventoryCountLabel.SetBinding(Label.TextProperty, "InventoryCount", BindingMode.OneWay, null, "Inventory Count: {0}");

                    var priceLabel = new Label();
                    priceLabel.SetBinding(Label.TextProperty,"Price", BindingMode.OneWay, null, "Price: ${0}");

                    // Return an assembled ViewCell.
                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            VerticalOptions = LayoutOptions.Center,
                            Spacing = -7,
                            Children =
                            {
                                nameLabel,
                               inventoryCountLabel,
                               priceLabel
                                
                            }
                        }
                    };
                })
    };

           
            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    listView,
                    createProduct
                }
            };
        }
        
        async void OnLabelClicked(Label clickedLabel)
        {
            var temp = clickedLabel.BindingContext as Product;
            
            await Navigation.PushAsync(new ItemPage(temp));
        }

        async void CreateProductOnClicked(object sender, EventArgs eventArgs)
        {
            await Navigation.PushAsync(new ProductCreation());
        }
    }
}