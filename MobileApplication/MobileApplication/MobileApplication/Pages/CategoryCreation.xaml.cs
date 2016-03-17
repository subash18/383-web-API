using System;
using MobileApplication.Models;
using MobileApplication.Services;
using RestSharp.Portable;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;

namespace MobileApplication.Pages
{
	public partial class CategoryCreation : ContentPage
	{
		private Category category = new Category();

		public CategoryCreation()
		{
			this.BindingContext = category;

			var nameLabel = new Label() {Text = "Category Name: "};
			var nameEntry = new Entry() {HorizontalOptions = LayoutOptions.FillAndExpand};
			nameEntry.SetBinding(Entry.TextProperty, "Name");
			nameEntry.TextChanged += (sender, args) => { category.CategoryName = args.NewTextValue; };
			var createButton = new Button() {Text = "Add a Category", HeightRequest = 50, WidthRequest = 80};
			createButton.Clicked += CreateButtonOnClicked;


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
			grid.Children.Add(createButton, 1, 12);


			this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

			this.Content = grid;
		}

		async void CreateButtonOnClicked(object sender, EventArgs eventArgs)
		{
			var request = new Rest(Globals.Global.apiCategories, Method.PUT);
			var response = SingletonClient.GetClient().Execute(request);
			if (response.Result.IsSuccess)
			{
				await Navigation.PopAsync();
			}
		}
	}
}
