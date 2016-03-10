using System;
using MobileApplication.Models;
using MobileApplication.Services;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using Xamarin.Forms;


namespace MobileApplication.Pages
{
    public partial class LogInPage : ContentPage
    {
        User user = new User();

        public LogInPage()
        {
            Title = "383 Managment App";



            var header = new Label { Text = "383 Management App", HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center, FontSize = 20 };

            var emailEntry = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email, };
            emailEntry.TextChanged += (sender, e) => { user.Email = e.NewTextValue; };

            var passwordEntry = new Entry { Placeholder = "Password", IsPassword = true };
            passwordEntry.TextChanged += (sender, e) => { user.Password = e.NewTextValue; };

            var button = new Button { Text = "Login", WidthRequest = 50, HeightRequest = 80, TextColor = Color.White, BackgroundColor = Color.FromHex("77D065"), };
            button.Clicked += OnButtonClicked;

            this.Content = new StackLayout
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    header,
                    new BoxView{HorizontalOptions = LayoutOptions.FillAndExpand},
                    new BoxView { VerticalOptions = LayoutOptions.FillAndExpand },
                    emailEntry,
                    new BoxView{HorizontalOptions = LayoutOptions.FillAndExpand},
                    passwordEntry,
                     new BoxView{HorizontalOptions = LayoutOptions.FillAndExpand},
                    new BoxView { VerticalOptions = LayoutOptions.FillAndExpand },
                    button

                }
            };



        }




        async void OnButtonClicked(object sender, EventArgs e)
        {
            var email = user.Email;
            var password = user.Password;
            
            var connect = new Rest("api/ApiKey?email=" + email + "&password=" + password, Method.GET);
            var response = await SingletonClient.GetClient().Execute(connect.request);
            var deserializer = new JsonDeserializer();
            user = deserializer.Deserialize<User>(response);
            user.Email = email;
            user.Password = password;

            await Navigation.PushAsync(new ProductsPage(user));
        }
    }
}
