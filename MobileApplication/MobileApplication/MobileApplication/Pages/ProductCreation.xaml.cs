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
			manufacturerLabel.SetBinding(Entry.TextProperty, "product.ManufacturerId");
			manufacturerEntry.TextChanged += (sender, args) => { manufacturer.ManufacturerName = args.NewTextValue; };
			var categoryLabel = new Label() { Text = "Category: " };
			var categoryEntry = new Entry() { HorizontalOptions = LayoutOptions.FillAndExpand };
			categoryLabel.SetBinding(Entry.TextProperty, "product.CategoryId");
			categoryEntry.TextChanged += (sender, args) => { category.CategoryName = args.NewTextValue; };


			var grid = new Grid()

			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				RowDefinitions =
				{
					new RowDefinition() {Height = GridLength.Auto},
					new RowDefinition() {Height = GridLength.Auto},
					new RowDefinition() {Height = GridLength.Auto},
					new RowDefinition() {Height = GridLength.Auto},
					new RowDefinition() {Height = GridLength.Auto},
				},
				ColumnDefinitions =
				{
					new ColumnDefinition() {Width = GridLength.Auto},
					new ColumnDefinition() {Width = new GridLength(200)},

				}
				};
			grid.Children.Add(nameLabel, 0,1);
			grid.Children.Add(nameEntry, 1,1);
			grid.Children.Add(quantityLabel, 0, 2);
			grid.Children.Add(quantityEntry, 1, 2);
			grid.Children.Add(priceLabel, 0, 3);
			grid.Children.Add(priceEntry, 1, 3);
			grid.Children.Add(manufacturerLabel,0,4);
			grid.Children.Add(manufacturerEntry,1,4);
			grid.Children.Add(categoryLabel,0,5);
			grid.Children.Add(categoryEntry, 1, 5);



			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			var layout = new StackLayout()
			{
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.Center,
				Children = { createButton}

			};

			this.Content = new StackLayout() {Children = { grid, layout}};

		}

		async void CreateButtonOnClicked(object sender, EventArgs eventArgs)
		{

			var request = new Rest(Globals.Global.apiProduct, Method.PUT);
			var response = SingletonClient.GetClient().Execute(request);
			if (response.Result.IsSuccess)
			{
				await Navigation.PopAsync();
			}
		}
	}
}