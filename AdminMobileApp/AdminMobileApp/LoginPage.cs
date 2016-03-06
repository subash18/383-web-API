using System;

using Xamarin.Forms;

namespace AdminMobileApp
{
	public class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			var LoginButton = new Button () { Text = "Login", TextColor = Color.White, BackgroundColor = Color.FromHex ("77D065")};
			LoginButton.Clicked += async (object sender, EventArgs e) => 
			{
				await this.Navigation.PushAsync(new ManagementPage());
			};
				
			Content = new StackLayout { 
				Spacing = 20, Padding = 50,
				VerticalOptions = LayoutOptions.Center,
				Children = {
					new Entry { Placeholder = "Username" },
					new Entry { Placeholder = "Password", IsPassword = true },
					LoginButton,
					//new Button {
						//Text = "Login",
						//TextColor = Color.White,
						//BackgroundColor = Color.FromHex ("77D065"),
						//Command = new Command(() => NavigationPage.PushAsync(new ManagementPage()))
	 
					new Label {
						XAlign = TextAlignment.Center,
						Text = "Please enter your username and password"
					}
				}
			};
		}
	}}


