using System;
using Xamarin.Forms;
using CalabashDemo.Pages;

namespace CalabashDemo.Pages
{
	public class App
	{
		public static Page GetLoginPage()
		{
			return new LoginPage();
		}

		public static Page GetFirstPage()
		{	
			return new NavigationPage(new FirstPage());
		}

		public static Page GetSecondPage()
		{
			return new SecondPage();
		}
	}
}

