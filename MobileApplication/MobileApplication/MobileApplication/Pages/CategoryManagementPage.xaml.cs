using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MobileApplication.Annotations;
using MobileApplication.Models;
using MobileApplication.Services;
using RestSharp.Portable;
using Xamarin.Forms;


namespace MobileApplication
{
	public partial class CategoryManagementPage : ContentPage
	{
		private Category _category;

		public CategoryManagementPage(Category category)
		{
			this._category = category;
			this.BindingContext = category;

			var nameLabel = new Label() { Text = "Category Name: "};
			var name = new Entry(){HorizontalOptions = LayoutOptions.FillAndExpand};
			name.SetBinding(Entry.TextProperty, "Name");
			var deleteButton = new Button();
			deleteButton = new Button() {Text = "Delete"};
			deleteButton.Clicked += DeleteButtonOnClicked;
			var saveButton = new Button() {Text = "Edit"};
			saveButton.Clicked += SaveButtonOnClicked;

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
			grid.Children.Add(nameLabel,0,2);
			grid.Children.Add(name,1,2);
			grid.Children.Add(deleteButton,0,8);
			grid.Children.Add(saveButton,1,8);

			this.Padding = new Thickness(10, Device.OnPlatform(20,0,0), 10, 5);

			this.Content = grid;
		}

		async void DeleteButtonOnClicked(object sender, EventArgs eventArgs)
		{
			var request = new Rest(Globals.Global.baseUrl + _category.CategoryId, Method.DELETE);
			var response = await SingletonClient.GetClient().Execute(request.request);
			if (response.IsSuccess)
			{
				await Navigation.PopAsync();
			}
		}


		async void SaveButtonOnClicked(object sender, EventArgs eventArgs)
		{
			var request = new Rest(Globals.Global.apiCategory, Method.PUT);

			var response = await SingletonClient.GetClient().Execute(request.request.AddBody(_category));
			if (response.IsSuccess)
			{
				await Navigation.PopAsync();
			}


		}
	}
}

