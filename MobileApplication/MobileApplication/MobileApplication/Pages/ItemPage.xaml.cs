using System;
using MobileApplication.Models;
using Xamarin.Forms;

namespace MobileApplication.Pages
{
    public partial class ItemPage : ContentPage
    {
        public ItemPage(Product product)
        {
            var name = new Label
            {
                Text = product.Name,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center,
                FontSize = 10
            };

            this.Content = new StackLayout
            {
                Spacing = 0,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    name,
                    new BoxView {HorizontalOptions = LayoutOptions.FillAndExpand},
                    new BoxView {VerticalOptions = LayoutOptions.FillAndExpand},
                }

            };
        }
    }
}
