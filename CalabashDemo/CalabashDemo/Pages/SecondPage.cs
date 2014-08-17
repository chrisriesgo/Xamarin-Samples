using System;
using Xamarin.Forms;
using CalabashDemo.Services;

namespace CalabashDemo.Pages
{
	public class SecondPage : ContentPage
	{
		private readonly ILoginService _loginService;

		public SecondPage()
		{
			_loginService = DependencyService.Get<ILoginService>();

			Title = "Second Page";
		
			var button = new Button {
				Text = "Logout",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};
			button.Clicked += async (sender, e) =>
			{
				await _loginService.Logout();
				Navigation.PopToRootAsync();
			};

			Content = button;
		}
	}
}

