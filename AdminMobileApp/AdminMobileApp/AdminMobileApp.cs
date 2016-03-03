using System;

using Xamarin.Forms;

namespace AdminMobileApp
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new ContentPage {
				Content = new StackLayout {
					Spacing = 20, Padding = 50,
					VerticalOptions = LayoutOptions.Center,
					Children = {
						new Entry { Placeholder = "Username" },
						new Entry { Placeholder = "Password", IsPassword = true },
						new Button {
							Text = "Login",
							TextColor = Color.White,
							BackgroundColor = Color.FromHex("77D065")}, 
						new Label {
							XAlign = TextAlignment.Center,
							Text = "Please enter your username and password"
						}
					}
				}
			};
					
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

