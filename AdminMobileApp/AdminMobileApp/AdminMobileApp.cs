using System;

using Xamarin.Forms;

namespace AdminMobileApp
{
	public class App : Application
	{
		public App ()
		{
			MainPage = new NavigationPage (new LoginPage ());

		
		}
	};
}
			
					




