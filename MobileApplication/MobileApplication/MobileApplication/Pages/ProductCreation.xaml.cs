using System;
using MobileApplication.Models;
using MobileApplication.Services;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace MobileApplication.Pages
{
    public partial class ProductCreation : ContentPage
    {
        private Product product = new Product();
        private Manufacturer manufacturer = new Manufacturer();
        private Category category = new Category();

        public ProductCreation()
        {
            this.BindingContext = product;

            var nameLabel = new Label() {Text = "Product Name: "};
            var nameEntry = new Entry() {HorizontalOptions = LayoutOptions.FillAndExpand};
            nameEntry.SetBinding(Entry.TextProperty, "Name");
            nameEntry.TextChanged += (sender, args) => { product.Name = args.NewTextValue; };
            var quantityLabel = new Label() {Text = "Inventory Count: "};
            var quantityEntry = new Entry() {Keyboard = Keyboard.Numeric, HorizontalOptions = LayoutOptions.FillAndExpand};
            quantityEntry.SetBinding(Entry.TextProperty, "InventoryCount");
            quantityEntry.TextChanged += (sender, args) => { product.InventoryCount = int.Parse(args.NewTextValue);};
            var priceLabel = new Label() {Text = "Price: $"};
            var priceEntry = new Entry() {Keyboard = Keyboard.Numeric};
            priceEntry.SetBinding(Entry.TextProperty, "Price");
            priceEntry.TextChanged += (sender, args) => { product.Price = decimal.Parse(args.NewTextValue); };
            var createButton = new Button() {Text = "Add a Product", HeightRequest = 50, WidthRequest = 80};
            createButton.Clicked += CreateButtonOnClicked;
            var manufacturerLabel = new Label() { Text = "Manufacturer: " };
            var manufacturerEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            manufacturerLabel.SetBinding(Entry.TextProperty, "product.Manufacturer.ManufacurerName");
            manufacturerEntry.TextChanged += (sender, args) => { manufacturer.ManufacturerName = args.NewTextValue; };
            var categoryLabel = new Label() { Text = "Category: " };
            var categoryEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
            categoryLabel.SetBinding(Entry.TextProperty, "product.Category.CategoryName");
            categoryEntry.TextChanged += (sender, args) => { category.CategoryName = args.NewTextValue; };


            var grid = new Grid()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                RowDefinitions =
                {
                    new RowDefinition() {Height = GridLength.Auto},
                    new RowDefinition() {Height = GridLength.Auto},
                    new RowDefinition() {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition() {Height = new GridLength(10, GridUnitType.Absolute)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition() {Width = GridLength.Auto},
                    new ColumnDefinition() {Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition() {Width = new GridLength(100, GridUnitType.Absolute)}
                }
            };
            grid.Children.Add(nameLabel, 0, 2);
            grid.Children.Add(nameEntry, 1, 2);
            grid.Children.Add(quantityLabel, 0, 4);
            grid.Children.Add(quantityEntry, 1, 4);
            grid.Children.Add(priceLabel, 0, 6);
            grid.Children.Add(priceEntry, 1, 6);
            grid.Children.Add(manufacturerLabel,0,8);
            grid.Children.Add(manufacturerEntry,1,8);
            grid.Children.Add(categoryLabel,0,10);
            grid.Children.Add(categoryEntry,1,10);
            grid.Children.Add(createButton, 1, 12);
            

            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            this.Content = grid;
        }
 
        async void CreateButtonOnClicked(object sender, EventArgs eventArgs)
        {
            product.CreatedDate = DateTime.UtcNow;
            product.LastModifiedDate = DateTime.UtcNow;
            product.Manufacturer = manufacturer;
            product.Category = category;
            var request = new Rest(Globals.Global.apiProduct, Method.PUT);

            var response = await SingletonClient.GetClient().Execute(request.request.AddBody(product));
            if (response.IsSuccess)
            {
                await Navigation.PopAsync();
            }
        }
    }
}