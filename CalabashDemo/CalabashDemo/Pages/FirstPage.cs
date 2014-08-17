using Xamarin.Forms;
using CalabashDemo.Services;

namespace CalabashDemo.Pages
{
	public class FirstPage : ContentPage
	{
		private readonly ILoginService _loginService;

		public FirstPage()
		{
			_loginService = DependencyService.Get<ILoginService>();

			Title = "First Page";

			var button = new Button {
				Text = "Open Second Page",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				HorizontalOptions = LayoutOptions.CenterAndExpand,
			};

			button.Clicked += (sender, e) =>
			{
				Navigation.PushAsync(App.GetSecondPage());
			};

			Content = button;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			ConfirmLogin();
		}

		private async void ConfirmLogin()
		{
			if(!await _loginService.IsLoggedIn())
			{
				Navigation.PushModalAsync(new LoginPage());
			}
		}
	}
}

