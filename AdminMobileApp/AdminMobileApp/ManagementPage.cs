using System;

using Xamarin.Forms;

namespace AdminMobileApp
{
	public class ManagementPage : ContentPage
	{
		public ManagementPage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "This is the management page" }
				}
			};
		}
	}
}


