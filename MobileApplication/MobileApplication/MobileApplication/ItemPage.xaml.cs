using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MobileApplication
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
