using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MobileApplication.Models;
using MobileApplication.Services;
using RestSharp.Portable;
using Xamarin.Forms;


namespace MobileApplication.Pages
{
	public partial class CategoryPage : ContentPage
	{
		private IEnumerable<Category> categories = new List<Category>();
		private ListView listView;


		async Task<ICollection<Category>> load()
		{
			var request = new Rest(Globals.Global.apiCategories, Method.GET);
			var response = await SingletonClient.GetClient().Execute<ICollection<Category>>(request.request);
			return response.Data;


		}

		protected override async void OnAppearing()
		{
			listView.ItemsSource = await load();
			base.OnAppearing();
		}

		public CategoryPage(User user)
		{
			var createCategory = new Button()
			{ WidthRequest = 50, HeightRequest = 80, BackgroundColor = Color.FromHex("77D065"), Text = "Create New Category", FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Button)) };
			createCategory.Clicked += CreateCategoryOnClicked;
			Padding = new Thickness(20, Device.OnPlatform(20, 20, 20), 20, 20);

			var header = new Label
			{
				Text = "Category View",
				FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};

			listView = new ListView
			{
				HasUnevenRows = true,
				ItemTemplate = new DataTemplate(() =>
					{
						// Create views with bindings for displaying each property.
						var nameLabel = new Label() { HeightRequest = 20 };
						nameLabel.SetBinding(Label.TextProperty, "Name");
						nameLabel.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command<Label>(OnLabelClicked), CommandParameter = nameLabel, NumberOfTapsRequired = 1 });



						return new ViewCell
						{
							View = new StackLayout
							{
								VerticalOptions = LayoutOptions.Center,
								Spacing = -7,
								Children =
								{
									new Label() { HeightRequest = 20},
									nameLabel,
									new Label() {HeightRequest = 30}

								}
								}
						};
					})
			};


			this.Content = new StackLayout
			{
				Children =
				{
					header,
					new Label() {HeightRequest = 20},
					listView,
					createCategory
				}
				};
		}

		async void OnLabelClicked(Label clickedLabel)
		{
			var temp = clickedLabel.BindingContext as Category;

			await Navigation.PushAsync(new CategoryManagementPage(temp));
		}

		async void CreateCategoryOnClicked(object sender, EventArgs eventArgs)
		{
			await Navigation.PushAsync(new CategoryCreation());
		}
	}
}

