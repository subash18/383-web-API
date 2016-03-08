using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp.Portable;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.HttpClient;
using Xamarin.Forms;


namespace MobileApplication
{
    public partial class LogInPage : ContentPage
    {
        User user = new User();
        
        private RestClient client = new RestClient("http://147.174.166.47:58198/");

        public LogInPage()
        {
           Title = "383 Managment App";

            

            Label header = new Label
            {
                Text = "383 Management App",
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 20
            };
            
            var emailEntry = new Entry {Placeholder = "Email"};
            emailEntry.TextChanged += (sender, e) => { user.Email= e.NewTextValue; };
            
            Entry passwordEntry= new Entry {Placeholder = "Password", IsPassword = true};
            passwordEntry.TextChanged += (sender, e) => { user.Password = e.NewTextValue; };

            Button button = new Button
            {
                Text = "Login",
                WidthRequest = 50,
                HeightRequest = 80,
                TextColor = Color.White,
                BackgroundColor = Color.FromHex("77D065"),

            };

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
            var request = new RestRequest("api/Products", Method.GET);
            var response = await client.Execute<IEnumerable<Product>>(request);

           await Navigation.PushAsync(new ProductsPage(response.Data));
        }    
    }
}
